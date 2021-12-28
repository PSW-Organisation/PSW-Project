import { Component, OnInit } from '@angular/core';
import { AuthService } from '../shared/jwt/auth.service';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent implements OnInit {

  constructor(private authService: AuthService) { }

  ngOnInit(): void {
  }

  logOut(){
    this.authService.logout()
  }

}
