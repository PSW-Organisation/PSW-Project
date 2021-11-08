import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { filter } from 'rxjs-compat/operator/filter';
import { tap } from 'rxjs/operators';
import { IComplaint } from '../complaints-view/complaint';
import { IResponseToComplaint } from './responseToComplaint';

@Injectable({
  providedIn: 'root'
})
export class ComplaintDetailService {

  constructor(private _http: HttpClient) { }

  data!: Observable<IResponseToComplaint[]>

  getComplaint(id: number): Observable<IComplaint> {
    const headers = new HttpHeaders()
    .set('content-type', 'application/json')
    .set('Access-Control-Allow-Origin', '*');
    return this._http.get<IComplaint>('http://localhost:16928/api2/complaint/' + id, { 'headers': headers})
    .pipe(
      tap(data => console.log("Data complaint :", data))
    )
  }

  getResponses(): Observable<IResponseToComplaint[]> {
    const headers = new HttpHeaders()
    .set('content-type', 'application/json')
    .set('Access-Control-Allow-Origin', '*');
    return this._http.get<IResponseToComplaint[]>('http://localhost:16928/api2/responses', { 'headers': headers})
    .pipe(
      tap(data => console.log("Data response :", data))
    )
  }

  deleteResponse(id : number){
    return this._http.delete('http://localhost:16928/api2/responses/'+id);
  }
}
