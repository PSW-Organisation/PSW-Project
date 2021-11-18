import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RegistrationService {

  constructor(private _http: HttpClient) { }

  getCitiesForCountry(country: string): Observable<any>{
    return this._http.post<any>('https://countriesnow.space/api/v0.1/countries/cities', {"country" : country});
  }
/*
  getAllFeedbacks(): Observable<Feedback[]> {
    return this._http.get<Feedback[]>('/api/PatientFeedbacks')
  }
*/
}
