import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { IMedicine } from './medicine';
import { tap } from 'rxjs/operators';
import { IHospital } from './hospital';

@Injectable({
  providedIn: 'root'
})
export class MedicineReportService {
  data!: Observable<IMedicine[]>;

  constructor(private _http: HttpClient) { }

  getMedicine() : Observable<IMedicine[]> {
    const headers= new HttpHeaders()
    .set('content-type', 'application/json')
    .set('Access-Control-Allow-Origin', '*');
    return this._http.get<IMedicine[]>('http://localhost:29631/api3/medicine', { 'headers': headers }) 
    .pipe(
    tap(data => console.log("Data medicine :", data)
    ))          
  }

  public getMedicineReport(medicineId: number): any {
    var mediaType = 'application/pdf';
    this._http.get('http://localhost:29631/api3/pdfcreator/' + medicineId, { responseType: 'blob' }).subscribe(
        (response) => {
            var blob = new Blob([response], { type: mediaType });
            const url= window.URL.createObjectURL(blob);
            window.open(url);
        },
        e => { throwError(e); }
    );
  }

  getHospitals() : Observable<IHospital[]> {
    const headers= new HttpHeaders()
    .set('content-type', 'application/json')
    .set('Access-Control-Allow-Origin', '*');
    return this._http.get<IHospital[]>('http://localhost:29631/api3/hospital', { 'headers': headers }) 
    .pipe(
    tap(data => console.log("Data hospital :", data)
    ))          
  }

  postFile(fileToUpload: File, hospitalUrl: string) {
    const endpoint = hospitalUrl + '/report';
    const formData: FormData = new FormData();
    formData.append('fileKey', fileToUpload, fileToUpload.name);
    return this._http
      .post(endpoint, formData);
}
}
