export interface IMoveEquipmentActions
{
    sourceRoomID: number,
    destinationRoomID: number,
    nameOfEquipment: string,
    numberOfEvents: number
}

export interface EventMoveEquipment{
    idUser:string,
    timeStamp: Date,
    sourceRoomID: number,
    destinationRoomID: number,
    nameOfEquipment: string
}