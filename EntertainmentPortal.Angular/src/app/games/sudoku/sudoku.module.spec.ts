import { SudokuModule } from './sudoku.module';

describe('SudokuModule', () => {
  let sudokuModule: SudokuModule;

  beforeEach(() => {
    sudokuModule = new SudokuModule();
  });

  it('should create an instance', () => {
    expect(sudokuModule).toBeTruthy();
  });
});
