import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NgbDate, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { RegistrationService } from './registration.service';
import { Patient } from './patient';
import { Allergen } from './allergen';
import { Doctor } from './doctor';
import { Router } from '@angular/router';
import { MedicalRecord } from './medical-record';
import * as XRegExp from 'xregexp';
import * as moment from 'moment';
import { ProfileService } from '../profile/profile.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  countries: string[] = ['Serbia', 'Bosnia and Herzegovina', 'Montenegro']
  bloodTypes: string[] = ['A+', 'A-', 'B+', 'B-', 'AB+', 'AB-', 'O+', 'O-']
  cities: string[] = []
  allergens: Allergen[] = []
  doctors: Doctor[] = []
  minDate: moment.Moment = moment()
  maxDate: moment.Moment = moment()
  startDate: moment.Moment = moment()

  settings = {
    singleSelection: false,
    text: "Select allergens",
    selectAllText: 'Select all',
    unSelectAllText: 'Unselect all',
    enableSearchFilter: true,
    labelKey: 'name',
    primaryKey: 'id',
    tagToBody: false,
    lazyLoading: true,
    maxHeight: 150,
  };

  patient: Patient = {
    loginType: 'patient',
    username: '',
    password: '',
    name: '',
    parentName: '',
    surname: '',
    dateOfBirth: '',
    gender: 'male',
    phone: '',
    email: '',
    address: '',
    city: 'Ada',
    country: 'serbia',
    allergens: [],
    isActivated: false,
    isBlocked: false,
    medicalPermits: [],
    medical: {
      personalId: '',
      patientId: '',
      bloodType: 'A+',
      profession: '',
      doctorId: '',
      height: 170,
      weight: 60,
      patient: null,
      doctor: null
    }
  }

  image: any;
  imageUrl: any;

  repeatPassword: string = ''

  registrationForm: FormGroup = new FormGroup({
    usernameControl: new FormControl(this.patient.username, [
      Validators.required,
      Validators.pattern('^(?=[a-zA-Z0-9._]{4,20}$)(?!.*[_.]{2})[^_.].*[^_.]$')
    ]),
    passwordControl: new FormControl(this.patient.password, [
      Validators.required,
      Validators.pattern('^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,40}$')
    ]),
    nameControl: new FormControl(this.patient.name, [
      Validators.required,
      Validators.pattern(XRegExp('^\\p{Lu}[\\p{Ll}]+$', 'u')),
      Validators.maxLength(30)
    ]),
    parentNameControl: new FormControl(this.patient.parentName,
      [
        Validators.required,
        Validators.pattern(XRegExp('^\\p{Lu}[\\p{Ll}]+$', 'u')),
        Validators.maxLength(30)
      ]),
    surnameControl: new FormControl(this.patient.surname, [
      Validators.required,
      Validators.pattern(XRegExp('^\\p{Lu}[\\p{Ll}]+$', 'u')),
      Validators.maxLength(30)
    ]),
    dateOfBirthControl: new FormControl(this.patient.dateOfBirth, [
      Validators.required
    ]),
    genderControl: new FormControl(this.patient.gender, [
      Validators.required
    ]),
    phoneControl: new FormControl(this.patient.phone, [
      Validators.required,
      Validators.pattern('^(\\+\\d{3})?\\d{8,10}$')
    ]),
    emailControl: new FormControl(this.patient.email, [
      Validators.required,
      Validators.email,
      Validators.maxLength(254)
    ]),
    addressControl: new FormControl(this.patient.address, [
      Validators.required,
      Validators.minLength(4),
      Validators.maxLength(50),
      Validators.pattern(XRegExp('^[\\p{L}\\s,0-9\\/-]+$', 'u'))
    ]),
    cityControl: new FormControl(this.patient.city, [
      Validators.required
    ]),
    countryControl: new FormControl(this.countries[0], [
      Validators.required
    ]),
    personalIdControl: new FormControl(this.patient.medical.personalId, [
      Validators.required,
      Validators.pattern('\\d{13}')
    ]),
    bloodTypeControl: new FormControl(this.patient.medical.bloodType, [
      Validators.required
    ]),
    professionControl: new FormControl(this.patient.medical.profession, [
      Validators.required,
      Validators.minLength(3),
      Validators.maxLength(100),
      Validators.pattern(XRegExp('^[\\p{L}\\s,\\/-]+$', 'u'))
    ]),
    doctorControl: new FormControl(this.patient.medical.doctorId[0], [
      Validators.required
    ]),
    heightControl: new FormControl(this.patient.medical.height, [
      Validators.required,
      Validators.min(50),
      Validators.max(280)
    ]),
    weightControl: new FormControl(this.patient.medical.weight, [
      Validators.required,
      Validators.min(30),
      Validators.max(650)
    ]),
    confirmPasswordControl: new FormControl(this.repeatPassword, [
      Validators.required,
      Validators.pattern(this.repeatPassword),
    ]),
    allergensControl: new FormControl(this.patient.allergens, [
    ]),
    imgControl: new FormControl([
    ]),
  });

  get name() { return this.registrationForm.get('nameControl') }
  get parentName() { return this.registrationForm.get('parentNameControl') }
  get surname() { return this.registrationForm.get('surnameControl') }
  get personalId() { return this.registrationForm.get('personalIdControl') }
  get dateOfBirth() { return this.registrationForm.get('dateOfBirthControl') }
  get phone() { return this.registrationForm.get('phoneControl') }
  get address() { return this.registrationForm.get('addressControl') }
  get profession() { return this.registrationForm.get('professionControl') }
  get username() { return this.registrationForm.get('usernameControl') }
  get email() { return this.registrationForm.get('emailControl') }
  get password() { return this.registrationForm.get('passwordControl') }
  get confirmPassword() { return this.registrationForm.get('confirmPasswordControl') }
  get height() { return this.registrationForm.get('heightControl') }
  get weight() { return this.registrationForm.get('weightControl') }

  constructor(private registrationService: RegistrationService, private modalService: NgbModal,
    private toastr: ToastrService, private router: Router, private profileService: ProfileService) { }

  ngOnInit(): void {
    this.configDatePicker()
    this.registrationService.getCitiesForCountry(this.patient.country).subscribe({
      next: c => {
        this.cities = c.data
        this.cities = this.cities.sort()
      }, error: e => (console.log(e))
    })
    this.registrationService.getAllergens().subscribe({
      next: a => {
        this.allergens = a
      }, error: e => (console.log(e))
    })
    this.registrationService.getDoctors().subscribe({
      next: d => {
        this.doctors = d
        this.registrationForm.get('doctorControl')?.setValue(d[0])
      }, error: e => (console.log(e))
    })

    this.onPasswordChanges();
  }

  configDatePicker(): void {
    this.maxDate = moment(Date.now()).subtract(18, 'years');
    this.minDate = moment({ year: 1900, month: 1, day: 1 })
    this.startDate = moment(Date.now()).subtract(21, 'years');
  }

  isDisabled = (date: NgbDate) =>
    moment({ year: date.year, month: date.month, day: date.day }).isAfter(moment().subtract(18, 'years'));

  onPasswordChanges(): void {
    this.registrationForm.get('passwordControl')?.valueChanges.subscribe(val => {
      if (XRegExp.test(val, XRegExp('^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,40}$'))) {
        this.registrationForm.get('confirmPasswordControl')?.setValidators([Validators.required, Validators.pattern(val)]);
        this.registrationForm.get('confirmPasswordControl')?.updateValueAndValidity();
      }
      else {
        this.registrationForm.get('confirmPasswordControl')?.setErrors({ 'incorrect': true })
      }
    });
  }

  updateCities(): void {
    this.registrationService.getCitiesForCountry(this.registrationForm.get('countryControl')?.value).subscribe({
      next: c => {
        this.cities = c.data
        this.cities = this.cities.sort()
      }, error: e => (console.log(e))
    })
  }

  onDateSelect(event: any): void {
    this.registrationForm.get('dateOfBirthControl')?.setValue(`${event.day}-${event.month}-${event.year}`)
  }

  register(): void {
    if (this.registrationForm.invalid) {
      this.showError('Form is invalid!');
      return;
    }
    let bloodType = this.registrationForm.get('bloodTypeControl')?.value;

    if (bloodType === 'A+') bloodType = 'A_positive'
    else if (bloodType === 'A-') bloodType = 'A_negative'
    else if (bloodType === 'B+') bloodType = 'B_positive'
    else if (bloodType === 'B-') bloodType = 'B_negative'
    else if (bloodType === 'AB+') bloodType = 'AB_positive'
    else if (bloodType === 'AB-') bloodType = 'AB_negative'
    else if (bloodType === 'O+') bloodType = 'O_positive'
    else if (bloodType === 'O-') bloodType = 'O_negative'

    let doctor: any = this.registrationForm.get('doctorControl')?.value;

    let medicalRecord: MedicalRecord = {
      bloodType: bloodType,
      profession: this.registrationForm.get('professionControl')?.value,
      doctorId: doctor.id,
      height: this.registrationForm.get('heightControl')?.value,
      weight: this.registrationForm.get('weightControl')?.value,
      personalId: this.registrationForm.get('personalIdControl')?.value,
      patientId: this.registrationForm.get('usernameControl')?.value,
      patient: null,
      doctor: null
    }

    let date: string = this.registrationForm.get('dateOfBirthControl')?.value
    let dateParts = date.split('-');

    let patient: Patient = {
      loginType: 'patient',
      allergens: this.registrationForm.get('allergensControl')?.value,
      username: this.registrationForm.get('usernameControl')?.value,
      password: this.registrationForm.get('passwordControl')?.value,
      name: this.registrationForm.get('nameControl')?.value,
      parentName: this.registrationForm.get('parentNameControl')?.value,
      surname: this.registrationForm.get('surnameControl')?.value,
      dateOfBirth: `${dateParts[1]}-${dateParts[0]}-${dateParts[2]}`,
      gender: this.registrationForm.get('genderControl')?.value,
      phone: this.registrationForm.get('phoneControl')?.value,
      email: this.registrationForm.get('emailControl')?.value,
      address: this.registrationForm.get('addressControl')?.value,
      city: this.registrationForm.get('cityControl')?.value,
      country: this.registrationForm.get('countryControl')?.value,
      isActivated: false,
      isBlocked: false,
      medical: medicalRecord,
      medicalPermits: []
    }

    this.saveImage()
    this.registrationService.register(patient).subscribe({
      next: c => {
        console.log(c)
        if (c.statusText === 'OK') {
          this.toastr.success('Verification email has been sent! Redirecting to home page');
          this.registrationForm.reset();
          setTimeout(() => { this.router.navigate(['/']); }, 5000);
        }
      }, error: e => this.showError('An error occured.')
    })
  }

  showSuccess(message: string) {
    this.toastr.success(message);
  }

  showError(message: string) {
    this.toastr.error(message);
  }

  handleFileInput(e: File[]) {
    this.image = e[0];
    console.log(this.image)
    this.updateImage(e);
  }

  updateImage(e: any) {
    let self = this;
    var reader = new FileReader();
    reader.readAsDataURL(e[0]); // read file as data url
    reader.onload = (event) => { // called once readAsDataURL is completed
      if (event.target != null) {
        self.imageUrl = event.target.result;
      }
    }
  }

  saveImage() {
    if (this.image == null) return
    this.profileService.postFile(this.image, this.registrationForm.get('usernameControl')?.value).subscribe(data => {
      this.showSuccess("Successfully saved image!");
    }, error => {
      this.showError("Error while saving image, please check format!")
    });
  }
}
