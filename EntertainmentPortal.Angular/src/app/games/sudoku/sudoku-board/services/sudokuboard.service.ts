import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Cell } from 'src/app/games/sudoku/sudoku-board/models/cell';
import { Observable } from 'rxjs';
import { SudokuEnvironments } from '../../sudokuenvironments';
import { BoardStatus } from '../models/board-status.enum';
import { UpdateCellRequest } from '../models/update-cell-request';
import { PlayerBoard } from '../models/player-board';

@Injectable({
    providedIn: 'root'
})
export class SudokuBoardService {
    private url = SudokuEnvironments.apiUrl + 'game';

    constructor(private http: HttpClient) {}

    public getBoard(playerBoardId: number): Observable<PlayerBoard> {
        return this.http.get<PlayerBoard>(`${this.url}/${playerBoardId}`);
    }

    public resetBoard(playerBoardId: number): Observable<PlayerBoard> {
        return this.http.put<PlayerBoard>(`${this.url}/${playerBoardId}/reset`, null);
    }

    public updateCellAndGetStatus(playerBoardId: number, updateRequest: UpdateCellRequest): Observable<BoardStatus> {
        return this.http.put<BoardStatus>(`${this.url}/${playerBoardId}/cell/boardStatus`, updateRequest);
    }
}
