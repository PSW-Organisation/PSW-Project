import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { IPharmacy } from '../pharmacies-view/pharmacy';

@Injectable({
  providedIn: 'root'
})
export class MedicineConsumptionService {

  constructor(private _http: HttpClient) { }

  getPharmacies(): Observable<IPharmacy[]>{
    const headers= new HttpHeaders()
    .set('content-type', 'application/json')
    .set('Access-Control-Allow-Origin', '*');
    return this._http.get<IPharmacy[]>('http://localhost:16928/api2/pharmacy',{ 'headers': headers} )
    .pipe(
      tap(data => console.log("Data complaint :", data))
    )
  }

  postFile(fileToUpload: File, pharmacyURL: string) {
    const endpoint = pharmacyURL + '/report';
    const formData: FormData = new FormData();
    formData.append('fileKey', fileToUpload, fileToUpload.name);
    return this._http
      .post(endpoint, formData);
}
}
