import { Doctor } from "./doctor";

export interface MedicalPermit{
    doctor: Doctor,
    doctorId: string,
    expirationDate: Date
}