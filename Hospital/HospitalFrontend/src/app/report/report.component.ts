import { formatDate } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Feedback } from '../feedback/feedback';
import { ProfileService } from '../profile/profile.service';
import Report from './report';

@Component({
  selector: 'app-report',
  templateUrl: './report.component.html',
  styleUrls: ['./report.component.css']
})
export class ReportComponent implements OnInit {

  @Input('reportId') reportId: number = 0;

  report: Report | null = null;

  reportForm = new FormGroup({
    dateControl: new FormControl(this.report?.date),
    anamnesisControl: new FormControl(this.report?.anamnesis),
    diagnosisControl: new FormControl(this.report?.diagnosis),
    notesControl: new FormControl(this.report?.notes)
  });

  constructor(private modalService: NgbModal, private profileService: ProfileService) { }

  ngOnInit(): void {
    this.profileService.getReport(this.reportId).subscribe({
      next: response => {
        this.report = response.body
        if(this.report)
          this.reportForm.get('dateControl')?.setValue(formatDate(this.report.date, 'dd.MM.yyyy. HH:mm', 'en-US'))
        this.reportForm.get('anamnesisControl')?.setValue(this.report?.anamnesis)
        this.reportForm.get('diagnosisControl')?.setValue(this.report?.diagnosis)
        this.reportForm.get('notesControl')?.setValue(this.report?.notes)
      }, error: e => { this.report = null }
    })
  }

  open(content: any) {
    this.modalService.open(content, { scrollable: true })
  }
}
