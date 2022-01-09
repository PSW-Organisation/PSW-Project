import { TimeSpan } from "./timespan";

export interface ITimeInterval{
    startTime : Date;
    endTime : Date;
    duration : TimeSpan;
}