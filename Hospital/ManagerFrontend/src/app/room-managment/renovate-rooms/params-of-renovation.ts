import { RoomType } from '../rooms-view/room';

export interface IParamsOfRenovation {
  TypeOfRenovation: number;
  StartTime: Date;
  EndTime: Date;
  DurationInMinutes: number;
  IdRoomA: number;
  IdRoomB: number;
  EquipmentLogic: EquipmentLogic;
  NewNameForRoomA: string;
  NewSectorForRoomA: string;
  NewRoomTypeForRoomA: RoomType;
  NewNameForRoomB: string;
  NewSectorForRoomB: string;
  NewRoomTypeForRoomB: RoomType;
}

export enum EquipmentLogic {
  ALL_EQUIPMENT_IN_A,
  ALL_EQUIPMENT_IN_B,
  HALF_IN_A_HALF_IN_B,
}
