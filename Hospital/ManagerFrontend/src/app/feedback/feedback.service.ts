import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Feedback } from './feedback';

@Injectable({
  providedIn: 'root'
})
export class FeedbackService {
  constructor(private _http: HttpClient) { }

  getAllFeedbacks(): Observable<Feedback[]> {
    return this._http.get<Feedback[]>('/api/PatientFeedbacks');
  }

  publishFeedback(feedback: Feedback, id: number): Observable<any> {
    return this._http.put<any>(`/api/PatientFeedbacks/${id}`, feedback, {observe: 'response'});
  }

}
