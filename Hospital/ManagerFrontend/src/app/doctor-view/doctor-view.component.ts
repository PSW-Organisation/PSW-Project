import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { IOnCallShift } from '../doctor-on-call-shift/on-call-shift';
import { Doctor } from '../doctors/Doctor';
import { IShift } from '../manage-shifts/shift';
import { ShiftService } from '../manage-shifts/shift.service';
import { DoctorViewService } from './doctor-view.service';


@Component({
  selector: 'app-doctor-view',
  templateUrl: './doctor-view.component.html',
  styleUrls: ['./doctor-view.component.css']
})
export class DoctorViewComponent implements OnInit {
  selected: boolean = false;
  doctorId: string = "";
  doctor!: Doctor;
  newDoctor!: Doctor;
  onCallShifts!: IOnCallShift[];
  selectedShiftOrder!: number;
  initialShiftOrder!: number;
  newShift!: IShift;
  shifts! : IShift[];

  constructor(private _route: ActivatedRoute, private _doctorViewService: DoctorViewService, private _shiftService: ShiftService,) {
   }

  ngOnInit(): void {

    this.doctorId = "" + this._route.snapshot.paramMap.get('id');
    this._doctorViewService.getDoctorById(this.doctorId).subscribe(doctor => {this.doctor = doctor
      this._shiftService.getAllShifts().subscribe(shifts => {
        this.shifts = shifts;
        this.initSelection(this.doctor.shiftOrder);
        })
    });
    this._doctorViewService.GetAllOnCallShiftByDoctorId(this.doctorId).subscribe(shifts => { this.onCallShifts = shifts; console.log(shifts); });
  }

  initSelection(shiftOrder: Number){
      let doctorShift= this.shifts.find(e => e.shiftOrder == shiftOrder);
      if(doctorShift !== undefined){
        this.selectedShiftOrder = doctorShift.shiftOrder;
        this.initialShiftOrder = doctorShift.shiftOrder;
      }
  }
  formatDate(date:Date):string{
    var newDate = new Date(date);
    var dd = String(newDate.getDate()).padStart(2, '0');
    var mm = String(newDate.getMonth() + 1).padStart(2, '0'); //January is 0!
    var yyyy = newDate.getFullYear();
    return dd + '/' + mm + '/'  + yyyy;
  }


  select() {
     if(this.selectedShiftOrder != this.initialShiftOrder){
     this.selected = true;
     this.initialShiftOrder = this.selectedShiftOrder;
     }
  }

  changeDoctorShiftOrder(){
    this.newDoctor = this.doctor;
    this.newDoctor.shiftOrder = this.selectedShiftOrder;
    this._doctorViewService.updateDoctor(this.doctorId,this.newDoctor).subscribe(d=> this.doctor =d);
    this.selected = false;
  }

}
