import { Component, OnInit } from '@angular/core';
import { UserLogUpRequest } from '../models/user-logup-request';
import { UserService } from '../services/user.service';
import { NotificationsService } from 'angular2-notifications';
import { Router, ActivatedRoute } from '@angular/router';
import { SudokuStartGameService } from '../../sudoku-start-game/services/sudoku-start-game.service';
import { map } from 'rxjs/operators';
@Component({
  selector: 'app-user-logup',
  templateUrl: './user-logup.component.html',
  styleUrls: ['./user-logup.component.scss']
})
export class UserLogUpComponent implements OnInit {
  public user: UserLogUpRequest = new UserLogUpRequest('');

  public IsLoading = false;

  constructor(private userService: UserService,
              private startGameService: SudokuStartGameService,
              private notifications: NotificationsService,
              private route: ActivatedRoute,
              private router: Router) { }

  ngOnInit() {
    this.userService.logOut();
  }

  onSubmit(form: HTMLFormElement) {
    if (form.checkValidity()) {
      this.IsLoading = true;
      this.userService.logUp(this.user)
                      .pipe(map(t => {
                        this.IsLoading = false;
                        return t;
                      }))
                      .subscribe(() => this.handleSuccess(),
                                 () => this.handleError());
    }
  }

  private handleSuccess() {
    this.notifications.success('Succesfully done!');
    this.startGameService.isUnfinishedGameExist().subscribe(exist => {
      if (exist) {
        const unfinishedGameURL = '../startGame/unfinishedGame';
        this.router.navigate([unfinishedGameURL], {relativeTo: this.route});
      } else {
        const newGameURL = '../startGame/newGame';
        this.router.navigate([newGameURL], {relativeTo: this.route});
      }
    });
  }

  private handleError() {
    this.notifications.error('Error!');
  }

}
