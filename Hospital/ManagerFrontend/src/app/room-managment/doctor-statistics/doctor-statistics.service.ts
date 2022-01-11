import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { IAppointmentCount } from './AppointmentCount';

@Injectable({
  providedIn: 'root',
})
export class DoctorStatisticsService {
  // http://localhost:42789/api/appointment/nelex/appointmentYearly
  // http://localhost:42789/api/appointment/nelex/appointmentMonthly
  // http://localhost:42789/api/appointment/nelex/appointmentWeekly
  // http://localhost:42789/api/appointment/nelex/appointmentDaily
  appointmentUrl = 'http://localhost:42789/api/appointment/';
  constructor(private _http: HttpClient) {}

  getAppointmentsCountYearly(
    doctorUsername: string
  ): Observable<IAppointmentCount> {
    return this._http
      .get<IAppointmentCount>(
        this.appointmentUrl + doctorUsername + '/appointmentYearly'
      )
      .pipe(
        tap((data) => console.log('All: ', JSON.stringify(data))),
        catchError(this.handleError)
      );
  }

  getPatientCountYearly(doctorUsername: string): Observable<IAppointmentCount> {
    return this._http
      .get<IAppointmentCount>(
        this.appointmentUrl + doctorUsername + '/patientYearly'
      )
      .pipe(
        tap((data) => console.log('All: ', JSON.stringify(data))),
        catchError(this.handleError)
      );
  }

  getAppointmentsCountMonthly(
    doctorUsername: string
  ): Observable<IAppointmentCount> {
    return this._http
      .get<IAppointmentCount>(
        this.appointmentUrl + doctorUsername + '/appointmentMonthly'
      )
      .pipe(
        tap((data) => console.log('All: ', JSON.stringify(data))),
        catchError(this.handleError)
      );
  }

  getPatientCountMonthly(
    doctorUsername: string
  ): Observable<IAppointmentCount> {
    return this._http
      .get<IAppointmentCount>(
        this.appointmentUrl + doctorUsername + '/patientMonthly'
      )
      .pipe(
        tap((data) => console.log('All: ', JSON.stringify(data))),
        catchError(this.handleError)
      );
  }

  getAppointmentsCountWeekly(
    doctorUsername: string
  ): Observable<IAppointmentCount> {
    return this._http
      .get<IAppointmentCount>(
        this.appointmentUrl + doctorUsername + '/appointmentWeekly'
      )
      .pipe(
        tap((data) => console.log('All: ', JSON.stringify(data))),
        catchError(this.handleError)
      );
  }

  getPatientCountWeekly(doctorUsername: string): Observable<IAppointmentCount> {
    return this._http
      .get<IAppointmentCount>(
        this.appointmentUrl + doctorUsername + '/patientWeekly'
      )
      .pipe(
        tap((data) => console.log('All: ', JSON.stringify(data))),
        catchError(this.handleError)
      );
  }

  getAppointmentsCountDaily(
    doctorUsername: string
  ): Observable<IAppointmentCount> {
    return this._http
      .get<IAppointmentCount>(
        this.appointmentUrl + doctorUsername + '/appointmentDaily'
      )
      .pipe(
        tap((data) => console.log('All: ', JSON.stringify(data))),
        catchError(this.handleError)
      );
  }

  getPatientCountDaily(doctorUsername: string): Observable<IAppointmentCount> {
    return this._http
      .get<IAppointmentCount>(
        this.appointmentUrl + doctorUsername + '/patientDaily'
      )
      .pipe(
        tap((data) => console.log('All: ', JSON.stringify(data))),
        catchError(this.handleError)
      );
  }

  private handleError(err: HttpErrorResponse) {
    console.log(err.message);
    return throwError(err.message);
  }
}
