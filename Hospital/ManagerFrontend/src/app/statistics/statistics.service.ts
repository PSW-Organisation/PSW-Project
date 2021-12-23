import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import {IStatWinnDefeat}  from './model/IStatWinnDefeat';
import { IStatBarChart } from './model/IStatBarChart';

@Injectable({
  providedIn: 'root'
})
export class StatisticsService {

  constructor(private _http: HttpClient) { }

  getStatWinnDefeat(apiKey: string){
    return this._http.get<IStatWinnDefeat>('http://localhost:16928/api2/tender/statisticsPharmacyWinningsDefeat/' + apiKey)
  }

  getStatParticipate(apiKey: string){
    return this._http.get<IStatWinnDefeat>('http://localhost:16928/api2/tender/statisticsPharmacyParticipate/' + apiKey)
  }

  getStatWinnerOffers(apiKey: string){
    return this._http.get<IStatBarChart>('http://localhost:16928/api2/tender/statisticPharmacyWinnerOffers/' + apiKey)
  }

  getStatActiveTenderOffers(apiKey: string){
    return this._http.get<IStatBarChart>('http://localhost:16928/api2/tender/statisticPharmacyAcitiveTenderOffers/' + apiKey)
  }
}
