import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Patient } from "./patient";

@Injectable({
  providedIn: 'root'
})
export class PatientService {

  constructor(private _http: HttpClient) { }

  getMaliciousPatients(): Observable<Patient[]> {
    return this._http.get<Patient[]>('/api/patients');
  }
  
  blockPatient(username: string): Observable<any>{
    return this._http.put<any>(`/api/patients/${username}`, {observe: 'response'})
  }

}
