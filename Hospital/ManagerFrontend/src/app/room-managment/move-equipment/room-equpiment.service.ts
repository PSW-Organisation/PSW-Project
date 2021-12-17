import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { IEquipment, IEquipmentQuantity, IFreeTerms } from './room-equipment';
import { IParamsOfRelocationEquipment } from './room-equipment';

@Injectable({
  providedIn: 'root',
})
export class RoomEqupimentService {
  private _equipmentUrl = 'http://localhost:42789/api/roomEquipments';
  private _termsOfRelocationUrl = 'http://localhost:42789/api/termsofrelocation';

  constructor(private _http: HttpClient) {}

  getRoomEquipmentQuantity(): Observable<IEquipmentQuantity[]> {
    return this._http.get<IEquipmentQuantity[]>(this._equipmentUrl+'/quantity').pipe(
      tap((data) => console.log('All: ', JSON.stringify(data))),
      catchError(this.handleError)
    );
  }

  getRoomEquipment(name: string): Observable<IEquipment[]> {
    return this._http.get<IEquipment[]>(this._equipmentUrl+`/equipment/${name}`).pipe(
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
  
  getAllRoomEquipmentInRoom(roomId: number): Observable<IEquipment[]> {
    return this._http.get<IEquipment[]>(this._equipmentUrl+`/${roomId}`).pipe(
      tap((data) => console.log('All Room equipment: ', JSON.stringify(data))),
      catchError(this.handleError)
    );
  }

  getAllPosibleRelocationTerms(paramsOfRelocationEquipment: IParamsOfRelocationEquipment): Observable<IFreeTerms[]> {
    return this._http.post<IFreeTerms[]>(this._termsOfRelocationUrl, paramsOfRelocationEquipment).
      pipe(tap((data) => console.log('All: ', JSON.stringify(data))), catchError(this.handleError));
  }

  createTermOfRelocation(paramsOfRelocationEquipment: IParamsOfRelocationEquipment): Observable<IParamsOfRelocationEquipment>{
    return this._http.put<IParamsOfRelocationEquipment>(this._termsOfRelocationUrl, paramsOfRelocationEquipment).
      pipe(tap((data) => console.log('All: ', JSON.stringify(data))), catchError(this.handleError));
  }

  private handleError(err: HttpErrorResponse) {
    console.log(err.message);
    return throwError(err.message);
  }

  cancelTermOfRelocation(termId: number): Observable<boolean> {
  return this._http.put<boolean>(this._termsOfRelocationUrl + `/cancel/${termId}`, {}).
      pipe(tap((data) => console.log('All: ', JSON.stringify(data))), catchError(this.handleError));
  }
  
}
