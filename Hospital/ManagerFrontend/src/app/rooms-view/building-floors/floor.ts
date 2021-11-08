import { IRoom } from "../room";

export interface IFloor {
    floor: number;
    rooms: Array<IRoom>;
}