import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { IComplaint } from './complaint';


@Injectable({
    providedIn: 'root'
  })
  export class ComplaintsService {
  
    data!: Observable<IComplaint[]>
  
    constructor(private _http: HttpClient) { }
  
    //moze da se odradi get obican, jer u ovom pharmacyju ce biti u bazi samo ono sto je pristiglo njoj 
    getComplaints() : Observable<IComplaint[]> {
      return this._http.get<IComplaint[]>('http://localhost:29631/api3/complaint')
      .pipe(
        tap(data => console.log("Data complaint :", data))
      )
    }

    //sad stoji samo primera radi na frontu forma, nije bitno za sad
    sendResponse(response: any){
      return this._http.post('http://localhost:29631/api3/responses', response )
    }

    deleteComplaint(id:any) {
      return this._http.delete('http://localhost:29631/api3/complaint/delete/'+ id)
   
    }


}