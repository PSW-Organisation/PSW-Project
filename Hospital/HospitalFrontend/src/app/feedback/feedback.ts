export interface Feedback {
    id: string,
    patientUsername: string,
    submissionDate: Date
    text: string,
    anonymous: boolean,
    publishAllowed: boolean,
    isPublished: boolean
}