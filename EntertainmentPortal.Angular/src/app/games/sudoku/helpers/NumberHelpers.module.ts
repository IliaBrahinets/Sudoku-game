import { PipeTransform } from '@angular/core';
import { Pipe } from '@angular/core';
import { NgModule } from '@angular/core';


@Pipe({name: 'isEven'})
export class IsNumberEvenPipe implements PipeTransform {
    transform(value: number): boolean {
        return value % 2 === 0;
    }
}

@Pipe({name: 'isOdd'})
export class IsNumberOddPipe implements PipeTransform {
    transform(value: number): boolean {
        return value % 2 !== 0;
    }
}


// @NgModule decorator with its metadata
@NgModule({
    declarations: [
        IsNumberEvenPipe,
        IsNumberOddPipe
    ],
    exports: [
        IsNumberEvenPipe,
        IsNumberOddPipe
    ]
})
export class NumberHelpersModule { }
