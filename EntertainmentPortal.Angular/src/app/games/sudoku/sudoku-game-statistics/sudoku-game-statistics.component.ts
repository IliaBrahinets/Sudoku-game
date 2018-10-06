import { Component, OnInit, Input } from '@angular/core';
import { User } from '../user-management/models/user';
import { SudokuGameStatisticsService } from './services/sudoku-game-statistics.service';

@Component({
  selector: 'app-sudoku-game-statistics',
  templateUrl: './sudoku-game-statistics.component.html',
  styleUrls: ['./sudoku-game-statistics.component.scss']
})
export class SudokuGameStatisticsComponent implements OnInit {

  public topPlayers: User[] = new Array<User>();

  public currentPlayer: User = null;

  constructor(private service: SudokuGameStatisticsService) {

  }

  ngOnInit() {
    this.service.getTopPlayer().subscribe(topPlayers => this.topPlayers = topPlayers);
    this.service.getCurrentPlayerStatistics().subscribe(player => this.currentPlayer = player);
  }

}
