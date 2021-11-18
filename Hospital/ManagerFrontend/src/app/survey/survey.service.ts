import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { SurveyStats } from "./surveyStats";

@Injectable({
    providedIn: 'root'
  })
  export class SurveyService {
    constructor(private _http: HttpClient) { }
  
    getSurveyStats(): Observable<SurveyStats[]> {
      return this._http.get<SurveyStats[]>('/api/survey/surveyStats');
    }
  }