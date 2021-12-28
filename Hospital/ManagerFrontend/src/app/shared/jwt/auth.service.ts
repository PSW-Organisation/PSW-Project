import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private router: Router, private _http: HttpClient, private toastr: ToastrService) { }

  private _accessToken = null;

  login(username: string, password: string) {
    const loginHeaders = new HttpHeaders({
      'Accept': 'application/json',
      'Content-Type': 'application/json'
    });
    const body = {
      'username': username,
      'password': password
    };

    return this._http.post('api/login/authenticate', body, { 'headers': loginHeaders })
      .pipe(map((res: any) => {
        if (res) {
          this._accessToken = res.token.token;
          localStorage.setItem("jwt", res.token.token);
          localStorage.setItem("currentUser", JSON.stringify(res.user));
          this.router.navigate(['home']);
      
      }}), catchError((err, caught) => {
        this.toastr.error('Wrong credentials')
        return of(void(0))
      }))
  }

  logout() {
    this._accessToken = null;
    localStorage.removeItem("jwt");
    localStorage.removeItem("currentUser");
    this.router.navigate(['/']);
  }

  tokenIsPresent() {
    return localStorage.getItem("jwt") != null;
  }

  getToken() {
    return localStorage.getItem("jwt");
  }


}
