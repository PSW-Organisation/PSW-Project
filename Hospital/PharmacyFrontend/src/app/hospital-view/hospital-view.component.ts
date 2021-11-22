import { Component, OnInit } from '@angular/core';
import { IHospital } from '../welcome/hospital';
import { HospitalService } from './hospital.service';

@Component({
  selector: 'app-hospital-view',
  templateUrl: './hospital-view.component.html',
  styleUrls: ['./hospital-view.component.css']
})
export class HospitalViewComponent implements OnInit {

  hospitals: IHospital[]=[]

  constructor(private _complaintService: HospitalService) { }

  ngOnInit(): void {
    this.loadHospitals();
  }

  
  loadHospitals() {
    this._complaintService.getHospitals().subscribe(
      hospitals => {
        this.hospitals = hospitals;
      }
    );
  }

}
