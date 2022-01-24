import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IPharmacy } from '../pharmacies-view/pharmacy';
import { IStatBarChart } from '../statistics/model/IStatBarChart';
import { IStatWinnDefeat } from '../statistics/model/IStatWinnDefeat';


@Injectable({
  providedIn: 'root'
})
export class PharmacyProfileService {
  thisUrl: string = "http://localhost:16928/api2/pharmacy";
  constructor(private _http: HttpClient) { }

  editPharmacy(pharmacy: any){
    return this._http.put<IPharmacy>( this.thisUrl +'/'+ pharmacy.pharmacyId, pharmacy)
  }

  getStatWinnDefeat(apiKey: string){
    return this._http.get<IStatWinnDefeat>('http://localhost:16928/api2/tenderstatistics/statisticsPharmacyWinningsDefeat/' + apiKey)
  }

  getStatParticipate(apiKey: string){
    return this._http.get<IStatWinnDefeat>('http://localhost:16928/api2/tenderstatistics/statisticsPharmacyParticipate/' + apiKey)
  }

  getStatWinnerOffers(apiKey: string){
    return this._http.get<IStatBarChart>('http://localhost:16928/api2/tenderstatistics/statisticPharmacyWinnerOffers/' + apiKey)
  }

  getStatActiveTenderOffers(apiKey: string){
    return this._http.get<IStatBarChart>('http://localhost:16928/api2/tenderstatistics/statisticPharmacyAcitiveTenderOffers/' + apiKey)
  }

}
