import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { IPharmacy } from '../pharmacies-view/pharmacy';
import { IComplaint } from './complaint';

@Injectable({
  providedIn: 'root'
})
export class ComplaintsService {

  data!: Observable<IComplaint[]>

  constructor(private _http: HttpClient) { }

  getComplaints() : Observable<IComplaint[]> {
    const headers = new HttpHeaders()
    .set('content-type', 'application/json')
    .set('Access-Control-Allow-Origin', '*');
    return this._http.get<IComplaint[]>('http://localhost:16928/api2/complaint', { 'headers': headers})
    .pipe(
      tap(data => console.log("Data complaint :", data))
    )
  }

  getPharmacies(): Observable<IPharmacy[]>{
    const headers= new HttpHeaders()
    .set('content-type', 'application/json')
    .set('Access-Control-Allow-Origin', '*');
    return this._http.get<IPharmacy[]>('http://localhost:16928/api2/pharmacy',{ 'headers': headers} )
    .pipe(
      tap(data => console.log("Data complaint :", data))
    )
  }

  addComplaint(newComplaint : any){
    return this._http.post('http://localhost:16928/api2/complaint', newComplaint);
}

sendComplaintToPharmacy(newComplaint : any, key:string){
  var newComplaintForPharmacy = { complaintId: newComplaint.complaintId, date: newComplaint.date, title:newComplaint.title, content:newComplaint.content};
  return this._http.post('http://localhost:29631/api3/complaint/' + key, newComplaintForPharmacy);
}

}
