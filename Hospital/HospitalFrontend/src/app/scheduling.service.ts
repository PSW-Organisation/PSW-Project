import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Visit } from '../app/recommended-appointment-scheduling/visits';

@Injectable({
  providedIn: 'root'
})
export class SchedulingService {

  constructor(private _http: HttpClient) { }

  getDoctors(): Observable<any> {
    return this._http.get<any>('api/Appointment/doctors')
  }

  getGeneratedFreeVisits(doctorId: string, priority: boolean, isVisitScheduleByPriority: boolean,
    beginning: string, ending: string): Observable<any> {
    const params = new HttpParams({
      fromObject: {
        doctorId: doctorId,
        priority: priority,
        isVisitScheduleByPriority: isVisitScheduleByPriority,
        beginning: beginning,
        ending: ending
      }
    });
    return this._http.get<any>('api/Appointment/generatedFreeVisits', {params: params})
  }

  createVisit(visit : Visit): Observable<any>{
    return this._http.post<any>('/api/Appointment', visit, {observe: 'response'});
  }

}
