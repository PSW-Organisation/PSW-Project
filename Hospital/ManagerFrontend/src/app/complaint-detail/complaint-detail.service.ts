import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { IComplaint } from '../complaints-view/complaint';

@Injectable({
  providedIn: 'root'
})
export class ComplaintDetailService {

  constructor(private _http: HttpClient) { }

  getComplaint(id: number): Observable<IComplaint> {
    const headers = new HttpHeaders()
    .set('content-type', 'application/json')
    .set('Access-Control-Allow-Origin', '*');
    return this._http.get<IComplaint>('http://localhost:16928/api2/complaint/' + id, { 'headers': headers})
    .pipe(
      tap(data => console.log("Data complaint :", data))
    )
  }
}
