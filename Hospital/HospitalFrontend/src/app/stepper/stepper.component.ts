import { DatePipe, DOCUMENT } from '@angular/common';
import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router, Event } from '@angular/router';
import { NavigationStart, NavigationError, NavigationEnd } from '@angular/router';
import { NgbDate } from '@ng-bootstrap/ng-bootstrap';
import Stepper from 'bs-stepper';
import * as moment from 'moment';
import { ToastrService } from 'ngx-toastr';
import { Doctor } from './doctor';
import { Visit } from '../recommended-appointment-scheduling/visits';
import { SchedulingService } from '../scheduling.service'

@Component({
  selector: 'app-stepper',
  templateUrl: './stepper.component.html',
  styleUrls: ['./stepper.component.css']
})
export class StepperComponent implements OnInit {
  stepper: any = null;
  date: string = '';
  minDate: moment.Moment = moment();
  startDate: moment.Moment = moment();
  isBlocked: boolean = false;
  selectedDoctorFullname: string = '';

  doctors: Doctor[] = [];
  specializations: number[] = [];
  selectedSpec: number = 0;
  filteredDoctors: Doctor[] = [];
  selectedDoc: string = '';

  visits: any[] = [];
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

  dateForm: FormGroup = new FormGroup({
    dateControl: new FormControl(this.date, [
      Validators.required
    ])
  });
  specForm: FormGroup = new FormGroup({
    specControl: new FormControl(this.selectedSpec, [
      Validators.required
    ])
  });
  doctorForm: FormGroup = new FormGroup({
    doctorControl: new FormControl(this.selectedDoc, [
      Validators.required
    ])
  });

  get selectedDate() { return this.dateForm.get('dateControl') }
  get selectedSpecialization() { return this.specForm.get('specControl') }
  get selectedDoctor() { return this.doctorForm.get('doctorControl') }



  constructor(@Inject(DOCUMENT) private document: Document, private schedulingService: SchedulingService,
    private toastr: ToastrService, private router: Router, private datepipe: DatePipe) {
      this.router.events.subscribe((event: Event) => {
        if (event instanceof NavigationStart) {
          
        }

        if (event instanceof NavigationError) {
            // Handle error
            console.error(event.error);
        }

        if (event instanceof NavigationEnd) {
          let bsstepper = this.document.querySelector('.bs-stepper')
          if (bsstepper != null)
            this.stepper = new Stepper(bsstepper)
            this.getDoctors();
            this.configDatePicker();
        }
    });
     }

  ngOnInit(): void {
    // var self = this
    // this.document.addEventListener('DOMContentLoaded', function () {
    //   let bsstepper = self.document.querySelector('.bs-stepper')
    //   if (bsstepper != null)
    //     self.stepper = new Stepper(bsstepper)
    // })
    // this.getDoctors();
    // this.configDatePicker();
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
        this.getSpecializations();
        this.specForm.get('specControl')?.setValue(this.specializations[0])
      }, error: e => (console.log(e))
    })
  }

  getSelectedDoctor() {
    this.selectedDoc = (document.getElementById("doctor") as HTMLSelectElement).value
    this.doctors.forEach(element => {
      if (element.id === this.selectedDoc) {
        this.selectedDoctorFullname = element.fullName
      }
    });
    this.generateFreeVisits()
  }

  getSpecializations() {
    let filter = this.doctors.map(d => d.specialization);
    this.specializations = filter?.filter((d, index) => {
      return filter.indexOf(d) === index;
    });
  }

  getSelectedSpecialization() {
    this.selectedSpec = this.specForm.get('specControl')?.value
    this.filteredDoctors = []
    this.filteredDoctors = this.doctors.filter(d => d.specialization == this.selectedSpec)
    this.doctorForm.get('doctorControl')?.setValue(this.filteredDoctors[0])
  }
  nextStep() {
    this.stepper.next();
  }
  backToPrevious(step: number) {
    this.stepper.to(step);
  }
  onDateSelect(event: any): void {
    this.dateForm.get('dateControl')?.setValue(`${event.day}-${event.month}-${event.year}`)
    this.date = this.dateForm.get('dateControl')?.value
  }
  configDatePicker(): void {
    this.minDate = moment(Date.now());
    this.startDate = moment(Date.now()).add(1, 'months');
  }

  isDisabled = (date: NgbDate) =>
    moment({ year: date.year, month: date.month - 1, day: date.day }).isBefore(moment());

  selectedRow(visit: Visit) {
    this.visits.map(x => {
      x.isCanceled = false
      return x
    })
    this.selectedVisit = {
      startTime: visit.startTime,
      endTime: visit.endTime,
      visitType: visit.visitType,
      doctorId: visit.doctorId,
      patientId: 'imbiamba',
      isReviewed: false,
      isCanceled: false
    }
    visit.isCanceled = true;
    this.canCreate = true;
  }
  generateFreeVisits() {
    let self = this
    let dateParts = this.date.split('-');
    this.schedulingService.getGeneratedFreeVisits(this.selectedDoc, false, false,
      `${dateParts[1]}/${dateParts[0]}/${dateParts[2]}`,
      `${dateParts[1]}/${dateParts[0]}/${dateParts[2]}`).subscribe({
        next: response => {
          this.visits = response
          //this.visits = []
        }
      })
  }

  createVisit() {
    if (this.canCreate) {
      this.schedulingService.createVisit(this.selectedVisit).subscribe({
        next: response => {
          this.showSuccess("Appointment successfully scheduled!")
          this.router.navigate(['/appointments'], { queryParams: { username: this.selectedVisit.patientId } })
        },
        error: e => {
          if (e.status === 400) this.showError("The selected appointment has been taken in the meantime. Please try selecting another one.")
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

  checkIfVisitsEmpty(): boolean {
    return this.visits.length === 0
  }

}