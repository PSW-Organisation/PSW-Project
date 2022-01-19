import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { ToastrService } from 'ngx-toastr';
import { Observable, throwError } from 'rxjs';
import { catchError, mergeMap, switchMap, tap } from 'rxjs/operators';
import { IPharmacy } from '../pharmacies-view/pharmacy';

@Injectable({
  providedIn: 'root'
})
export class MedicineConsumptionService {

  constructor(private _http: HttpClient,private toastr: ToastrService) { }

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
  return this._http.get(pharmacyUrl + '/pdfcreator/' + medicineName, { responseType: 'text' } ).pipe(
    mergeMap(response =>  this._http.get('http://localhost:16928/api2/report/' + response ))
    
    ).subscribe(
   res =>{  
     this.sendNotification("specification", medicineName)
     this.sendNotificationForMedicineReport2( "New medicine specification is created for " + medicineName + ".Check reports.");
    },
    (error:HttpErrorResponse )=>{
      this.sendNotification("failed_specification", medicineName)
     this.sendNotificationForMedicineReport2("This pharmacy doesn't have that medicine. Chose another one, or try again later!")} 
    );
  }
  
  sendConsumptionReport(pharmacyUrl: string, timeRange: any){
    this._http.post('http://localhost:16928/api2/pdfcreator', timeRange, { responseType: 'text' }).pipe(
      mergeMap(response => this._http.get(pharmacyUrl + '/report/' + response ))
    ).subscribe(
      (data) =>{
         this.sendNotification("report", "Flos")
         this.sendNotificationForMedicineReport2( "New consumption report is created for Flos pharmacy! Time range is " + timeRange)
         this.sendNotificationForConsumptionReportToPharmacy("New consumption report is created from LeanOn hospital! Time range is " + timeRange + " Check your reports.");},
      (error: HttpErrorResponse )=>{this.sendNotification("failed_report", "")
   } 
    );
  }

sendNotification(type: string, name: string) {
  if(type === "specification") { 
    this.showToastrSuccess("New medicine specification is created for " + name , "Success")  
  } 
   if (type ==="report"){   
    this.showToastrSuccess("New consumption report is created for " + name, "Success")
  }
  if(type === "failed_specification"){
    this.showToastrError("Failed to create. This medication doesn't exist", "Failed");
  }
  if(type === "failed_report") {
    this.showToastrError("This report could not be created. Try again later", "Failed");
  }
}


showToastrSuccess(message: string, title: string){
  this.toastr.success(message, title,
   { timeOut: 3000, 
    progressBar: true,
     progressAnimation: 'increasing'})
}
showToastrError(message: string, title: string){
  this.toastr.error(message, title,
   { timeOut: 3000, 
    progressBar: true,
     progressAnimation: 'increasing'})
}


sendNotificationForMedicineReport(notification: any){
  this._http.post('http://localhost:16928/api2/notifications' ,notification ).subscribe()
}
sendNotificationForMedicineReport2(content: any){
  this._http.get('http://localhost:16928/api2/notifications/' + content ).subscribe()
}

sendNotificationForConsumptionReportToPharmacy(content: any){
  this._http.get('http://localhost:29631/api3/notifications/' + content ).subscribe()
}

}
