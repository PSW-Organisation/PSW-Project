import { Allergen } from "./allergen";
import { MedicalPermit } from "./medical-permit";
import { MedicalRecord } from "./medical-record";

export interface Patient{
    loginType: string,
    username: string,
    password: string,
    name: string,
    parentName: string,
    surname: string,
    dateOfBirth: Date,
    gender: string,
    phone: string,
    email: string,
    address: string,
    city: string,
    country: string,
    isActivated: boolean,
    isBlocked: boolean,
    medical: MedicalRecord,
    allergens: Allergen[],
    medicalPermits: MedicalPermit[]
}