import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { SudokuEnvironments } from '../../sudokuenvironments';
import { User } from '../../user-management/models/user';

@Injectable({
    providedIn: 'root'
})
export class SudokuGameStatisticsService {
    private url = SudokuEnvironments.apiUrl + 'players/';
    constructor(private http: HttpClient) {}

    getTopPlayer(): Observable<User[]> {
        return this.http.get<User[]>(`${this.url}topPlayers`);
    }

    getCurrentPlayerStatistics(): Observable<User> {
        return this.http.get<User>(`${this.url}`);
    }
}
