import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { IOnCallShift } from '../doctor-on-call-shift/on-call-shift';
import { Doctor } from '../doctors/Doctor';
import { DoctorViewService } from './doctor-view.service';

@Component({
  selector: 'app-doctor-view',
  templateUrl: './doctor-view.component.html',
  styleUrls: ['./doctor-view.component.css']
})
export class DoctorViewComponent implements OnInit {

  doctorId: string = "";
  doctor!: Doctor;
  onCallShifts!: IOnCallShift[];

  constructor(private _route: ActivatedRoute, private _doctorViewService: DoctorViewService) {
   }

  ngOnInit(): void {

    this.doctorId = "" + this._route.snapshot.paramMap.get('id');
    this._doctorViewService.getDoctorById(this.doctorId).subscribe(doctor => this.doctor = doctor);
    this._doctorViewService.GetAllOnCallShiftByDoctorId(this.doctorId).subscribe(shifts => { this.onCallShifts = shifts; console.log(shifts); });
  }

  formatDate(date:Date):string{
    var newDate = new Date(date);
    var dd = String(newDate.getDate()).padStart(2, '0');
    var mm = String(newDate.getMonth() + 1).padStart(2, '0'); //January is 0!
    var yyyy = newDate.getFullYear();
    return dd + '/' + mm + '/'  + yyyy;
  }

}
