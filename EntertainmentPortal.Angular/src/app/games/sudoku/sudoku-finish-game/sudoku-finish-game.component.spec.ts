import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SudokuFinishGameComponent } from './sudoku-finish-game.component';

describe('SudokuFinishGameComponent', () => {
  let component: SudokuFinishGameComponent;
  let fixture: ComponentFixture<SudokuFinishGameComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SudokuFinishGameComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SudokuFinishGameComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
