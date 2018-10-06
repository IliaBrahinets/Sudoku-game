import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SudokuGameStatisticsComponent } from './sudoku-game-statistics.component';

describe('SudokuGameStatisticsComponent', () => {
  let component: SudokuGameStatisticsComponent;
  let fixture: ComponentFixture<SudokuGameStatisticsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SudokuGameStatisticsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SudokuGameStatisticsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
