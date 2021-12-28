import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../welcome/auth.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  username: string = 'imbiamba'

  constructor(public router: Router, private authService: AuthService) { }

  ngOnInit(): void {
  }

  hyperLink(path: string) {
    this.router.navigate([path])
    console.log(path);
  }

  logOut(){
    this.authService.logout();
  }
}
