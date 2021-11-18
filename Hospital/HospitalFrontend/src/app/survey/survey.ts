import { Question } from "./question";

export interface Survey {
    patientId: string,
    submissionDate: Date,
    visitId: 1,
    questions: Question[]
}