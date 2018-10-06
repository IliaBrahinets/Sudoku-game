import { Cell } from 'src/app/games/sudoku/sudoku-board/models/cell';

export class PlayerBoard {
    constructor(public BoardId: number,
                public PlayerId: number,
                public CellList: Cell[]) {}
}
