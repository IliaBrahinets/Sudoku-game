import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SudokuMainComponent } from './sudoku-main.component';

describe('SudokuMainComponent', () => {
  let component: SudokuMainComponent;
  let fixture: ComponentFixture<SudokuMainComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SudokuMainComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SudokuMainComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
