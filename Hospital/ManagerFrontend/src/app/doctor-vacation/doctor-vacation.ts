import { ITimeInterval } from "./time-interval";

export interface IDoctorVacation {
  id : number;
  dateSpecification : ITimeInterval;
  description : String;
  doctorId : String;
}
