export class UpdateCellRequest {
    constructor(public XCoordinate: number,
                public YCoordinate: number,
                public Value: number | null) {}
}
