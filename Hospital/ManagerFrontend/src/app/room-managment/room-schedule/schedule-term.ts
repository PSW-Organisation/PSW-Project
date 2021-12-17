export interface IScheduleTerm{
    id : number,
    startTime: Date,
    durationInMinutes: number,
    endTime: Date,
    type: string
    termState : StateOfRenovation
}

export enum StateOfRenovation{
    pending, successfull, unsuccessfull, cancelled 
}