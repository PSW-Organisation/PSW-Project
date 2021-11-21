import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
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

  public getMedicineReport(timeRange: any): any {
    var mediaType = 'application/pdf';
    this._http.get('http://localhost:16928/api2/pdfcreator/' + timeRange.startDate + '/' + timeRange.endDate, { responseType: 'blob' }).subscribe(
        (response) => {
            var blob = new Blob([response], { type: mediaType });
            const url= window.URL.createObjectURL(blob);
            window.open(url);
        },
        e => { throwError(e); }
    );
  }

}
