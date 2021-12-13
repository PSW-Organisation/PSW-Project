import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { INotification } from './notification';

@Injectable({
  providedIn: 'root'
})
export class NotificationsService {

  constructor(private _http: HttpClient) { }


  getNotifications(): Observable<INotification[]>{
    
    return this._http.get<INotification[]>('http://localhost:16928/api2/notifications' )
    .pipe(
      tap(data => console.log("Data complaint :", data))
    )
  }

  changeToSeen(note: any){
    return this._http.put('http://localhost:16928/api2/notifications', note)
  }

 
  deleteNotification(notificationId: any){
    return this._http.delete('http://localhost:16928/api2/notifications/' + notificationId)
  }
  
}