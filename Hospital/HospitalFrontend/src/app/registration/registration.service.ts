import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Patient} from './patient';

@Injectable({
  providedIn: 'root'
})
export class RegistrationService {

  constructor(private _http: HttpClient) { }

  getCitiesForCountry(country: string): Observable<any>{
    return this._http.post<any>('https://countriesnow.space/api/v0.1/countries/cities', {"country" : country});
  }

  getAllergens(): Observable<any>{
    return this._http.get<any>('api/Registration')
  }

  getDoctors(): Observable<any>{
    return this._http.get<any>('api/Registration/Doctors')
  }

  register(patient: Patient): Observable<any>{
    return this._http.post<any>('/api/Registration', patient, {observe: 'response'});
  } 
}
