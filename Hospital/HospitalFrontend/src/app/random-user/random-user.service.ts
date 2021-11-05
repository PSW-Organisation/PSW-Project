import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RandomUserService {

  constructor(private _http: HttpClient) { }

  getRandomUser(): Observable<any>{
    return this._http.get('https://randomuser.me/api/?inc=login', { responseType: 'json' })
  }
}
