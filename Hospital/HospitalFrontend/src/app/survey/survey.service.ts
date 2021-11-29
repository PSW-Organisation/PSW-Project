import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Survey } from "./survey";

@Injectable({
    providedIn: 'root'
  })
  export class SurveyService {
    constructor(private _http: HttpClient) { }
  
    createSurvey(survey : Survey): Observable<any>{
        return this._http.post<any>('/api/survey', survey, {observe: 'response'});
      }

    getVisitById(id: number): Observable<any>{
       return this._http.get<any>(`/api/appointment/visit/${id}`, {observe: 'response'});
    }

    reviewVisit(id: number): Observable<any>{
      return this._http.put<any>(`/api/appointment/visit/${id}`, {observe: 'response'});
   }

  }