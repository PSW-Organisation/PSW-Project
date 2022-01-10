import { Component, OnInit } from '@angular/core';
import { Doctor } from './Doctor';
import { DoctorsService } from './doctors.service';
import { Router } from '@angular/router';
import {ScheduleComponent} from '../doctor-vacation/schedule/schedule.component'

@Component({
  selector: 'app-doctors',
  templateUrl: './doctors.component.html',
  styleUrls: ['./doctors.component.css']
})
export class DoctorsComponent implements OnInit {

  doctors: Array<Doctor>;
  searchByNameAndSurname: string = "";

  constructor(private _doctorService: DoctorsService,  private _router: Router) { 
    this.doctors = [];
  }

  ngOnInit(): void {
    this._doctorService.getDoctors().subscribe(doctors => this.doctors = doctors);
  }

  goToDoctorView(doctor: Doctor): void {
    this._router.navigateByUrl(`doctorView/${doctor.id}`);
  }

  renderIf(doctor: Doctor): boolean {
    return (doctor.name + doctor.surname).toLowerCase().includes(this.searchByNameAndSurname.toLowerCase());
  }

}
