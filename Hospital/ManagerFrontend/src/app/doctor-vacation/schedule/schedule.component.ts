import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IDoctorVacation } from '../doctor-vacation';
import { DoctorVacationService } from '../doctor-vacation.service';
import { TimeSpan } from '../timespan';

@Component({
  selector: 'app-schedule',
  templateUrl: './schedule.component.html',
  styleUrls: ['./schedule.component.css']
})
export class ScheduleComponent implements OnInit {

  title : string = 'Doctors Vacations';
  doctorId! : string;
  vacations! : IDoctorVacation[];
  vacation : IDoctorVacation=  {
    id: 0,
    dateSpecification: {
      startTime: new Date(""),
      endTime: new Date(""),
      duration: new TimeSpan(0),
    },
    description: '',
    doctorId: "0",
  };;
  formAction! : string;
  formOpened : boolean = false;

  constructor(private _doctorVacationService: DoctorVacationService,
              private _route: ActivatedRoute) { }

  ngOnInit(): void {
    this.doctorId = this._route.snapshot.paramMap.get('doctorId')!;
    this._doctorVacationService.getDoctorVacations(this.doctorId).subscribe(vacations =>{
      this.vacations = vacations;
    })
  }

  removeVacation(vacation: IDoctorVacation): void{
    this._doctorVacationService.deleteDoctorVacation(vacation).subscribe(deletedVacation =>{
      this._doctorVacationService.getDoctorVacations(this.doctorId).subscribe(vacations =>{
        this.vacations = vacations;
      })
    })
  }

  updateVacation(vacation: IDoctorVacation): void{
    this.formOpened = true;
    this.formAction = "update";
    this.vacation = vacation;
  }

  createVacation(){
    this.formOpened = true;
    this.formAction = "create";
  }

  closeForm(vacations:IDoctorVacation[]) {
    this.formOpened = false;
    this.vacations = vacations;
  }

  formatDate(date:Date):string{
    var newDate = new Date(date);
    var dd = String(newDate.getDate()).padStart(2, '0');
    var mm = String(newDate.getMonth() + 1).padStart(2, '0'); //January is 0!
    var yyyy = newDate.getFullYear();
    return mm + '/' + dd + '/' + yyyy;
  }

}
