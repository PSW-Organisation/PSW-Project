import { Component, OnInit } from '@angular/core';
import { Doctor } from '../doctors/Doctor';
import { DoctorOnCallShiftService } from './doctor-on-call-shift.service';
import { IOnCallShift } from './on-call-shift';

@Component({
  selector: 'app-doctor-on-call-shift',
  templateUrl: './doctor-on-call-shift.component.html',
  styleUrls: ['./doctor-on-call-shift.component.css']
})
export class DoctorOnCallShiftComponent implements OnInit {

  onCallShift : IOnCallShift = {
    id: 0,
    date: new Date(""),
    doctorId: "0",
  };
  selectedDate!: Date;
  selectedDateDoctorsOnCallShift!: Doctor[];
  selectedDateDoctorsNotOnCallShift!: Doctor[];
  selectedDoctor: Doctor=new Doctor('0','',0,'','','','','','','','',1);
  selectedDoctorBool: boolean = false;
  pastDate : boolean = false;

  constructor(private _doctorOnCallShiftService: DoctorOnCallShiftService) { 
    this.selectedDate = new Date(Date.now());
    this.selectedDate.setHours(0,0,0,0);
  }

  ngOnInit(): void {
    this.datePassed(new Date(Date.now()));
    this.loadData();
  }

  selectDoctor(newDoctor: Doctor): void {
    this.onCallShift.doctorId = newDoctor.id;
    this.selectedDoctorBool = true;
  }

  datePassed(date:Date):void{
    let dateToday = new Date(Date.now());
    dateToday.setHours(0,0,0,0);
    if(date>=dateToday)
      this.pastDate = true;
    else
      this.pastDate = false;
  }

  dateChange(event:Date):void {
    this.datePassed(event);
    this.selectedDate = event;
    this.loadData();
  }

  loadData(): void {
    //this.selectedDate.setHours(23,0,0,0);
    this.onCallShift.date =  new Date(Date.UTC(this.selectedDate.getFullYear(), this.selectedDate.getMonth(), this.selectedDate.getDate(), this.selectedDate.getHours(), this.selectedDate.getMinutes()));
    this._doctorOnCallShiftService.GetDoctorsOnCallShift(this.selectedDate.toLocaleDateString("sr-RS")).subscribe(doctors => { this.selectedDateDoctorsOnCallShift = doctors; console.log(doctors); });
    this._doctorOnCallShiftService.GetDoctorsNotOnCallShift(this.selectedDate.toLocaleDateString("sr-RS")).subscribe(doctors => { this.selectedDateDoctorsNotOnCallShift = doctors; console.log(doctors);});
  }

  addNewDoctor(): void{
    this.selectedDoctorBool = false;
    this._doctorOnCallShiftService.AddDoctorOnCallShift(this.onCallShift).subscribe(retval => { console.log(retval);  this.loadData();  });
  }

  removeDoctor(removeDoctor: Doctor): void{
    if (confirm('Are you sure you want to remove doctor ' + removeDoctor.name + ' ' + removeDoctor.surname +  ' for onCallShift?')) {
      this.onCallShift.doctorId = removeDoctor.id;
      this._doctorOnCallShiftService.RemoveDoctorOnCallShift(this.onCallShift).subscribe(retval => { console.log(retval);  this.loadData();  });
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
      return this.onCallShift.doctorId == newDoctor.id;
    }
    return false;
  }

}
