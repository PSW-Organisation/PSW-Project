export interface Visit {
    id: number,
    startTime: Date,
    endTime: Date,
    visitType: number,
    doctorId: string,
    patientId: string,
    isReviewed: boolean,
    isCanceled: boolean,
    doctor: any
}