import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SudokuStartFromUnfinishedGameComponent } from './sudoku-start-from-unfinished-game.component';

describe('SudokuStartFromUnfinishedGameComponent', () => {
  let component: SudokuStartFromUnfinishedGameComponent;
  let fixture: ComponentFixture<SudokuStartFromUnfinishedGameComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SudokuStartFromUnfinishedGameComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SudokuStartFromUnfinishedGameComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
