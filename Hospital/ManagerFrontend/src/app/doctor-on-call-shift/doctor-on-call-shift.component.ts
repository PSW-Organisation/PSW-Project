import { Component, OnInit } from '@angular/core';
import { Doctor } from '../doctors/Doctor';
import { DoctorOnCallShiftService } from './doctor-on-call-shift.service';

@Component({
  selector: 'app-doctor-on-call-shift',
  templateUrl: './doctor-on-call-shift.component.html',
  styleUrls: ['./doctor-on-call-shift.component.css']
})
export class DoctorOnCallShiftComponent implements OnInit {

  selectedDate!: Date;
  selectedDateDoctorsOnCallShift!: Doctor[];
  selectedDateDoctorsNOTOnCallShift!: Doctor[];
  selectedDoctor!: Doctor;
  selectedDoctorBool: boolean = false;

  constructor(private _doctorOnCallShiftService: DoctorOnCallShiftService) { 
    this.selectedDate = new Date(Date.now());
  }

  ngOnInit(): void {
    this._doctorOnCallShiftService.GetDoctorsOnCallShift(this.selectedDate).subscribe(doctors => { this.selectedDateDoctorsOnCallShift = doctors; console.log(doctors); });
    this._doctorOnCallShiftService.GetDoctorsNOTOnCallShift(this.selectedDate).subscribe(doctors => { this.selectedDateDoctorsNOTOnCallShift = doctors; console.log(doctors);});
  }

  selectDoctor(newDoctor: Doctor): void {
    this.selectedDoctor = newDoctor;
  }

  addNewDoctor(): void{
    
  }

  cancelAdd(): void {
    this.selectedDoctorBool = false;
  }

}
