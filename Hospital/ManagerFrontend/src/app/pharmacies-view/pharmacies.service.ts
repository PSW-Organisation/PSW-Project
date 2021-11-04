import { Injectable } from "@angular/core";
import { IPharmacy } from "./pharmacy";

import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http'
import { Observable } from "rxjs";

import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/catch';
import { tap } from 'rxjs/operators';

@Injectable()
export class PharmaciesService {
    data!: Observable<IPharmacy[]>

    constructor(private _http: HttpClient) {}

    getPharmacies() : Observable<IPharmacy[]> {
        const headers= new HttpHeaders()
        .set('content-type', 'application/json')
        .set('Access-Control-Allow-Origin', '*');
        return this._http.get<IPharmacy[]>('http://localhost:16928/api2/pharmacy', { 'headers': headers }) 
        .pipe(
            tap(data => console.log("Data pharmacy :", data)
            ))          
    }

    addPharmacy(newPharmacy : any){
        return this._http.post('http://localhost:16928/api2/pharmacy', newPharmacy);
    }
}