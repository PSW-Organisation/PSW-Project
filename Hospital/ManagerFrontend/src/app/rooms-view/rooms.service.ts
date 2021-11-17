import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { IFloor } from './building-floors/floor';
import { RoomType } from './room';

@Injectable({
  providedIn: 'root',
})
export class RoomService {
  private _roomsUrl = 'http://localhost:42789/api/rooms/floors';

  constructor(private _http: HttpClient) {}

  getRooms(): Observable<IFloor[]> {
    return this._http.get<IFloor[]>(this._roomsUrl).pipe(
      tap((data) => console.log('All: ', JSON.stringify(data))),
      catchError(this.handleError)
    );
  }

  private handleError(err: HttpErrorResponse) {
    console.log(err.message);
    return throwError(err.message);
  }

  getRoomColor(type: RoomType): string {
    let color = '#000000';
    if (type === RoomType.operation) {
      color = '#FFE5CC';
    } else if (type === RoomType.counter) {
      color = '#999FFF';
    } else if (type === RoomType.examination) {
      color = '#FBD9FC';
    } else if (type === RoomType.restroom) {
      color = '#CCFFFF';
    } else if (type === RoomType.waitingRoom) {
      color = '#E5FFCC';
    } else if (type === RoomType.restingRoom) {
      color = '#C0C0C0';
    }
    return color;
  }

  getRoomTypeText(type: RoomType): string {
    let text = '';
    if (type === RoomType.examination) {
      text = 'Examination';
    } else if (type === RoomType.operation) {
      text = 'Operation hall';
    } else if (type === RoomType.restingRoom) {
      text = 'Resting room';
    } else if (type === RoomType.restroom) {
      text = 'Restroom';
    } else if (type === RoomType.counter) {
      text = 'Counter';
    } else if (type === RoomType.waitingRoom) {
      text = 'Waiting room';
    }
    return text;
  }

  getAcronym(text: string): string {
    let matches = text.match(/\b(\w)/g);
    let acronym = '';
    if (matches !== null) {
      acronym = matches.join('');
    }
    return acronym.toUpperCase();
  }
}
