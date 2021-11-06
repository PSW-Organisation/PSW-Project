import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class EditPharmacyService {

  thisUrl: string = "http://localhost:16928/api2/pharmacy";

  constructor(private _http: HttpClient) { }

  editPharmacy(pharmacy : any){
    return this._http.put(this.thisUrl +'/'+ pharmacy.pharmacyId, pharmacy);
  }
}
