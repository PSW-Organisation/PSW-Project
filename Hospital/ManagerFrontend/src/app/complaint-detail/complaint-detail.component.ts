import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { IComplaint } from '../complaints-view/complaint';

import { ComplaintDetailService } from './complaint-detail.service';

@Component({
  selector: 'app-complaint-detail',
  templateUrl: './complaint-detail.component.html',
  styleUrls: ['./complaint-detail.component.css']
})
export class ComplaintDetailComponent implements OnInit {

  complaint: IComplaint | undefined;
  errorMessage: string = ""

  constructor(private route: ActivatedRoute,
              private router: Router,
              private complaintDetailService: ComplaintDetailService) { }

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    if(id) {
      this.getComplaint(id);
    }
  }

  getComplaint(id: number): void {
    this.complaintDetailService.getComplaint(id).subscribe({
      next: complaint => this.complaint = complaint,
      error: err => this.errorMessage = err
    });
  }

  onBack(): void {
    this.router.navigate(['/complaints']);
  }
}

