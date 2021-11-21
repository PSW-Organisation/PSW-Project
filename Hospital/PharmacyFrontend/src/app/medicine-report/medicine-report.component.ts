import { Component, OnInit } from '@angular/core';
import { IHospital } from './hospital';
import { IMedicine } from './medicine';
import { MedicineReportService } from './medicine-report.service';

@Component({
  selector: 'app-medicine-report',
  templateUrl: './medicine-report.component.html',
  styleUrls: ['./medicine-report.component.css']
})
export class MedicineReportComponent implements OnInit {

  medicine: IMedicine[] = [];
  errorMessage: string = "";
  medicineId: number = 0; 
  hospitals: IHospital[] = [];
  hospitalUrl: string = "";
  fileToUpload: File | null = null;

  constructor(private _reportService: MedicineReportService) { }

  ngOnInit(): void {
    this.getMedicine();
    this.getHospitals();
  }

  getMedicine(){
    this._reportService.getMedicine().subscribe(
      medicine => {
        this.medicine = medicine;
      },
      error => this.errorMessage = <any> error);
  }

  getMedicineReport(){
    this._reportService.getMedicineReport(this.medicineId);
  }

  getHospitals(){
    this._reportService.getHospitals().subscribe(
      hospitals => {
        this.hospitals = hospitals;
      },
      error => this.errorMessage = <any> error);
  }

  handleFileInput(event: Event) {
    this.fileToUpload = (<HTMLInputElement>event.target).files?.item(0) as File;
  }

  uploadFileToActivity() {
    this._reportService.postFile(this.fileToUpload as File, this.hospitalUrl).subscribe(data => {
      // do something, if upload success
      }, error => {
        console.log(error);
      });
  }
}
