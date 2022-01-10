import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { Doctor } from '../doctors/Doctor';
import { OnCallShift } from './OnCallShift';


@Injectable({
  providedIn: 'root'
})
export class DoctorOnCallShiftService {

  private _onCallShiftUri = 'http://localhost:42789/api/oncallshift';

  constructor(private _http: HttpClient) { }

  GetDoctorsOnCallShift(date: Date): Observable<Doctor[]> {
    //treba posalti date, dal preko body ili preko param parametar
    return this._http.get<Doctor[]>(this._onCallShiftUri+'/doctorsoncallshift').catch(this.handleError);

    // delete this
    /*
    var retVal = Observable.create((observer: { next: (arg0: Doctor) => void; complete: () => void; }) => {
      observer.next(new Doctor('rikiID', 'Specializacija', 1, 'Riki@', 'Riki','Rikic', '343253', 'email@', 'marka kralja', 'Novi Sad', 'Serbia'));
      observer.next(new Doctor('mikiID', 'Specializacija', 1, 'Mika@', 'Mika', 'Mikic', '343253', 'email@', 'marka kralja', 'Novi Sad', 'Serbia'));
      observer.next(new Doctor('pavleID', 'Specializacija', 1, 'Pavle@', 'Pavle','Pavlovic', '343253', 'email@', 'marka kralja', 'Novi Sad', 'Serbia'));
      observer.complete();
    });
    return retVal;
    */
  }

  GetDoctorsNOTOnCallShift(date: Date): Observable<Doctor[]> {
    //treba posalti date, dal preko body ili preko param parametar
    return this._http.get<Doctor[]>(this._onCallShiftUri+'/doctorsnotoncallshift').catch(this.handleError);

    // delete this
    /*
    var retVal = Observable.create((observer: { next: (arg0: Doctor) => void; complete: () => void; }) => {
      observer.next(new Doctor('stefanID', 'Specializacija', 1, 'stefke@', 'Stefan', 'Stefanovic', '343253', 'email@', 'marka kralja', 'Novi Sad', 'Serbia'));
      observer.next(new Doctor('kikiID', 'Specializacija', 1, 'kristijan@', 'Kristijan','kriki', '343253', 'email@', 'marka kralja', 'Novi Sad', 'Serbia'));
  
      observer.complete();
    });
    return retVal;
    */
  }

  AddDoctorOnCallShift(doctorID: string, date: Date): boolean {
    //treba posalti date, dal preko body ili preko param parametar
    //return this._http.get<boolean>(this._onCallShiftUri).catch(this.handleError);

    // delete this
    return true;
  }

  RemoveDoctorOnCallShift(doctorID: string, date: Date): boolean {
    //treba posalti date, dal preko body ili preko param parametar
    //return this._http.get<boolean>(this._onCallShiftUri).catch(this.handleError);

    // delete this
    return true;
  }

  GetAllOnCallShiftByDoctorId(doctorID: string): Observable<OnCallShift[]> {
    //treba posalti date, dal preko body ili preko param parametar
    //return this._http.get<OnCallShift[]>(this._onCallShiftUri).catch(this.handleError);

    // delete this
    
    var retVal = Observable.create((observer: { next: (arg0: OnCallShift) => void; complete: () => void; }) => {
      observer.next(new OnCallShift('', new Date(Date.now())));
      observer.next(new OnCallShift('', new Date(Date.now())));
      observer.next(new OnCallShift('', new Date(Date.now())));

      observer.complete();
    });
    return retVal;
    
  }

  private handleError(err: HttpErrorResponse) {
    console.log(err.message);
    return Observable.throw(err.message)
  }
}
