import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
})

export class RegistrationService {
   apiKey: string=""

    constructor( private _http: HttpClient) {}

    register(newHospital: any) {
        return this._http.post('http://localhost:29631/api3/hospital', newHospital)
        .pipe(
            tap(data =>{console.log("Api key for your hospital:", data)  })
          )
    }

 
}
