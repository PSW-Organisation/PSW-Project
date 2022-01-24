import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { ITender } from './tender';
import { ITenderStatisticBarChart } from './TenderStatisticBarChart';
import { ITenderStatisticTwoBarChart } from './TenderStatisticTwoBarChart';

@Injectable({
  providedIn: 'root'
})
export class TendersService {

  constructor(private _http: HttpClient) { }

  getTenders(): Observable<ITender[]> {
    return this._http.get<ITender[]>('http://localhost:16928/api2/tender')
    .pipe(
      tap(data => console.log("Data: ", data))
    )
  }

  saveTender(tender: ITender){
    return this._http.post('http://localhost:16928/api2/tender', tender);
  }

  closeTender(id: number) {
    return this._http.get('http://localhost:16928/api2/tender/close/' + id)
    .pipe(
      tap(data => console.log("Data: ", data))
    )
  }

    //-----------------------------------------------------STATISTIKA----------------------------------------

    statisticTenderWinnerOffers(start: Date, end: Date): Observable<ITenderStatisticBarChart>{
      return this._http.post<ITenderStatisticBarChart>('http://localhost:16928/api2/tenderstatistics/statisticTenderWinnerOffers', {"dateStart": start, "dateEnd": end});
    }

    statisticTenderPharmacyProfits(start: Date, end: Date): Observable<ITenderStatisticBarChart>{
      return this._http.post<ITenderStatisticBarChart>('http://localhost:16928/api2/tenderstatistics/statisticTenderPharmacyProfits', {"dateStart": start, "dateEnd": end});
    }

    statisticTenderWinningDefeat(start: Date, end: Date): Observable<ITenderStatisticTwoBarChart>{
      return this._http.post<ITenderStatisticTwoBarChart>('http://localhost:16928/api2/tenderstatistics/statisticTenderWinningDefeat', {"dateStart": start, "dateEnd": end});
    }

    statisticTenderParticipate(start: Date, end: Date): Observable<ITenderStatisticTwoBarChart>{
      return this._http.post<ITenderStatisticTwoBarChart>('http://localhost:16928/api2/tenderstatistics/statisticTenderParticipate', {"dateStart": start, "dateEnd": end});
    }
}
