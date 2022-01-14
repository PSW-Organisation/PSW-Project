import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { IDoctorVacation } from './doctor-vacation';

@Injectable({
  providedIn: 'root'
})
export class DoctorVacationService {
  private _vacationUrl = 'http://localhost:42789/api/doctorvacation';
  constructor(private _http: HttpClient) { }

  getDoctorVacations(doctorId : string): Observable<IDoctorVacation[]> {
    console.log(doctorId);
    return this._http.get<IDoctorVacation[]>(this._vacationUrl+`/${doctorId}`).pipe(
      tap((data) => console.log('Doctors vacations: ', JSON.stringify(data))),
      catchError(this.handleError)
    );
  }

  createDoctorVacation(vacation : IDoctorVacation): Observable<IDoctorVacation[]> {
    return this._http.post<IDoctorVacation[]>(this._vacationUrl,vacation).pipe(
      tap((data) => console.log('Doctors vacation: ', JSON.stringify(data))),
      catchError(this.handleError)
    );
  }

  updateDoctorVacation(vacation : IDoctorVacation): Observable<IDoctorVacation[]> {
    return this._http.put<IDoctorVacation[]>(this._vacationUrl,vacation).pipe(
      tap((data) => console.log('Doctors vacation: ', JSON.stringify(data))),
      catchError(this.handleError)
    );
  }

  deleteDoctorVacation(vacation : IDoctorVacation): Observable<IDoctorVacation[]> {
    return this._http.delete<IDoctorVacation[]>(this._vacationUrl,{
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      }),
      body: vacation
    }).pipe(
      tap((data) => console.log('Doctors vacation: ', JSON.stringify(data))),
      catchError(this.handleError)
    );
  }

  private handleError(err: HttpErrorResponse) {
    console.log(err.message);
    return throwError(err.message);
  }
}
