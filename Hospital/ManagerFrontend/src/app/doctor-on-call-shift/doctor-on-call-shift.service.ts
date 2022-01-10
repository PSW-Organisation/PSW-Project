import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { Doctor } from '../doctors/Doctor';
import { IOnCallShift } from './on-call-shift';


@Injectable({
  providedIn: 'root'
})
export class DoctorOnCallShiftService {

  private _onCallShiftUri = 'http://localhost:42789/api/oncallshift';

  constructor(private _http: HttpClient) { }

  GetDoctorsOnCallShift(date: string): Observable<Doctor[]> {
    //treba posalti date, dal preko body ili preko param parametar
    return this._http.get<Doctor[]>(this._onCallShiftUri+'/doctorsoncallshift/'+`${date}`).catch(this.handleError);
  }

  GetDoctorsNotOnCallShift(date: string): Observable<Doctor[]> {
    //treba posalti date, dal preko body ili preko param parametar
    return this._http.get<Doctor[]>(this._onCallShiftUri+'/doctorsnotoncallshift/'+`${date}`).catch(this.handleError);
  }

  AddDoctorOnCallShift(onCallShift:IOnCallShift): Observable<IOnCallShift> {
    //treba posalti date, dal preko body ili preko param parametar
    return this._http.post<IOnCallShift>(this._onCallShiftUri,onCallShift).catch(this.handleError);
  }

  RemoveDoctorOnCallShift(onCallShift:IOnCallShift): Observable<Doctor> {
    //treba posalti date, dal preko body ili preko param parametar
    return this._http.delete<Doctor>(this._onCallShiftUri,{
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      }),
      body: onCallShift
    }).catch(this.handleError);
  }

  GetAllOnCallShiftByDoctorId(doctorId: string): Observable<IOnCallShift[]> {
    //treba posalti date, dal preko body ili preko param parametar
    return this._http.get<IOnCallShift[]>(this._onCallShiftUri+`/${doctorId}`).catch(this.handleError);
  }

  private handleError(err: HttpErrorResponse) {
    console.log(err.message);
    return Observable.throw(err.message)
  }
}
