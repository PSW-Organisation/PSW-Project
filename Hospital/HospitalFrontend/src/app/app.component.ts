import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from './welcome/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'HospitalFrontend';

  constructor(public router: Router, private authService: AuthService) {}

  ngOnInit() {
    this.authService.logout();
  }

}
