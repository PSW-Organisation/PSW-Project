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
  }