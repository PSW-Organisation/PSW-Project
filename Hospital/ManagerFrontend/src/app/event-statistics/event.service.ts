import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EventService {

  constructor(private _http: HttpClient) { }

  getAbortStepBreakdown(): Observable<any>{
    return this._http.get<any>('/api/AppointmentSchedulingEvent/abortStepBreakdown', {observe: 'response'});
  }

  getStepDurationBreakdown(): Observable<any>{
    return this._http.get<any>('/api/AppointmentSchedulingEvent/stepDurationBreakdown', {observe: 'response'});
  }

  getUnsuccessfullSchedulingPerMonth(): Observable<any>{
    return this._http.get<any>('/api/AppointmentSchedulingEvent/unsuccessfullSchedulingPerMonth', {observe: 'response'});
  }

  getSuccessfullSchedulingPerMonth(): Observable<any>{
    return this._http.get<any>('/api/AppointmentSchedulingEvent/successfullSchedulingPerMonth', {observe: 'response'});
  }

  getSchedulingPerTimeOfDay(): Observable<any>{
    return this._http.get<any>('/api/AppointmentSchedulingEvent/schedulingPerTimeOfDay', {observe: 'response'});
  }

  getUnsuccessfullSchedulingByAgeGroup(): Observable<any>{
    return this._http.get<any>('/api/AppointmentSchedulingEvent/unsuccessfullSchedulingByAgeGroup', {observe: 'response'});
  }

  getAverageStats(): Observable<any>{
    return this._http.get<any>('/api/AppointmentSchedulingEvent/averageStats', {observe: 'response'});
  }
}
