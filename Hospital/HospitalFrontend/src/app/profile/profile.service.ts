import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProfileService {

  constructor(private _http: HttpClient) { }

  getProfileData(username: string): Observable<any> {
    return this._http.get<any>(`api/Profile/${username}`)
  }

  getVisits(username: string): Observable<any> {
    return this._http.get<any>(`api/Appointment/${username}`)
  }

  cancelVisit(id: number): Observable<any> {
    return this._http.put<any>(`/api/Appointment/${id}`, {observe: 'response'});
  }
}
