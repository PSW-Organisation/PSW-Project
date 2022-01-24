export default interface AppointmentSchedulingEvent{
    id: number;
    idUser: string;
    timeStamp: Date | string;
    eventAppName: string;
    eventClass: string;
    eventGuid: string;
    duration: number;
}