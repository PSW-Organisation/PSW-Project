import { formatDate } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ProfileService } from '../profile/profile.service';
import { Prescription } from './prescription';

@Component({
  selector: 'app-prescription',
  templateUrl: './prescription.component.html',
  styleUrls: ['./prescription.component.css']
})
export class PrescriptionComponent implements OnInit {

  @Input('prescriptionId') reportId: number = 0;

  prescription: Prescription | null = null;

  prescriptionForm = new FormGroup({
    dateControl: new FormControl(this.prescription?.date),
    diagnosisControl: new FormControl(this.prescription?.diagnosis),
    medicineControl: new FormControl(this.prescription?.medicine),
    quantityControl: new FormControl(this.prescription?.quantity),
    recommendedDoseControl: new FormControl(this.prescription?.recommendedDose)
  });

  constructor(private modalService: NgbModal, private profileService: ProfileService) { }
  

  ngOnInit(): void {
    this.profileService.getPreciption(this.reportId).subscribe({
      next: response => {
        this.prescription = response.body
        if(this.prescription)
          this.prescriptionForm.get('dateControl')?.setValue(formatDate(this.prescription.date, 'dd.MM.yyyy. HH:mm', 'en-US'))
          this.prescriptionForm.get('medicineControl')?.setValue(this.prescription?.medicine)
          this.prescriptionForm.get('quantityControl')?.setValue(this.prescription?.quantity)
          this.prescriptionForm.get('recommendedDoseControl')?.setValue(this.prescription?.recommendedDose)
          this.prescriptionForm.get('diagnosisControl')?.setValue(this.prescription?.diagnosis)
      }, error: e => { this.prescription = null }
    })
  }

  open(content: any) {
    this.modalService.open(content, { scrollable: true })
  }

}  
