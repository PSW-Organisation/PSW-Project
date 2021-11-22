import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { IEquipment, IEquipmentQuantity } from './room-equipment';

@Injectable({
  providedIn: 'root',
})
export class RoomEqupimentService {
  private _equipmentUrl = 'http://localhost:42789/api/roomEquipments';

  constructor(private _http: HttpClient) {}

  getRoomEquipmentQuantity(): Observable<IEquipmentQuantity[]> {
    return this._http.get<IEquipmentQuantity[]>(this._equipmentUrl+'/quantity').pipe(
      tap((data) => console.log('All: ', JSON.stringify(data))),
      catchError(this.handleError)
    );
  }

  getRoomEquipment(name: string): Observable<IEquipment[]> {
    return this._http.get<IEquipment[]>(this._equipmentUrl+`/${name}`).pipe(
      tap((data) => console.log('All equipment: ', JSON.stringify(data))),
      catchError(this.handleError)
    );
  }

  getAllRoomEquipment(): Observable<IEquipment[]> {
    return this._http.get<IEquipment[]>(this._equipmentUrl).pipe(
      tap((data) => console.log('All equipment: ', JSON.stringify(data))),
      catchError(this.handleError)
    );
  }

  private handleError(err: HttpErrorResponse) {
    console.log(err.message);
    return throwError(err.message);
  }
}
