import { IRoom } from './room';

export interface IRoomGraphic {
  id: number;
  name: string;
  x: number;
  y: number;
  width: number;
  height: number;
  doorPosition: string;
  room: IRoom;
}
