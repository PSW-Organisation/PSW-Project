import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { ITender } from './tender';

@Injectable({
  providedIn: 'root'
})
export class TendersService {

  constructor(private _http: HttpClient) { }

  getTenders(): Observable<ITender[]> {
    return this._http.get<ITender[]>('http://localhost:16928/api2/tender')
    .pipe(
      tap(data => console.log("Data: ", data))
    )
  }

  saveTender(tender: ITender){
    return this._http.post('http://localhost:16928/api2/tender', tender);
  }

  closeTender(id: number) {
    return this._http.get('http://localhost:16928/api2/tender/close/' + id)
    .pipe(
      tap(data => console.log("Data: ", data))
    )
  }
}
