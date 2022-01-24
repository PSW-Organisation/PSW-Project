import { Component, OnInit } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { PharmaciesService } from '../pharmacies-view/pharmacies.service';
import { IPharmacy } from '../pharmacies-view/pharmacy'

@Component({
  selector: 'app-add-pharmacy',
  templateUrl: './add-pharmacy.component.html',
  styleUrls: ['./add-pharmacy.component.css']
})
export class AddPharmacyComponent implements OnInit {
  newPharmacy: any = { pharmacyUrl: "", pharmacyName:"", pharmacyAddress:"", hospitalApiKey: "", comment: "", picture: "", pharmacyCommunicationType:"", email: ""};

  constructor(private _pharmaciesService: PharmaciesService, private router: Router) { }

  ngOnInit(): void {
  }

  addNewPharmacy(){

    if (this.newPharmacy.pharmacyUrl == "")
    {
      alert("Url should be defined!");
    }

    
    if ( this.newPharmacy.pharmacyName == "")
    {
      alert("Name should be defined!");
    }

    
    if (this.newPharmacy.pharmacyAddress == "")
    {
      alert("Address should be defined!");
    }

    this._pharmaciesService.addPharmacy(this.newPharmacy).subscribe( res => {
      alert("Pharmacy added successfully!");
    } );
    
    //this.newPharmacy = {pharmacyUrl: "", pharmacyName:"", pharmacyAddress:"", hospitalApiKey: "",pharmacyCommunicationType: ""};

    if (this.newPharmacy.pharmacyUrl != "" && this.newPharmacy.pharmacyName != "" && this.newPharmacy.pharmacyAddress != "")
    this.router.navigateByUrl('/pharmacies');
  }

}
