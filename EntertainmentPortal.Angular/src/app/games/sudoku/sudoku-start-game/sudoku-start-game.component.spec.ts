import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SudokuStartGameComponent } from './sudoku-start-game.component';

describe('SudokuStartGameComponent', () => {
  let component: SudokuStartGameComponent;
  let fixture: ComponentFixture<SudokuStartGameComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SudokuStartGameComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SudokuStartGameComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
