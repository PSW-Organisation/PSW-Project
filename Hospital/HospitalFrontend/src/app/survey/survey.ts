import { Question } from "./question";

export interface Survey {
    patientId: string,
    submissionDate: Date,
    visitId: number,
    questions: Question[]
}