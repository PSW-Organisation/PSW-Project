import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { ITender } from '../tenders/tender';

@Injectable({
  providedIn: 'root'
})
export class TenderDetailService {

  constructor(private _http: HttpClient) { }

  getTender(id: number): Observable<ITender> {
    return this._http.get<ITender>('http://localhost:16928/api2/tender/' + id)
    .pipe(
      tap(data => console.log("Data: ", data))
    )
  }

  acceptOffer(id: number) {
    return this._http.get<ITender>('http://localhost:16928/api2/tenderresponse/accept/' + id)
    .pipe(
      tap(data => console.log("Data: ", data))
    )
  }


  sendNotificationToPharmacy(message: any){
    return this._http.get('http://localhost:29631/api3/notifications/'+ message).subscribe()
  }
}
