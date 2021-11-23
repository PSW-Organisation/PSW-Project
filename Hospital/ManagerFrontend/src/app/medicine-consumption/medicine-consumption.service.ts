import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { mergeMap, tap } from 'rxjs/operators';
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

  /*requestMedicineReport(pharmacyUrl: string, medicineName: string) {
    var mediaType = 'application/pdf';
    this._http.get(pharmacyUrl + '/pdfcreator/' + medicineName, { responseType: 'blob' }).subscribe(
        (response) => {
            this._http.get('http://localhost:16928/api2/report/' + medicineName )
            var blob = new Blob([response], { type: mediaType });
            const url= window.URL.createObjectURL(blob);
            window.open(url);
        },
        e => { throwError(e); }
    );
  }*/

  getMedicineDetails(pharmacyUrl: string, medicineName: string){
    this._http.get(pharmacyUrl + '/pdfcreator/' + medicineName, { responseType: 'text' }).pipe(
      mergeMap(response => this._http.get('http://localhost:16928/api2/report/' + response ))
    ).subscribe();
  }
  
  sendConsumptionReport(pharmacyUrl: string, timeRange: any){
    this._http.post('http://localhost:16928/api2/pdfcreator', timeRange, { responseType: 'text' }).pipe(
      mergeMap(response => this._http.get(pharmacyUrl + '/report/' + response ))
    ).subscribe();
  }

}
