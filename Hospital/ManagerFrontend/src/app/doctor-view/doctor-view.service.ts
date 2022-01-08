import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { Doctor } from '../doctors/Doctor';

@Injectable({
  providedIn: 'root'
})
export class DoctorViewService {

  private _doctorUri = 'http://localhost:42789/api/doctor';

  constructor(private _http: HttpClient) { }

  getDoctorById(doctorId: string): Observable<Doctor> {
    return this._http.get<Doctor>(this._doctorUri+'/'+doctorId).catch(this.handleError);
  }

  private handleError(err: HttpErrorResponse) {
    console.log(err.message);
    return Observable.throw(err.message)
  }
}
