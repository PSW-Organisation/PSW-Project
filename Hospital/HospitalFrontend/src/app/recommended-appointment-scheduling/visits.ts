export interface Visit {
    startTime: Date,
    endTime: Date,
    visitType: number,
    doctorId: string,
    patientId: string,
    isReviewed: boolean,
    isCanceled: boolean,
}