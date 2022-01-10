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
    this.loadData();
  }

  selectDoctor(newDoctor: Doctor): void {
    this.selectedDoctor = newDoctor;
    this.selectedDoctorBool = true;
  }

  loadData(): void {
    this._doctorOnCallShiftService.GetDoctorsOnCallShift(this.selectedDate).subscribe(doctors => { this.selectedDateDoctorsOnCallShift = doctors; console.log(doctors); });
    this._doctorOnCallShiftService.GetDoctorsNOTOnCallShift(this.selectedDate).subscribe(doctors => { this.selectedDateDoctorsNOTOnCallShift = doctors; console.log(doctors);});
  }

  addNewDoctor(): void{
    this.selectedDoctorBool = false;
    this._doctorOnCallShiftService.AddDoctorOnCallShift(this.selectedDoctor.id, this.selectedDate).subscribe(retval => { console.log(retval);  this.loadData();  });
  }

  removeDoctor(removeDoctor: Doctor): void{
    if (confirm('Are you sure you want to remove doctor ' + removeDoctor.name + ' ' + removeDoctor.surname +  ' for onCallShift?')) {
      this._doctorOnCallShiftService.RemoveDoctorOnCallShift(removeDoctor.id, this.selectedDate).subscribe(retval => { console.log(retval);  this.loadData();  });
    } else {
      // Do nothing!
    }
  }

  cancelAdd(): void {
    console.log(this.selectedDoctorBool);
    this.selectedDoctorBool = false;
    console.log(this.selectedDoctorBool);
  }

  selectCSS(newDoctor: Doctor): boolean {
    if (this.selectedDoctorBool) {
      return this.selectedDoctor.id == newDoctor.id;
    }
    return false;
  }

}
