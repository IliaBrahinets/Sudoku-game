import { Injectable } from '@angular/core';
import { SudokuEnvironments } from '../../SudokuEnvironments';
import { StartGameRequest } from '../models/start-game-request';
import { Observable } from 'rxjs';
import { PlayerBoard } from '../../sudoku-board/models/player-board';
import { HttpClient } from '@angular/common/http';

@Injectable({
    providedIn: 'root'
})
export class SudokuStartGameService {
    private url = SudokuEnvironments.apiUrl + 'game/';
    constructor(private http: HttpClient) {}

    newGame(request: StartGameRequest): Observable<PlayerBoard> {
       return this.http.post<PlayerBoard>(this.url, request);
    }

    getDifficultyLevels(): Observable<string[]> {
        const levelsPostfix = 'difficultyLevels';
        return this.http.get<string[]>(`${this.url}${levelsPostfix}`);
    }

    isUnfinishedGameExist(): Observable<boolean> {
        const unfinishedGamePostfix = 'unfinishedGame/existenseStatus';
        return this.http.get<boolean>(`${this.url}${unfinishedGamePostfix}`);
    }

    getUnfinishedGame(): Observable<PlayerBoard> {
        const unfinishedGamePostfix = 'unfinishedGame';
        return this.http.get<PlayerBoard>(`${this.url}${unfinishedGamePostfix}`);
    }
}
