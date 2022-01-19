import { Component, OnInit } from '@angular/core';
import { NotificationsService } from '../notifications/notifications.service';
import { AuthService } from '../shared/jwt/auth.service';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent implements OnInit {
  numberOfUnseen: any;

  constructor(private authService: AuthService,private notificationsService: NotificationsService) { }

  ngOnInit(): void {
    
    this.getCountOfUnseen(); //notifikacije za bolnicu
  }

  logOut(){
    this.authService.logout()
  }

  
  getCountOfUnseen(){
    this.notificationsService.countNumber().subscribe(
     numberOfUnseen => {
       this.numberOfUnseen = numberOfUnseen;
     }
    )
   }
}
