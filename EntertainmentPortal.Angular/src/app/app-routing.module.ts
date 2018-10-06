import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SudokuMainComponent } from './games/sudoku/sudoku-main/sudoku-main.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'games/sudoku',
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
