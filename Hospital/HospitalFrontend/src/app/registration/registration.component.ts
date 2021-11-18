import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { RegistrationService } from './registration.service';
import { User } from './user';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  countries: string[] = ['serbia', 'bosnia and herzegovina', 'montenegro']
  bloodTypes: string[] = ['A+', 'A-', 'B+', 'B-', 'AB+', 'AB-', 'O+', 'O-']
  cities: string[] = []

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
    weight: 0
  }

  confirmPassword: string = ''

  registrationForm = new FormGroup({
    usernameControl: new FormControl(this.user.username),
    passwordControl: new FormControl(this.user.password),
    nameControl: new FormControl(this.user.name),
    parentNameControl: new FormControl(this.user.parentName),
    surnameControl: new FormControl(this.user.surname),
    dateOfBirthControl: new FormControl(this.user.dateOfBirth),
    genderControl: new FormControl(this.user.gender),
    phoneControl: new FormControl(this.user.phone),
    emailControl: new FormControl(this.user.email),
    addressControl: new FormControl(this.user.address),
    cityControl: new FormControl(this.user.city),
    countryControl: new FormControl(this.countries[0]),
    personalIdControl: new FormControl(this.user.personalId),
    bloodTypeControl: new FormControl(this.user.bloodType),
    professionControl: new FormControl(this.user.profession),
    doctorControl: new FormControl(this.user.doctor),
    heightControl: new FormControl(this.user.height),
    weightControl: new FormControl(this.user.weight),
    confirmPasswordControl: new FormControl(this.confirmPassword),
  });

  constructor(private service: RegistrationService, private modalService: NgbModal,
    private toastr: ToastrService) { }

  ngOnInit(): void {
    this.service.getCitiesForCountry(this.user.country).subscribe({
      next: c => {
        this.cities = c.data
        this.cities = this.cities.sort()
      }, error: e => (console.log(e))
    })
  }

  updateCities() : void {
    this.service.getCitiesForCountry(this.registrationForm.get('countryControl')?.value).subscribe({
      next: c => {
        this.cities = c.data
        this.cities = this.cities.sort()
      }, error: e => (console.log(e))
    })
  }

  register(): void {

  }



  showSuccess(message: string) {
    this.toastr.success(message);
  }

  showError(message: string) {
    this.toastr.error(message);
  }
}
