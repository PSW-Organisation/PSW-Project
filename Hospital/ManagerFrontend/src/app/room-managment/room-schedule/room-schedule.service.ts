import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { IScheduleTerm } from './schedule-term';

@Injectable({
  providedIn: 'root'
})
export class RoomScheduleService {
  private _relocationTermsUrl = 'http://localhost:42789/api/termsofrelocation';
  private _renovationTermsUrl = 'http://localhost:42789/api/termsofrenovation';
  private _appointmentsUrl = 'http://localhost:42789/api/appointment';

  constructor(private _http: HttpClient) {}

  getAllRelocationTermsForRoom(id :number): Observable<IScheduleTerm[]> {
    return this._http.get<IScheduleTerm[]>(this._relocationTermsUrl+`/${id}`).pipe(
      tap((data) => console.log('Relocation terms: ', JSON.stringify(data))),
      catchError(this.handleError)
    );
  }

  getAllRenovationTermsForRoom(id :number): Observable<IScheduleTerm[]> {
    return this._http.get<IScheduleTerm[]>(this._renovationTermsUrl+`/${id}`).pipe(
      tap((data) => console.log('Renovation terms: ', JSON.stringify(data))),
      catchError(this.handleError)
    );
  }

  getAllAppointmentsForRoom(id :number): Observable<IScheduleTerm[]> {
    return this._http.get<IScheduleTerm[]>(this._appointmentsUrl+`/room/${id}`).pipe(
      tap((data) => console.log('Appointments: ', JSON.stringify(data))),
      catchError(this.handleError)
    );
  }

  private handleError(err: HttpErrorResponse) {
    console.log(err.message);
    return throwError(err.message);
  }


}
