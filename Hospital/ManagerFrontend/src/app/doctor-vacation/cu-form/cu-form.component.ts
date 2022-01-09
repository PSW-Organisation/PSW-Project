import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDatepickerInputEvent } from '@angular/material/datepicker';
import { ActivatedRoute } from '@angular/router';
import { IDoctorVacation } from '../doctor-vacation';
import { DoctorVacationService } from '../doctor-vacation.service';

@Component({
  selector: 'app-cu-form',
  templateUrl: './cu-form.component.html',
  styleUrls: ['./cu-form.component.css'],
})
export class CuFormComponent implements OnInit {
  myForm!: FormGroup;
  minDate!: Date;
  doctorId!: string;
  @Input() formAction!: string;
  @Input() vacation!: IDoctorVacation;
  @Output() formCloseEvent = new EventEmitter<IDoctorVacation[]>();
  errorMessage: string = '';

  constructor(
    private _doctorVacationService: DoctorVacationService,
    private _route: ActivatedRoute,
    private _formBuilder: FormBuilder
  ) {}

  ngOnInit(): void {
    this.minDate = new Date(Date.now());
    this.doctorId = this._route.snapshot.paramMap.get('doctorId')!;
    this.vacation.doctorId = this.doctorId;
    this.myForm = this._formBuilder.group({
      startTimeCtrl: ['', Validators.required],
      endTimeCtrl: ['', Validators.required],
      descriptionCtrl: ['', Validators.required],
    });
    
  }

  dateLessThan(from: string, to: string) {
    return (group: FormGroup): {[key: string]: any} => {
     let f = group.controls[from];
     let t = group.controls[to];
     if (f.value > t.value) {
       return {
         dates: "Date from should be less than Date to"
       };
     }
     return {};
    }
  }

  addEvent(type: string, event: MatDatepickerInputEvent<Date>) {
    if (event.value != null) {
      if (type === 'inputStart' || type === 'changeStart') {
        this.vacation.dateSpecification.startTime.setFullYear(
          event.value.getFullYear()
        );
        this.vacation.dateSpecification.startTime.setMonth(
          event.value.getMonth()
        );
        this.vacation.dateSpecification.startTime.setDate(
          event.value.getDate()
        );
        this.vacation.dateSpecification.startTime.setHours(0,0,0,0);
      } else if (type === 'inputEnd' || type === 'changeEnd') {
        this.vacation.dateSpecification.endTime.setFullYear(
          event.value.getFullYear()
        );
        this.vacation.dateSpecification.endTime.setMonth(
          event.value.getMonth()
        );
        this.vacation.dateSpecification.endTime.setDate(event.value.getDate());
        this.vacation.dateSpecification.endTime.setHours(0,0,0,0);
      }
    }
  }

  formClose() {
    this._doctorVacationService
      .getDoctorVacations(this.doctorId)
      .subscribe((vac) => {
        this.formCloseEvent.emit(vac);
      });
  }
  cancel(){
    this.formClose()
  }

  submit(): void {
    if(this.vacation.dateSpecification.endTime<=this.vacation.dateSpecification.startTime){
      this.errorMessage = 'Vacations dates are invalid.';
      return;
    }
    if (this.formAction === 'create') {
      this._doctorVacationService
        .createDoctorVacation(this.vacation)
        .subscribe((createdVacation) => {
          console.log(createdVacation);
          if (createdVacation === null)
            this.errorMessage = 'Vacation collides with an existing one.';
          else this.formClose();
        });
    } else if (this.formAction === 'update') {
      this._doctorVacationService
        .updateDoctorVacation(this.vacation)
        .subscribe((updatedVacation) => {
          if (updatedVacation === null)
            this.errorMessage = 'Vacation collides with an existing one.';
          else this.formClose();
        });
    }
  }
}
