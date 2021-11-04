import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs';
import { Feedback } from '../feedback/feedback';

@Injectable()
export class ConfigService {
  private _url = "http://localhost:42789";
  constructor(private _http: HttpClient) { }

  getPecurka(): Observable<any>{
    return this._http.get(`${this._url}/weatherforecast`, { responseType: 'text' });
  }

  createFeedback(feedback : Feedback): Observable<any>{
    return this._http.post<number>(`${this._url}/api/PatientFeedbacks`, feedback);
  }

}