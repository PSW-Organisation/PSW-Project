import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
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
  onCallShifts: string[];

  constructor(private _route: ActivatedRoute, private _doctorViewService: DoctorViewService) {
    this.onCallShifts = ['1999-11-09 00:00:00','1999-11-09 00:00:00','1999-11-09 00:00:00','1999-11-09 00:00:00','1999-11-09 00:00:00','1999-11-09 00:00:00','1999-11-09 00:00:00','1999-11-09 00:00:00','1999-11-09 00:00:00'];
   }

  ngOnInit(): void {

    this.doctorId = "" + this._route.snapshot.paramMap.get('id');
    this._doctorViewService.getDoctorById(this.doctorId).subscribe(doctor => this.doctor = doctor);
  }

}
