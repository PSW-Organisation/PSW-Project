import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IPharmacy } from '../pharmacies-view/pharmacy';

@Injectable({
  providedIn: 'root'
})
export class PharmacyProfileService {
  thisUrl: string = "http://localhost:16928/api2/pharmacy";
  constructor(private _http: HttpClient) { }

  editPharmacy(pharmacy: any){
    return this._http.put<IPharmacy>( this.thisUrl +'/'+ pharmacy.pharmacyId, pharmacy)
  }
}
