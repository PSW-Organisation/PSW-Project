import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { map } from 'rxjs/operators';
import { UserService } from './user.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private router: Router, private _http: HttpClient, private userService: UserService) { }

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
        if (res != null) {
          this._accessToken = res.token.token;
          localStorage.setItem("jwt", res.token.token);
          localStorage.setItem("currentUser", JSON.stringify(res.user));
        } else {
          alert("Password or username are invalid or your account is not activated!")
        }
      }))
  }

  logout() {
    this.userService.currentUser = null;
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
