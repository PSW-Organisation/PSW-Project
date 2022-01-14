import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { IShift } from './shift';

@Injectable({
  providedIn: 'root'
})
export class ShiftService {
  private _shiftUrl = 'http://localhost:42789/api/shift';

  constructor(private _http: HttpClient) { }

  getAllShifts(): Observable<IShift[]> {
    return this._http.get<IShift[]>(this._shiftUrl).pipe(
      tap((data) => console.log('All: ', JSON.stringify(data))),
      catchError(this.handleError)
    );
  }

  createShift(shift: IShift): Observable<IShift>{
    return this._http.post<IShift>(this._shiftUrl, shift).pipe(
      tap((data) => console.log('All: ', JSON.stringify(data))),
      catchError(this.handleError)
    );
  }

  deleteShift(shiftId: Number): Observable<IShift>{
    return this._http.delete<IShift>(`${this._shiftUrl}/${shiftId}`).pipe(
      tap((data) => console.log('All: ', JSON.stringify(data))),
      catchError(this.handleError)
    );
  }

  updateShift(shift: IShift): Observable<IShift>{
    return this._http.put<IShift>(this._shiftUrl, shift).pipe(
      tap((data) => console.log('All: ', JSON.stringify(data))),
      catchError(this.handleError)
    );
  }

  private handleError(err: HttpErrorResponse) {
    console.log(err.message);
    return throwError(err.message);
  }
}
