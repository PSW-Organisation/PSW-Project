import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { IHospital } from '../welcome/hospital';

@Injectable({
  providedIn: 'root'
})
export class HospitalService {

  data!: Observable<IHospital[]>
  constructor(private _http: HttpClient) { }

  getHospitals(): Observable<IHospital[]> {
    return this._http.get<IHospital[]>('http://localhost:29631/api3/hospital')
    .pipe(
      tap((data: any) => console.log("Data hospitals :", data))
    )}
}
