import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ProfileService {
  
  currentUser: any;

  constructor(private _http: HttpClient) { }

  getProfileData(username: string): Observable<any> {
    return this._http.get<any>(`api/Profile/${username}`)
      .pipe(map(user => {
        this.currentUser = user;
        return user;
      }))
  }

  getVisits(username: string): Observable<any> {
    return this._http.get<any>(`api/Appointment/${username}`)
  }

  cancelVisit(id: number): Observable<any> {
    return this._http.put<any>(`/api/Appointment/${id}`, { observe: 'response' });
  }

  postFile(fileToUpload: File, username: string): Observable<boolean> {
    const formData: FormData = new FormData();
    formData.append("profileImage", fileToUpload, fileToUpload.name);
    return this._http.post<any>(`/api/profile/UploadImage/${username}`, formData);
  }

  getImage(username: string): Observable<any> {
    return this._http.get<any>(`api/Profile/GetImage/${username}`)
  }

  getReport(id: number): Observable<any> {
    return this._http.get<any>(`api/appointment/report/${id}`, { observe: 'response' })
  }

  getPreciption(id: number) {
    return this._http.get<any>(`api/appointment/prescription/${id}`, { observe: 'response' })
  }
  
}
