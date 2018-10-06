import { Component, OnInit } from '@angular/core';
import { UserService } from '../services/user.service';
import { User } from '../models/user';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-user-details',
  templateUrl: './user-details.component.html',
  styleUrls: ['./user-details.component.scss']
})
export class UserDetailsComponent {
  public isDisplay: boolean;
  public currentUser: User;

  constructor(private userService: UserService,
              private route: ActivatedRoute,
              private router: Router) {
                userService.currentUserObservable().subscribe(newUser => this.changeUser(newUser));
               }

  changeUser(newUser: User): any {
    if (newUser === null) {
      this.isDisplay = false;
      this.currentUser = null;
    } else {
      this.isDisplay = true;
      this.currentUser = newUser;
    }
  }

  logOut() {
    const logUpUrl = './';
    this.router.navigate([logUpUrl], {relativeTo: this.route});
  }

}
