export interface Feedback {
    id: string,
    patientId: string,
    text: string,
    anonymous: boolean,
    publishAllowed: boolean,
}