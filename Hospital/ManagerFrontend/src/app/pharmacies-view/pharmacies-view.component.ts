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
  pharmacyForEdit: any = { pharmacyId:"", pharmacyUrl: "", pharmacyName:"", pharmacyAddress:"", hospitalApiKey:""};
  editing: boolean = false;
  newPharmacy: any = { pharmacyUrl: "", pharmacyName:"", pharmacyAddress:"", hospitalApiKey: ""};

  constructor(private _pharmaciesService: PharmaciesService) { }

  ngOnInit(): void {
    this.refreshPharmacies();
  }

  addNewPharmacy(){
    this._pharmaciesService.addPharmacy(this.newPharmacy).subscribe( res => {
      this.refreshPharmacies();
      alert("Pharmacy added successfully!");
      alert("Api key for pharmacy is " + res);
    } );
    /*if (window.confirm('Are you sure, you want to add this pharmacy?')){
      this._pharmaciesService.addPharmacy(this.newPharmacy).subscribe( data => {
        this.refreshPharmacies();
        alert("Pharmacy added successfully!");
        alert("Api key for pharmacy is " + data);
      });
    }*/
   //pharmacyApiKey???
    this.newPharmacy = {pharmacyUrl: "", pharmacyName:"", pharmacyAddress:"", hospitalApiKey: ""};
  }

  deletePharmacy(id: number){
    if (window.confirm('Are you sure, you want to delete this pharmacy?')){
      this._pharmaciesService.deletePharmacy(id).subscribe( data => {
        this.refreshPharmacies();
        //alert("Pharmacy deleted successfully!");
      });
    }

  }

  refreshPharmacies(){
    this._pharmaciesService.getPharmacies().subscribe(
      pharmacies => {
        this.pharmacies = pharmacies;
      },
      error => this.errorMessage = <any> error);
  }

  editPharmacy(edit : any) {
    this.pharmacyForEdit = edit;
    this.editing = true;
  }

  cancel(){
    this.editing = false;
    this.refreshPharmacies();
  }

}
