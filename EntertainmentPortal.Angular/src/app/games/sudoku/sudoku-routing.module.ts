import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SudokuBoardComponent } from './sudoku-board/sudoku-board.component';
import { SudokuMainComponent } from './sudoku-main/sudoku-main.component';
import { UserLogUpComponent } from './user-management/user-logup/user-logup.component';
import { SudokuStartGameComponent } from './sudoku-start-game/sudoku-start-game.component';
import { SudokuFinishGameComponent } from './sudoku-finish-game/sudoku-finish-game.component';
import { SudokuStartFromUnfinishedGameComponent } from './sudoku-start-game/sudoku-start-from-unfinished-game/sudoku-start-from-unfinished-game.component';
import { SudokuGameStatisticsComponent } from './sudoku-game-statistics/sudoku-game-statistics.component';

const childRoutes: Routes = [
  {
    path: 'board/:playerBoardId', component: SudokuBoardComponent
  },
  {
    path: 'finishGame', component: SudokuFinishGameComponent
  },
  {
    path: 'startGame/unfinishedGame', component: SudokuStartFromUnfinishedGameComponent
  },
  {
    path: 'topPlayers', component: SudokuGameStatisticsComponent
  },
  {
    path: 'startGame/newGame', component: SudokuStartGameComponent
  },
  {
    path: '',
    redirectTo: 'logUp',
    pathMatch: 'full'
  },
  {
    path: 'logUp', component: UserLogUpComponent
  }
];

const common = 'games/sudoku';
const routes: Routes = [
  {
    path: common, component: SudokuMainComponent, children: childRoutes
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SudokuRoutingModule { }
