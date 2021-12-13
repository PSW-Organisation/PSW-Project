export interface IEquipment 
{
    id: number,
    quantity: number, 
    name: string, 
    type: string,
    roomId: number
}

export interface IEquipmentQuantity 
{
    name: string, 
    quantity: number, 
}

export interface IParamsOfRelocationEquipment
{
    IdSourceRoom: number,
    IdDestinationRoom: number,
    NameOfEquipment: string,
    QuantityOfEquipment: number,
    StartTime: Date,
    EndTime: Date,
    DurationInMinutes: number
}

export interface IFreeTerms{
    startTime: Date,
    endTime: Date,
}

export class ParamsOfRelocationEquipment implements IParamsOfRelocationEquipment{
    IdSourceRoom: number;
    IdDestinationRoom: number;
    NameOfEquipment: string;
    QuantityOfEquipment: number;
    StartTime: Date;
    EndTime: Date;
    DurationInMinutes: number;
    
    constructor(IdSourceRoom: number, IdDestinationRoom: number, NameOfEquipment: string, QuantityOfEquipment: number,
        StartTime: Date, endTime: Date, durationInMinutes: number)
    {
        this.IdSourceRoom = IdSourceRoom;
        this.IdDestinationRoom = IdDestinationRoom;
        this.NameOfEquipment = NameOfEquipment;
        this.QuantityOfEquipment = QuantityOfEquipment;
        this.StartTime = StartTime;
        this.EndTime = endTime;
        this.DurationInMinutes = durationInMinutes;
    }
}