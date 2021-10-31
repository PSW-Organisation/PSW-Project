import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs';

@Injectable()
export class ConfigService {
  private _url = "http://localhost:42789";
  constructor(private _http: HttpClient) { }

  getPecurka(): Observable<any>{
    return this._http.get(`${this._url}/weatherforecast`, { responseType: 'text' });
  }
}