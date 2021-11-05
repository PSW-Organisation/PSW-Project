import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs';
import { Feedback } from './feedback';

@Injectable()
export class FeedbackService {
  constructor(private _http: HttpClient) { }

  createFeedback(feedback : Feedback): Observable<any>{
    return this._http.post<any>('/api/PatientFeedbacks', feedback, {observe: 'response'});
  }

  getAllFeedbacks(): Observable<Feedback[]> {
    return this._http.get<Feedback[]>('/api/PatientFeedbacks')
  }
}