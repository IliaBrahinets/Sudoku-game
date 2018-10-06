import { Component, OnInit } from '@angular/core';
import { Cell } from 'src/app/games/sudoku/sudoku-board/models/cell';
import { TestData_Board } from 'src/app/games/sudoku/sudoku-board/models/testBoard';
import { Direction } from 'src/app/games/sudoku/sudoku-board/appServices/Direction.Enum';
import { KeyBoardEventHandlingHelper } from './appServices/KeyBoardEventHandlingHelper.service';
import { SudokuBoardService } from 'src/app/games/sudoku/sudoku-board/services/sudokuboard.service';
import { PlayerBoard } from './models/player-board';
import { ActivatedRoute, Router } from '@angular/router';
import { toInteger } from '@ng-bootstrap/ng-bootstrap/util/util';
import { UpdateCellRequest } from './models/update-cell-request';
import { BoardStatus } from './models/board-status.enum';

@Component({
  selector: 'app-sudoku-board',
  templateUrl: './sudoku-board.component.html',
  styleUrls: ['./sudoku-board.component.scss']
})
export class SudokuBoardComponent implements OnInit {

  private cellEmptyValue: number = Cell.EmptyValue;

  public cells: Cell[][] = new Array<Array<Cell>>(9);

  private selectedCell: Cell = new Cell(-1, -1, -1, Cell.EmptyValue, false);

  public boardStatus: BoardStatus;

  private playerBoard: PlayerBoard;

  constructor(private boardService: SudokuBoardService,
              private keyHelper: KeyBoardEventHandlingHelper,
              private route: ActivatedRoute,
              private router: Router) { }

  ngOnInit() {
    this.initBoard();
  }

  private initBoard() {
    for (let i = 0; i < 9; i++) {
      this.cells[i] = new Array<Cell>();
    }

    this.route.params.subscribe(params => {
      const id: number = toInteger(params['playerBoardId']);
      this.boardService.getBoard(id).subscribe(board => {
        this.playerBoard = board;
        this.initBoardViewRepresentation(this.playerBoard);
      });
    });
  }

  private initBoardViewRepresentation(playerBoard: PlayerBoard) {
    playerBoard.CellList.forEach((cell) => {
      this.cells[cell.YCoordinate][cell.XCoordinate] = cell;
    });
  }

  public resetBoard() {
    this.boardService.resetBoard(this.playerBoard.BoardId).subscribe(board => {
      this.playerBoard = board;
      this.initBoardViewRepresentation(this.playerBoard);
    });
  }

  public boardKeyDown(event: KeyboardEvent) {
    this.handlingNumberInput(event);
    this.movePointerKeyBoardButtonsHandler(event);
  }

  // Handlig interacting with user.
  private handlingNumberInput(event: KeyboardEvent) {
    const key = event.key;
    const code = event.code;

    if (!this.selectedCell.IsConst) {

      if (this.keyHelper.isKeyNumber(key, code)) {
          const newValue = parseInt(key, null);
          if (newValue !== 0) {
              this.changeCellValue(this.selectedCell, newValue);
          }
      }

      if (this.keyHelper.isKeyBackSpace(key, code)) {
          const newValue = Cell.EmptyValue;
          this.changeCellValue(this.selectedCell, newValue);
      }
  }
  }

  private changeCellValue(cell: Cell, newValue: number|null) {
    const updateRequest = new UpdateCellRequest(cell.XCoordinate, cell.YCoordinate, newValue);
    this.boardService.updateCellAndGetStatus(this.playerBoard.BoardId, updateRequest)
                     .subscribe(boardStatus => {
                       cell.Value = newValue;
                       this.boardStatus = boardStatus;
                       if (boardStatus === BoardStatus.Complete) {
                         this.completeGame();
                       }
                     });
  }

  private completeGame() {
    const finishURL = '../../finishGame';
    this.router.navigate([finishURL], {relativeTo: this.route});
  }

  public newGame() {
    const newURL = '../../startGame/newGame';
    this.router.navigate([newURL], {relativeTo: this.route});
  }

  // MovingPointer
  public movePointerClickHandler(event) {
    const actualTarget: HTMLElement = event.target.parentElement;

    let X: number;
    let Y: number;

    X = parseInt(actualTarget.getAttribute('x'), null);
    Y = parseInt(actualTarget.getAttribute('y'), null);
    if (!(isNaN(X) || isNaN(Y))) {
      this.selectedCell = this.cells[Y][X];
    }

  }

  private movePointerKeyBoardButtonsHandler(event: KeyboardEvent) {
      const key = event.key;
      const code = event.code;
      event.preventDefault();
      if (this.keyHelper.isMoveButton(key, code)) {
        const dir: Direction = this.keyHelper.getDirection(key, code);
        let newCellX = this.selectedCell.XCoordinate;
        let newCellY = this.selectedCell.YCoordinate;

        switch (dir) {
          case Direction.Up:
            newCellY--;
          break;
          case Direction.Right:
            newCellX++;
          break;
          case Direction.Down:
            newCellY++;
          break;
          case Direction.Left:
            newCellX--;
          break;
        }

        if (this.isInBounds(newCellX, newCellY)) {
          this.selectedCell = this.cells[newCellY][newCellX];
        }

      }
  }

  // Some Helpers
  public isSelectedCell(cell: Cell): boolean {
    return cell.XCoordinate === this.selectedCell.XCoordinate
        && cell.YCoordinate === this.selectedCell.YCoordinate;
  }

  private isInBounds(X: number, Y: number): boolean {

    if (X >= 0 && X <= 8) {
      if (Y >= 0 && Y <= 8) {
          return true;
      }
    }

    return false;

  }

}
