import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Patient } from '../registration/patient';
import { ActivatedRoute, Router } from '@angular/router';
import { ProfileService } from './profile.service';
import { formatDate } from '@angular/common';
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  settings = {
    singleSelection: false,
    text: "Select allergens",
    selectAllText: 'Select all',
    unSelectAllText: 'Unselect all',
    enableSearchFilter: true,
    labelKey: 'name',
    primaryKey: 'id',
    disabled: true
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

  profile: FormGroup = new FormGroup({
    usernameControl: new FormControl(this.patient.username, [
    ]),
    // passwordControl: new FormControl(this.patient.password, [
    // ]),
    nameControl: new FormControl(this.patient.name, [
    ]),
    parentNameControl: new FormControl(this.patient.parentName, [
    ]),
    surnameControl: new FormControl(this.patient.surname, [
    ]),
    dateOfBirthControl: new FormControl(this.patient.dateOfBirth, [
    ]),
    genderControl: new FormControl(this.patient.gender, [
    ]),
    phoneControl: new FormControl(this.patient.phone, [
    ]),
    emailControl: new FormControl(this.patient.email, [
    ]),
    addressControl: new FormControl(this.patient.address, [
    ]),
    cityControl: new FormControl(this.patient.city, [
    ]),
    countryControl: new FormControl(this.patient.country, [
    ]),
    personalIdControl: new FormControl(this.patient.medical.personalId, [
    ]),
    bloodTypeControl: new FormControl(this.patient.medical.bloodType, [
    ]),
    professionControl: new FormControl(this.patient.medical.profession, [
    ]),
    doctorControl: new FormControl(this.patient.medical.doctorId, [
    ]),
    heightControl: new FormControl(this.patient.medical.height, [
    ]),
    weightControl: new FormControl(this.patient.medical.weight, [
    ]),
    // confirmPasswordControl: new FormControl(this.repeatPassword, [
    // ]),
    allergensControl: new FormControl(this.patient.allergens, [
    ])
  });

  constructor(private route: ActivatedRoute, private profileService: ProfileService, 
    private toastr: ToastrService, private router: Router) { }

  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      if (params['username'])
        this.profileService.getProfileData(params['username']).subscribe({
          next: response => {
            this.patient = response
            this.patient.allergens = this.patient.medical.patient.patientAllergens
              .flatMap((a: { allergen: any; }) => a.allergen);
            this.updateControls();
            this.profile.disable();
          }, error: e => { 
            this.router.navigate(['/'])
            this.showError('An error has occured.')
          }
        })
    });
  }

  updateControls(): void {
    this.profile.get('usernameControl')?.setValue(this.patient.username)
    this.profile.get('nameControl')?.setValue(this.patient.name)
    this.profile.get('parentNameControl')?.setValue(this.patient.parentName)
    this.profile.get('surnameControl')?.setValue(this.patient.surname)
    this.profile.get('genderControl')?.setValue(this.patient.gender)
    this.profile.get('phoneControl')?.setValue(this.patient.phone)
    this.profile.get('emailControl')?.setValue(this.patient.email)
    this.profile.get('addressControl')?.setValue(this.patient.address)
    this.profile.get('cityControl')?.setValue(this.patient.city)
    this.profile.get('countryControl')?.setValue(this.patient.country)
    const bloodTypeControl = this.profile.get('bloodTypeControl')
    switch (this.patient.medical.bloodType.toString()) {
      case '0': { bloodTypeControl?.setValue('A+'); break }
      case '1': { bloodTypeControl?.setValue('A-'); break }
      case '2': { bloodTypeControl?.setValue('B+'); break }
      case '3': { bloodTypeControl?.setValue('B-'); break }
      case '4': { bloodTypeControl?.setValue('AB+'); break }
      case '5': { bloodTypeControl?.setValue('AB-'); break }
      case '6': { bloodTypeControl?.setValue('O+'); break }
      default: bloodTypeControl?.setValue('O-')
    }
    this.patient.medical.bloodType = bloodTypeControl?.value;
    this.profile.get('professionControl')?.setValue(this.patient.medical.profession)
    this.profile.get('heightControl')?.setValue(this.patient.medical.height)
    this.profile.get('weightControl')?.setValue(this.patient.medical.weight)
    this.profile.get('personalIdControl')?.setValue(this.patient.medical.personalId)
    this.profile.get('doctorControl')?.setValue(this.patient.medical.doctorId)
  }

  showSuccess(message: string) {
    this.toastr.success(message);
  }

  showError(message: string) {
    this.toastr.error(message);
  }

}
