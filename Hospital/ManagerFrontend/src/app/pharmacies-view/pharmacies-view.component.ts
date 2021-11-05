import { Component, OnInit } from '@angular/core';
import { PharmaciesService } from './pharmacies.service';
import { IPharmacy } from './pharmacy';


@Component({
  selector: 'app-pharmacies-view',
  templateUrl: './pharmacies-view.component.html',
  styleUrls: ['./pharmacies-view.component.css']
})
export class PharmaciesViewComponent implements OnInit {
  pharmacies: IPharmacy[] = [];
  errorMessage: string = ""; 
  newPharmacy: any = { pharmacyUrl: "", pharmacyName:"", pharmacyAddress:"", pharmacyApiKey: ""};

  constructor(private _pharmaciesService: PharmaciesService) { }

  ngOnInit(): void {
    this.refreshPharmacies();
  }

  addNewPharmacy(){
    this._pharmaciesService.addPharmacy(this.newPharmacy).subscribe(res => this.refreshPharmacies());
    this.newPharmacy = {pharmacyUrl: "", pharmacyName:"", pharmacyAddress:"", pharmacyApiKey: ""};
  }

  refreshPharmacies(){
    this._pharmaciesService.getPharmacies().subscribe(
      pharmacies => {
        this.pharmacies = pharmacies;
      },
      error => this.errorMessage = <any> error);
  }

}
