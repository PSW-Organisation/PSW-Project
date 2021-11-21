import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { RegistrationService } from './registration.service';
import { User } from './user';
import { Allergen } from './allergen';
import { Doctor } from './doctor';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  countries: string[] = ['serbia', 'bosnia and herzegovina', 'montenegro']
  bloodTypes: string[] = ['A+', 'A-', 'B+', 'B-', 'AB+', 'AB-', 'O+', 'O-']
  cities: string[] = []
  allergens: Allergen[] = []
  doctors: Doctor[] = []

  settings = {
    singleSelection: false,
    text: "Select allergens*",
    selectAllText: 'Select all',
    unSelectAllText: 'Unselect all',
    enableSearchFilter: true,
    labelKey: 'name',
    primaryKey: 'id'
  };

  user: User = {
    username: '',
    password: '',
    name: '',
    parentName: '',
    surname: '',
    dateOfBirth: new Date(Date.now()),
    gender: '',
    phone: '',
    email: '',
    address: '',
    city: 'Ada',
    country: 'serbia',
    personalId: '',
    bloodType: 'A+',
    profession: '',
    doctor: '',
    height: 0,
    weight: 0,
    allergens: []
  }

  confirmPassword: string = ''

  registrationForm = new FormGroup({
    usernameControl: new FormControl(this.user.username, [
      Validators.required
    ]),
    passwordControl: new FormControl(this.user.password, [
      Validators.required
    ]),
    nameControl: new FormControl(this.user.name, [
      Validators.required,
      Validators.pattern('^[a-zA-Z]+$'),
      Validators.minLength(2),
      Validators.maxLength(30)
    ]),
    parentNameControl: new FormControl(this.user.parentName,
      [
        Validators.required,
        Validators.pattern('^[a-zA-Z]+$'),
        Validators.minLength(2),
        Validators.maxLength(30)
      ]),
    surnameControl: new FormControl(this.user.surname, [
      Validators.required,
      Validators.pattern('^[a-zA-Z]+$'),
      Validators.minLength(2),
      Validators.maxLength(30)
    ]),
    dateOfBirthControl: new FormControl(this.user.dateOfBirth, [
      Validators.required
    ]),
    genderControl: new FormControl(this.user.gender, [
      Validators.required
    ]),
    phoneControl: new FormControl(this.user.phone, [
      Validators.required
    ]),
    emailControl: new FormControl(this.user.email, [
      Validators.required,
      Validators.minLength(4),
      Validators.email,
      Validators.maxLength(40)
    ]),
    addressControl: new FormControl(this.user.address, [
      Validators.required
    ]),
    cityControl: new FormControl(this.user.city, [
      Validators.required
    ]),
    countryControl: new FormControl(this.countries[0], [
      Validators.required
    ]),
    personalIdControl: new FormControl(this.user.personalId, [
      Validators.required
    ]),
    bloodTypeControl: new FormControl(this.user.bloodType, [
      Validators.required
    ]),
    professionControl: new FormControl(this.user.profession, [
      Validators.required
    ]),
    doctorControl: new FormControl(this.user.doctor[0], [
      Validators.required
    ]),
    heightControl: new FormControl(this.user.height, [
      Validators.required
    ]),
    weightControl: new FormControl(this.user.weight, [
      Validators.required
    ]),
    confirmPasswordControl: new FormControl(this.confirmPassword, [
      Validators.required
    ]),
    allergensControl: new FormControl(this.user.allergens, [
      Validators.required
    ])

  });

  constructor(private registrationService: RegistrationService, private modalService: NgbModal,
    private toastr: ToastrService) { }

  ngOnInit(): void {
    this.registrationService.getCitiesForCountry(this.user.country).subscribe({
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
  }

  updateCities(): void {
    this.registrationService.getCitiesForCountry(this.registrationForm.get('countryControl')?.value).subscribe({
      next: c => {
        this.cities = c.data
        this.cities = this.cities.sort()
      }, error: e => (console.log(e))
    })
  }

  register(): void {

  }

  onItemSelect(item: any) {
    console.log(item);
    console.log(this.user.allergens);
  }
  onItemDeselect(item: any) {
    console.log(item);
    console.log(this.user.allergens);
  }
  onSelectAll(items: any) {
    console.log(items);
  }
  onDeselectAll(items: any) {
    console.log(items);
  }


  showSuccess(message: string) {
    this.toastr.success(message);
  }

  showError(message: string) {
    this.toastr.error(message);
  }
}
