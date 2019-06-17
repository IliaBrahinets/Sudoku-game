import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MATERIAL_SANITY_CHECKS } from '@angular/material/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NotificationsService, SimpleNotificationsModule } from '../../node_modules/angular2-notifications';
import { SudokuModule } from './games/sudoku/sudoku.module';
import { NgxLoadingModule } from 'ngx-loading';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    NgbModule.forRoot(),
    BrowserModule,
    AppRoutingModule,
    SimpleNotificationsModule.forRoot(),
    BrowserAnimationsModule,
    // App imports
    SudokuModule
  ],
  providers: [
    { provide: MATERIAL_SANITY_CHECKS, useValue: false }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
