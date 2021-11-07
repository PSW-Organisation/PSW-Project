import { Component, OnInit } from '@angular/core';
import { retry } from 'rxjs-compat/operator/retry';
import { PharmaciesService } from '../pharmacies-view/pharmacies.service';
import { IPharmacy } from '../pharmacies-view/pharmacy';
import { IComplaint } from './complaint';
import { ComplaintsService } from './complaints.service';

@Component({
  selector: 'app-complaints-view',
  templateUrl: './complaints-view.component.html',
  styleUrls: ['./complaints-view.component.css']
})
export class ComplaintsViewComponent implements OnInit {
  complaints: IComplaint[] = []
  errorMessage: string = ""
  pharmacies: IPharmacy[]= []

  myApiKey: string=""

  pharmacy: any = { pharmacyUrl: "", pharmacyName:"", pharmacyAddress:"", hospitalApiKey: "", pharmacyId: ""};

  newComplaint: any = { complaintId: 0, date: "2021-11-05T18:42:03.155742", title:"", content:"", pharmacyId: 0};

  constructor(private _complaintsService: ComplaintsService) { }

  ngOnInit(): void {
    this.refreshComplaints();
    this.loadPharmacies();
  }


  refreshComplaints() {
    this._complaintsService.getComplaints().subscribe(
      complaints => {
        this.complaints = complaints;
      },
      error => this.errorMessage = <any> error
    );
  }

  addNewComplaint(){
   var stringToConvert= this.newComplaint.pharmacyId;
   var numberId= Number(stringToConvert);
   this.newComplaint.pharmacyId=numberId;
    this._complaintsService.addComplaint(this.newComplaint).subscribe(res => this.refreshComplaints());
    this.sendComplaintToPharmacy();
 
  }
sendComplaintToPharmacy(){
  var stringToConvert= this.newComplaint.pharmacyId;
  var numberId= Number(stringToConvert);
  this.newComplaint.pharmacyId=numberId;
  this.myApiKey = this.getMyApiKey(this.newComplaint.pharmacyId);
  this._complaintsService.sendComplaintToPharmacy(this.newComplaint, this.myApiKey).subscribe(res=> this.refreshComplaints())
}
  loadPharmacies(){
    this._complaintsService.getPharmacies().subscribe(
      pharmacies => {
        this.pharmacies = pharmacies;
      },
      error => this.errorMessage = <any> error
    );
  }

  getMyApiKey(pharmacyId: any) : any{
    var api = "";
    this.pharmacies.forEach(pharmacy => {
      if(pharmacy.pharmacyId == pharmacyId){
        api = pharmacy.hospitalApiKey;
      } 
    }) 
    return api;
  }

}
