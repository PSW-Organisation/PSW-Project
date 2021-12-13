import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { IFreeTerms } from '../move-equipment/room-equipment';
import { IParamsOfRenovation } from './params-of-renovation';

@Injectable({
  providedIn: 'root'
})
export class TermOfRenovationService {
  private _termsOfRenovationUrl = 'http://localhost:42789/api/termsofrenovation';

  constructor(private _http: HttpClient) { }
  
  getAllPosibleRenovationTerms(paramsOfRenovation: IParamsOfRenovation): Observable<IFreeTerms[]>  {
    return this._http.post<IFreeTerms[]>(this._termsOfRenovationUrl, paramsOfRenovation).
      pipe(tap((data) => console.log('All: ', JSON.stringify(data))), catchError(this.handleError));
  }

  createTermOfRelocation(paramsOfRenovation: IParamsOfRenovation): Observable<IParamsOfRenovation>{
    return this._http.put<IParamsOfRenovation>(this._termsOfRenovationUrl, paramsOfRenovation).
      pipe(tap((data) => console.log('All: ', JSON.stringify(data))), catchError(this.handleError));
  }

  private handleError(err: HttpErrorResponse) {
    console.log(err.message);
    return throwError(err.message);
  }
}
