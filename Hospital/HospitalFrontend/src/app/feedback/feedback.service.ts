import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs';
import { Feedback } from './feedback';

@Injectable()
export class FeedbackService {
  private _url = "http://localhost:42789";
  constructor(private _http: HttpClient) { }

  createFeedback(feedback : Feedback): Observable<any>{
    return this._http.post<number>(`${this._url}/api/PatientFeedbacks`, feedback);
  }

  getAllFeedbacks(): Observable<Feedback[]> {
    return this._http.get<Feedback[]>(`${this._url}/api/PatientFeedbacks`)
  }
}