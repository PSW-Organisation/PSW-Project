import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { ITender } from './tender';
import { ITenderResponse } from './tenderResponse';
//import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class TendersService {

  constructor(private _http: HttpClient, private toastr: ToastrService) { }

  closeTender(tender: ITender){
    console.log('cao iz zatvaranja')
    return this._http.get('http://localhost:29631/api3/tender/close/' + tender.id)
  }

  sendOffer(Offer: ITenderResponse){
    console.log('cao')
    return this._http.post('http://localhost:29631/api3/tenderresponse', Offer);
  }
  getTenders(): Observable<ITender[]> {
    return this._http.get<ITender[]>('http://localhost:29631/api3/tender')
    .pipe(
      tap(data => console.log("Data: ", data))
    )
  }  
  
  sendNotificationToHospital(message: any){
    return this._http.get('http://localhost:16928/api2/notifications/'+ message).subscribe(),
    this.showToastrSuccess("You sent offer!" , "Success");  

  }

  showToastrSuccess(message: string, title: string){
    this.toastr.success(message, title,
     { timeOut: 3000, 
      progressBar: true,
       progressAnimation: 'increasing'})
  }
}
