import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { ITender } from './tender';
import { ITenderResponse } from './tenderResponse';

@Injectable({
  providedIn: 'root'
})
export class TendersService {

  constructor(private _http: HttpClient) { }

  sendOffer(Offer: ITenderResponse){
    console.log('cao')
    return this._http.post('http://localhost:29631/api3/tenderresponse', Offer);
  }
  getTenders(): Observable<ITender[]> {
    return this._http.get<ITender[]>('http://localhost:29631/api3/tender')
    .pipe(
      tap(data => console.log("Data: ", data))
    )

  }}
