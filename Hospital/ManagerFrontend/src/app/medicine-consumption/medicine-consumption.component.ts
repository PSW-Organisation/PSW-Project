import { Component, OnInit } from '@angular/core';
import { IPharmacy } from '../pharmacies-view/pharmacy';
import { MedicineConsumptionService } from './medicine-consumption.service';

@Component({
  selector: 'app-medicine-consumption',
  templateUrl: './medicine-consumption.component.html',
  styleUrls: ['./medicine-consumption.component.css']
})
export class MedicineConsumptionComponent implements OnInit {
  fileToUpload: File | null = null;
  pharmacyUrl: string = "";
  pharmacies: IPharmacy[]= [];
  errorMessage: string = ""
  timeRange: any = {startDate: Date, endDate: Date};

  constructor(private _consumptionService: MedicineConsumptionService) { }

  ngOnInit(): void {
    this.getPharmacies();
  }

  getPharmacies(){
    this._consumptionService.getPharmacies().subscribe(
      pharmacies => {
        this.pharmacies = pharmacies;
      },
      error => this.errorMessage = <any> error
    );
  }

  handleFileInput(event: Event) {
    this.fileToUpload = (<HTMLInputElement>event.target).files?.item(0) as File;
  }

  uploadFileToActivity() {
    this._consumptionService.postFile(this.fileToUpload as File, this.pharmacyUrl).subscribe(data => {
      // do something, if upload success
      }, error => {
        console.log(error);
      });
  }

  getMedicineReport(){
    this._consumptionService.getMedicineReport(this.timeRange);
    this.timeRange= {startDate: null, endDate: null}
  }

}
