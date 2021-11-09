export interface Feedback {
    id: number,
    patientUsername: string,
    submissionDate: Date
    text: string,
    anonymous: boolean,
    publishAllowed: boolean,
    isPublished: boolean
}