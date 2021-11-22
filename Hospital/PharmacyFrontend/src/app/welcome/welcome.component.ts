import { Component, OnInit } from '@angular/core';
import { RegistrationService } from './reistration.service';
@Component({
  selector: 'app-welcome',
  templateUrl: './welcome.component.html',
  styleUrls: ['./welcome.component.css']
})
export class WelcomeComponent implements OnInit {

  hospital: any={ hospitalId: 0, hospitalUrl: "", hospitalName: "", hospitalAddress:"", hospitalApiKey:"notDefinedYet", pharmacyApiKey:"notDefinedYet"}
  apiKeyForHospital : string=""


  constructor(private _registrationService: RegistrationService) { }


  ngOnInit(): void {
  }
  register(){
    this._registrationService.register(this.hospital).subscribe((data:any) => {
      console.log(data);
      this.apiKeyForHospital = data.data;
  
    });
    
    
  }
}
