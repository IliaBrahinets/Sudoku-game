import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from '../user-management/services/user.service';

@Component({
  selector: 'app-sudoku-finish-game',
  templateUrl: './sudoku-finish-game.component.html',
  styleUrls: ['./sudoku-finish-game.component.scss']
})
export class SudokuFinishGameComponent implements OnInit {

  constructor(private userService: UserService,
              private router: Router,
              private route: ActivatedRoute) { }

  ngOnInit() {
  }

  newGame() {
    const startURL = '../';
    this.router.navigate([startURL], {relativeTo: this.route});
  }

}
