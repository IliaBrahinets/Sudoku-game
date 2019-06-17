import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SudokuRoutingModule } from './sudoku-routing.module';
import { SudokuBoardComponent } from './sudoku-board/sudoku-board.component';
import { NumberHelpersModule } from 'src/app/games/sudoku/helpers/NumberHelpers.module';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { SudokuBoardService } from 'src/app/games/sudoku/sudoku-board/services/sudokuboard.service';
import { LayoutModule } from '@angular/cdk/layout';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BrowserModule } from '@angular/platform-browser';
import { SudokuMainComponent } from './sudoku-main/sudoku-main.component';
import { AngularMaterialImports } from './angular-material.imports';
import { KeyBoardEventHandlingHelper } from './sudoku-board/appServices/KeyBoardEventHandlingHelper.service';
import { UserLogUpComponent } from './user-management/user-logup/user-logup.component';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { SudokuStartGameComponent } from './sudoku-start-game/sudoku-start-game.component';
import { UserService } from 'src/app/games/sudoku/user-management/services/user.service';
import { UserDetailsComponent } from './user-management/user-details/user-details.component';
import { UserTokenInterceptor } from 'src/app/games/sudoku/user-management/interseptors/usertoken.interceptor';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { SudokuStartGameService } from './sudoku-start-game/services/sudoku-start-game.service';
import { SudokuFinishGameComponent } from './sudoku-finish-game/sudoku-finish-game.component';
import { SudokuStartFromUnfinishedGameComponent } from './sudoku-start-game/sudoku-start-from-unfinished-game/sudoku-start-from-unfinished-game.component';
import { SudokuGameStatisticsComponent } from './sudoku-game-statistics/sudoku-game-statistics.component';
import { SudokuGameStatisticsService } from './sudoku-game-statistics/services/sudoku-game-statistics.service';
import { NgxLoadingModule } from 'ngx-loading';

@NgModule({
  imports: [
    CommonModule,
    HttpClientModule,
    FormsModule,
    SudokuRoutingModule,
    NumberHelpersModule,
    AngularMaterialImports,
    ReactiveFormsModule,
    NgxLoadingModule.forRoot({}),
  ],
  providers : [
    // Angular providers
    HttpClient,
    // Application providers
    SudokuBoardService,
    UserService,
    SudokuGameStatisticsService,
    SudokuStartGameService,
    KeyBoardEventHandlingHelper,
    // Interceptors
    {
      provide: HTTP_INTERCEPTORS,
      useClass: UserTokenInterceptor,
      multi: true
    }
  ],
  declarations: [
    SudokuBoardComponent,
    SudokuMainComponent,
    UserLogUpComponent,
    SudokuStartGameComponent,
    UserDetailsComponent,
    SudokuFinishGameComponent,
    SudokuStartFromUnfinishedGameComponent,
    SudokuGameStatisticsComponent],
  exports: [
    LayoutModule,
    BrowserModule,
    BrowserAnimationsModule,
    SudokuBoardComponent,
    SudokuMainComponent]
})
export class SudokuModule { }
