export class Cell {
    constructor(public XCoordinate: number,
                public YCoordinate: number,
                public BlockNumber: number,
                public Value: number|null,
                public IsConst: boolean) { }

    public static readonly EmptyValue: number|null = null;
}
