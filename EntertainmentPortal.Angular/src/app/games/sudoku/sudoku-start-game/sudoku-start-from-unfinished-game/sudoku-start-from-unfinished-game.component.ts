import { Component, OnInit } from '@angular/core';
import { SudokuStartGameService } from '../services/sudoku-start-game.service';
import { Router, ActivatedRoute } from '@angular/router';
import { PlayerBoard } from '../../sudoku-board/models/player-board';

@Component({
  selector: 'app-sudoku-start-from-unfinished-game',
  templateUrl: './sudoku-start-from-unfinished-game.component.html',
  styleUrls: ['./sudoku-start-from-unfinished-game.component.scss']
})
export class SudokuStartFromUnfinishedGameComponent implements OnInit {

  constructor(private service: SudokuStartGameService,
              private router: Router,
              private route: ActivatedRoute) {}

  ngOnInit() {

  }

  newGame() {
    this.navigateToNewGame();
  }

  continueGame() {
    this.service.getUnfinishedGame().subscribe(playerBoard => this.navigateToBoard(playerBoard));
  }

  private navigateToBoard(playerBoard: PlayerBoard) {
    const sudokuBoardURL = '../../board';
    this.router.navigate([sudokuBoardURL, playerBoard.BoardId], {relativeTo: this.route});
  }

  private navigateToNewGame() {
    const sudokuNewGameURL = '../newGame';
    this.router.navigate([sudokuNewGameURL], {relativeTo: this.route});
  }


}
