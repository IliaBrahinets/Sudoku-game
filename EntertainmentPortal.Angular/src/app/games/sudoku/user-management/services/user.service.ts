import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { UserLogUpRequest } from '../models/user-logup-request';
import { User } from '../models/user';
import { Observable } from 'rxjs/internal/Observable';
import { SudokuEnvironments } from '../../SudokuEnvironments';
import { Observer } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class UserService {
    private static localStorageUserKey = 'currentUser';
    private url = SudokuEnvironments.apiUrl + 'players';

    private changeLogStateObservers: Observer<User>[] = new Array<Observer<User>>();
    constructor(private http: HttpClient) {}

    currentUserObservable(): Observable<User> {
        return new Observable(observer => this.addNewLogStateObserver(observer));
    }

    private addNewLogStateObserver(observer: Observer<User>) {
        this.changeLogStateObservers.push(observer);
        observer.next(this.getCurrentUser());
    }

    getCurrentUser(): User {
        const user: string = localStorage.getItem(UserService.localStorageUserKey);
        return JSON.parse(user);
    }

    private userChange(newUser: User) {
        this.changeLogStateObservers.forEach(observer => {
            observer.next(newUser);
        });
    }

    logUp(request: UserLogUpRequest): Observable<User> {
        return this.http.post<User>(this.url, request)
                        .pipe<User>(map(user => this.SaveToLocalStorage(user)))
                        .pipe<User>(map(user => this.userChange(user)));
    }

    private SaveToLocalStorage(user: User): User {
        // simply put that user's id is a token now.
        if (user && user.PlayerId) {
            localStorage.setItem(UserService.localStorageUserKey, JSON.stringify(user));
        }

        return user;
    }

    logOut() {
        localStorage.removeItem(UserService.localStorageUserKey);
        this.userChange(null);
    }
}
