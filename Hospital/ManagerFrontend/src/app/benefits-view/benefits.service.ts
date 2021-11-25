import { Injectable } from '@angular/core';
import { Benefits } from './benefits';

import { HttpClient, HttpErrorResponse, HttpHeaders, HttpParams } from '@angular/common/http'
import { Observable } from "rxjs";

import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/catch';
import { tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class BenefitsService {


  data!: Observable<Benefits[]>;
  thisUrl: string = "http://localhost:16928/api2/medicinebenefit";
  constructor(private _http: HttpClient) { }

  getBenefits() : Observable<Benefits[]>{
    const headers = new HttpHeaders()
    .set('content-type', 'application/json')
    .set('Access-Controll-Allow-Origin', '*');
    return this._http.get<Benefits[]>('http://localhost:16928/api2/medicinebenefit', {'headers': headers})
    .pipe(
      tap(data=>console.log("Data benefit: ", data))
    )
  }
  unpublishBenefit(benefit: any) {
    benefit.Published = false;
    return this._http.put(this.thisUrl + '/' + benefit.medicineBenefitId, benefit);
  }
}
