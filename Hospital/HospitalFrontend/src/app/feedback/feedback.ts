export interface Feedback {
    patientUsername: string,
    submissionDate: Date
    text: string,
    anonymous: boolean,
    publishAllowed: boolean,
    isPublished: boolean
}