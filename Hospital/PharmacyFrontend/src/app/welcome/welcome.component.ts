import { Component, OnInit } from '@angular/core';
import { NotificationsService } from '../notifications/notifications.service';
import { RegistrationService } from './reistration.service';
@Component({
  selector: 'app-welcome',
  templateUrl: './welcome.component.html',
  styleUrls: ['./welcome.component.css']
})
export class WelcomeComponent implements OnInit {

  hospital: any={ hospitalId: 0, hospitalUrl: "", hospitalName: "", hospitalAddress:"", hospitalApiKey:"notDefinedYet", pharmacyApiKey:"notDefinedYet"}
  apiKeyForHospital : string=""
  numberOfUnseen: any;

  constructor(private _registrationService: RegistrationService, private notificationsService: NotificationsService) { }


  ngOnInit(): void {
    this.getCountOfUnseen();
  }
  register(){
    this._registrationService.register(this.hospital).subscribe((data:any) => {
      console.log(data);
      this.apiKeyForHospital = data.data;
  
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


