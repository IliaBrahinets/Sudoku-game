import { Injectable } from '@angular/core';
import { Direction } from 'src/app/games/sudoku/sudoku-board/appServices/Direction.Enum';

@Injectable({
    providedIn: 'root'
})
export class KeyBoardEventHandlingHelper {
    // each button group has buttons for each direction, placed like:[(up),(right),(down),(left)]
    private readonly MoveButtonsGroups: String[][] = [['w', 'd', 's', 'a'],
                                                    ['arrowup', 'arrowright', 'arrowdown', 'arrowleft']];
    isMoveButton(key: string, code: string): boolean {
        const arr = this.MoveButtonsGroups;
        key = key.toLowerCase();

        for (let i = 0; i < arr.length; i++) {

            const index = arr[i].findIndex(
                (value, _index, obj) => value.toString() === key);

            if (index !== -1) {
                return true;
            }

        }

        return false;
    }

    getDirection(moveButtonKey: string, moveButtonCode: string): Direction {
        const arr = this.MoveButtonsGroups;

        moveButtonKey = moveButtonKey.toLowerCase();
        moveButtonCode = moveButtonCode.toLowerCase();

        for (let i = 0; i < arr.length; i++) {

            const index = arr[i].findIndex(
                (value, _index, obj) => value.toString() === moveButtonKey);

            if (index !== -1) {
                return <Direction>index;
            }

        }

        throw new Error('that\'s not a move button');
    }

    isKeyNumber(key: string, code: string): boolean {
        const tryNum = parseInt(key, null);
        return !isNaN(tryNum);
    }

    isKeyBackSpace(key: string, code: string): boolean {
        return key === 'Backspace';
    }

}
