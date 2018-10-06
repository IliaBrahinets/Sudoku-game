import { Component, OnInit } from '@angular/core';
import { DifficultyLevel } from 'src/app/games/sudoku/models/DifficultyLevel.enum';
import { SudokuStartGameService } from './services/sudoku-start-game.service';
import { StartGameRequest } from './models/start-game-request';
import { Router, ActivatedRoute } from '@angular/router';
import { PlayerBoard } from '../sudoku-board/models/player-board';

@Component({
  selector: 'app-sudoku-start-game',
  templateUrl: './sudoku-start-game.component.html',
  styleUrls: ['./sudoku-start-game.component.scss']
})
export class SudokuStartGameComponent implements OnInit {

  private difficultyLevels: string[] = new Array<string>();
  private request: StartGameRequest = new StartGameRequest('');

  constructor(private service: SudokuStartGameService,
              private router: Router,
              private route: ActivatedRoute) {}

  ngOnInit() {
    this.initDifficultyLevels();
  }

  private initDifficultyLevels() {
    this.service.getDifficultyLevels().subscribe(val => this.difficultyLevels = val);
  }

  onSubmit(form: HTMLFormElement) {
    if (form.checkValidity()) {
      this.service.newGame(this.request)
                  .subscribe(playerBoard => this.navigateToBoard(playerBoard));
    }
  }

  private navigateToBoard(playerBoard: PlayerBoard) {
    const sudokuBoardURL = '../../board';
    this.router.navigate([sudokuBoardURL, playerBoard.BoardId], {relativeTo: this.route});
  }

}
