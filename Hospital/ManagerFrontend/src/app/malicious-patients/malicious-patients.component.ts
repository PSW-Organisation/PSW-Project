import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Patient } from './patient';
import { PatientService } from './patient.service';

@Component({
  selector: 'app-malicious-patients',
  templateUrl: './malicious-patients.component.html',
  styleUrls: ['./malicious-patients.component.css']
})
export class MaliciousPatientsComponent implements OnInit {
  patients: Patient[] = []
  constructor(private paitentService: PatientService, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.getMaliciousPatients();
  }

  getMaliciousPatients() {
    this.paitentService.getMaliciousPatients().subscribe({
      next: p => {
        p.forEach((element: any ): void => {
          let patient = <Patient>{
            username: element.username,
            fullName: element.fullName,
            phone: element.phone,
            email: element.email,
            isBlocked: element.isBlocked
          }
          this.patients.push(patient)
        });
      }, error: e => (console.log(e))
    })
  }

  blockPatient(patient: Patient): void{
    this.paitentService.blockPatient(patient.username).subscribe({ 
      next: response => {
          patient.isBlocked = true;
          this.toastr.success('Successfully blocked malicious patient.');
      }, error: e => (this.toastr.error('An error occured.'))
    })
  }
}
