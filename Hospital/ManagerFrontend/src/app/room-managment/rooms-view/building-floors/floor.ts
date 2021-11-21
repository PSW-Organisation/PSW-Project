import { IRoomGraphic } from "../roomGraphic";

export interface IFloor {
    floor: number;
    roomGraphics: Array<IRoomGraphic>;
    buildingId: string;
}