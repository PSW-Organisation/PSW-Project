import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { Doctor } from './Doctor';

@Injectable({
  providedIn: 'root'
})
export class DoctorsService {

  private _doctorUri = 'http://localhost:42789/api/doctor';

  constructor(private _http: HttpClient) { }

  getDoctors(): Observable<Doctor[]> {
    return this._http.get<Doctor[]>(this._doctorUri).catch(this.handleError);
  }

  private handleError(err: HttpErrorResponse) {
    console.log(err.message);
    return Observable.throw(err.message)
  }

}
