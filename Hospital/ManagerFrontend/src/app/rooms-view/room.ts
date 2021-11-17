export interface IRoom {
  id: number;
  name: string;
  sector: string;
  floor: number;
  roomType: RoomType;
  isRenovated: boolean;
  isRenovatedUntil: string;
  numOfTakenBeds: number;
}

export enum RoomType {
  examination,
  operation,
  restingRoom,
  restroom,
  counter,
  waitingRoom,
}
