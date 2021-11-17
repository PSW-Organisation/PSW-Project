import { Allergen } from "./allergen";
import { Patient } from "./patient";

export interface MedicalRecord{
    bloodType: string,
    profession: string,
    doctorId: string,
    height: number,
    weight: number,
    personalId: string,
    patientId: string,
    patient: any,
    doctor: any
}
