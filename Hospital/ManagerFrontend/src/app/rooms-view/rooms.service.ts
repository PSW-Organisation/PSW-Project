import { Injectable } from "@angular/core";
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { IFloor } from "./building-floors/floor";

@Injectable({
    providedIn: 'root'
  })
export class RoomService{
    private _roomsUrl = 'assets/rooms/rooms.json'
    constructor(private _http: HttpClient){}

    getRooms(): Observable<IFloor[]>{
        return this._http.get<IFloor[]>(this._roomsUrl)
        .pipe(
            tap(data => console.log('All: ', JSON.stringify(data))),
            catchError(this.handleError)
          );
    }

    private handleError(err: HttpErrorResponse){
        console.log(err.message);
        return throwError(err.message);
    }

}