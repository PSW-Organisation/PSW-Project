import { DatePipe } from '@angular/common';
import { isNull } from '@angular/compiler/src/output/output_ast';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NgbCalendar, NgbDate } from '@ng-bootstrap/ng-bootstrap';
import * as moment from 'moment';
import { Visit } from '../recommended-appointment-scheduling/visits';
import { SchedulingService } from '../scheduling.service';
import { Doctor } from '../stepper/doctor';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Patient } from '../registration/patient';

@Component({
  selector: 'recommended-appointment-scheduling',
  templateUrl: './recommended-appointment-scheduling.component.html',
  styleUrls: ['./recommended-appointment-scheduling.component.css']
})
export class RecommendedAppointmentSchedulingComponent implements OnInit {

  minDate: moment.Moment = moment().add(1, "days");
  hoveredDate: NgbDate | null = null;
  priority: boolean = true;
  fromDate: NgbDate;
  toDate:  NgbDate | null = null;
  selectedD: string = '22222';
  
  user: Patient = JSON.parse(localStorage.getItem('currentUser') || '{}')
  generatedFreeVisits: any[] = [];
  selectedVisit: Visit =
    {
      startTime: new Date(),
      endTime: new Date(),
      visitType: 0,
      doctorId: '',
      patientId: '',
      isReviewed: false,
      isCanceled: false,
    }  
  isSelected: boolean = false;
  canCreate: boolean = false;
  isGenerated: boolean = false;

  constructor(calendar: NgbCalendar, private schedulingService: SchedulingService, 
    private datepipe: DatePipe,private toastr: ToastrService, private router: Router) {
    this.fromDate = calendar.getToday();
    this.toDate = calendar.getNext(calendar.getToday(), 'd', 10);
  }

  doctors: Doctor[] = [];

  visitForm: FormGroup = new FormGroup({
    dateControl: new FormControl( [
      Validators.required
    ]),
    radioControl: new FormControl(this.priority,[
      Validators.required
    ])
  });

  get selectedDate() { return this.visitForm.get('dateControl') }
  get selectedRadio() { return this.visitForm.get('radioControl') }

  onDateSelection(date: NgbDate) {
    if (!this.fromDate && !this.toDate) {
      this.fromDate = date;
    } else if (this.fromDate && !this.toDate && date.after(this.fromDate)) {
      this.toDate = date;
    } else {
      this.toDate = null;
      this.fromDate = date;
    }
  }

  isHovered(date: NgbDate) {
    return this.fromDate && !this.toDate && this.hoveredDate && date.after(this.fromDate) && date.before(this.hoveredDate);
  }

  isInside(date: NgbDate) {
    return this.toDate && date.after(this.fromDate) && date.before(this.toDate);
  }

  isRange(date: NgbDate) {
    return date.equals(this.fromDate) || (this.toDate && date.equals(this.toDate)) || this.isInside(date) || this.isHovered(date);
  }

  isDisabled = (date: NgbDate) =>
    moment({ year: date.year, month: date.month - 1, day: date.day }).isBefore(moment());

  ngOnInit(): void {
    this.getDoctors();
  }

  getDoctors() {
    this.schedulingService.getDoctors().subscribe({
      next: d => {
        d.forEach((element: { username: any; fullName: any; specialization: any; }) => {
          let doctor = <Doctor>{
            id: element.username,
            fullName: element.fullName,
            specialization: element.specialization
          }
          this.doctors.push(doctor)
        });
      }, error: e => (console.log(e))
    })
  }

  generateFreeVisits(){
    if(this.toDate === null){
      this.toDate = this.fromDate
    }
    this.selectedD = (document.getElementById("select") as HTMLSelectElement).value
    this.priority = this.visitForm.get("radioControl")?.value
    this.schedulingService.getGeneratedFreeVisits(this.selectedD, this.priority, true, 
      `${this.fromDate.month}/${this.fromDate.day}/${this.fromDate.year}`,
      `${this.toDate?.month}/${this.toDate?.day}/${this.toDate?.year}`).subscribe({
      next: response => {
        this.generatedFreeVisits = response
        this.isGenerated = true
      }
    })
  }
  selectedRow(visit: Visit){
    this.generatedFreeVisits.map( x => {
      x.isCanceled = false
      return x 
    }) 
    this.selectedVisit = {
      startTime: visit.startTime,
      endTime: visit.endTime,
      visitType: visit.visitType,
      doctorId: visit.doctorId,
      patientId: this.user?.username,
      isReviewed: false,
      isCanceled: false
    }
    visit.isCanceled = true;
    this.canCreate = true;
  }

  createVisit() {
    if(this.canCreate){
      this.schedulingService.createVisit(this.selectedVisit).subscribe({
        next: response => {
          this.showSuccess("Appointment successfully scheduled!")
          this.router.navigate(['/appointments'])
        }, 
        error: e => {
          if(e.status === 400) this.showError("The selected appointment has been taken in the meantime. Please try selecting another one.")   
          else this.showError("Failed.")
        }
      })
    }
    else this.showError("Please select an appointment.")
  }
  showSuccess(message: string) {
    this.toastr.success(message);
  }

  showError(message: string) {  
    this.toastr.error(message);
  }

}
