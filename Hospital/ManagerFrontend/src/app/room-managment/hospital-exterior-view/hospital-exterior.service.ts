import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { DrawableElement } from './drawableElement';
import { Observable } from 'rxjs/Observable';

@Injectable({
  providedIn: 'root'
})
export class HospitalExteriorService {

  private _exteriorGraphicUrl = 'http://localhost:65192/api/exterior';

  constructor(private _http: HttpClient) { }

  getExteriorGraphic(): Observable<DrawableElement[]> {
    return this._http.get<DrawableElement[]>(this._exteriorGraphicUrl).catch(this.handleError);
  }

  private handleError(err: HttpErrorResponse) {
    console.log(err.message);
    return Observable.throw(err.message)
  }

}
