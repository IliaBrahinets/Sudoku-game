import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import {  } from 'rxjs/add/operator/take';
import { UserService } from 'src/app/games/sudoku/user-management/services/user.service';
import { User } from '../models/user';
import { map } from 'rxjs/operators';

@Injectable()
export class UserTokenInterceptor implements HttpInterceptor {
    constructor(private userService: UserService) {
    }
    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        const user = this.userService.getCurrentUser();
        if (user != null) {
            request = this.addToRequest(user, request);
        }

        return next.handle(request);
    }

    private addToRequest(user: User, request: HttpRequest<any>): HttpRequest<any> {
          // simply put that user's id is a token now.
          if (request.method.toLowerCase() === 'post') {
            request.body.playerId = user.PlayerId;
            request = request.clone({
                setParams: {
                    'playerId': user.PlayerId.toString()
                }
            });
        } else {
            request = request.clone({
                setParams: {
                    'playerId': user.PlayerId.toString()
                }
            });
        }

        return request;
    }
}
