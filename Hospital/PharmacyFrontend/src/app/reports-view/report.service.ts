import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ReportService {

  constructor(private _http: HttpClient) { }

  getReportNames(directory: string) : Observable<string[]> {
    return this._http.get<string[]>('http://localhost:29631/api3/report/names/' + directory)
    .pipe(
      tap(data => console.log("Report names :", data))
    )
  }

  getReport(directory: string, reportName: string): any {
    var mediaType = 'application/pdf';
    this._http.get('http://localhost:29631/api3/report/pdf/' + directory + '/' + reportName, { responseType: 'blob' }).subscribe(
        (response) => {
            var blob = new Blob([response], { type: mediaType });
            const url= window.URL.createObjectURL(blob);
            window.open(url);
        },
        e => { throwError(e); }
    );
  }
}
