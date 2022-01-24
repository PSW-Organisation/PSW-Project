import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import AppointmentSchedulingEvent from './appointment-scheduling-event';

@Injectable({
  providedIn: 'root'
})
export class EventService {

  constructor(private _http: HttpClient) { }

  createEvent(event : AppointmentSchedulingEvent): Observable<any>{
    return this._http.post<any>('/api/AppointmentSchedulingEvent', event, {observe: 'response'});
  }

  updateEventDuration(durationDto: any): Observable<any>{
    return this._http.put<any>('/api/AppointmentSchedulingEvent', durationDto, {observe: 'response'});
  }
}
