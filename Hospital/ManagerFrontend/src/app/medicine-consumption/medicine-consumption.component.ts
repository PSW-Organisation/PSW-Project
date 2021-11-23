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
  timeRange: any = {startTime: Date, endTime: Date};
  medicineName: string = ""

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

  getMedicineDetails(){
    this._consumptionService.getMedicineDetails(this.pharmacyUrl, this.medicineName);
  }

  sendConsumptionReport(){
    this._consumptionService.sendConsumptionReport(this.pharmacyUrl, this.timeRange);
  }
}
