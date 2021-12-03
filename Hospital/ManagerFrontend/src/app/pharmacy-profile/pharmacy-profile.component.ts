import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { PharmaciesService } from '../pharmacies-view/pharmacies.service';
import { IPharmacy } from '../pharmacies-view/pharmacy';
import { EditPharmacyService } from '../edit-pharmacy/edit-pharmacy.service';

@Component({
  selector: 'app-pharmacy-profile',
  templateUrl: './pharmacy-profile.component.html',
  styleUrls: ['./pharmacy-profile.component.css']
})
export class PharmacyProfileComponent implements OnInit {
 
pharmacyId: number=0 
pharmacy: any = { pharmacyId:"", pharmacyUrl: "", pharmacyName:"", pharmacyAddress:"", hospitalApiKey:"", comment: ""};
picture: any;

  constructor(private route: ActivatedRoute,
    private router: Router, private pharmacyService: PharmaciesService ) { }

  ngOnInit(): void { 
    this.pharmacyId = Number(this.route.snapshot.paramMap.get('id'));
    if(this.pharmacyId) {
      this.showProfilePharmacy(this.pharmacyId);
      
    }
  
  }

  showProfilePharmacy(pharmacyId: number) {
    this.pharmacyService.showProfilePharmacy(pharmacyId).subscribe(
      pharmacy =>  {
        var picture = "../../assets/images/" + pharmacy.picture
        this.pharmacy = pharmacy;
        this.pharmacy.picture= picture;
      }

    )
  }

  editPharmacy(pharmacy: any) {
   this.pharmacyService.editPharmacy(pharmacy).subscribe(
    pharmacy =>  {
    
      this.pharmacy = pharmacy;
      this.showProfilePharmacy(this.pharmacyId);
    }

  )
  }

}
