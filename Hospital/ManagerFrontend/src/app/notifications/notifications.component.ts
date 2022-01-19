import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { INotification } from './notification';
import { NotificationsService } from './notifications.service';

@Component({
  selector: 'app-notifications',
  templateUrl: './notifications.component.html',
  styleUrls: ['./notifications.component.css']
})
export class NotificationsComponent implements OnInit {
notifications: INotification[] =[];
numberOfUnseen: any;


  constructor(private notificationsService: NotificationsService) { }

  ngOnInit(): void {
    this.getAllNotifications();
  }

 getAllNotifications() {
    this.notificationsService.getNotifications().subscribe(
      notifications => {
        this.notifications = notifications;
      }
    )
 }

getCountOfUnseen(){
 this.notificationsService.countNumber().subscribe(
  numberOfUnseen => {
    this.numberOfUnseen = numberOfUnseen;
  }
 )
}

 changeToSeen(notification:any){
   this.notificationsService.changeToSeen(notification).subscribe(data => {
    this.getAllNotifications();
  });
 }
 deleteNotification(notificationId: any){
  this.notificationsService.deleteNotification(notificationId).subscribe( data => {
    this.getAllNotifications();
  });
 
}

getCountOfUnseen(){
  this.notificationsService.countNumber().subscribe(
   numberOfUnseen => {
     this.numberOfUnseen = numberOfUnseen;
   }
  )
 }
}
