import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { IComplaint } from '../complaints-view/complaint';

import { ComplaintDetailService } from './complaint-detail.service';
import { IResponseToComplaint } from './responseToComplaint';

@Component({
  selector: 'app-complaint-detail',
  templateUrl: './complaint-detail.component.html',
  styleUrls: ['./complaint-detail.component.css']
})
export class ComplaintDetailComponent implements OnInit {

  complaint: IComplaint | undefined;
  responses: IResponseToComplaint[] = []
  errorMessage: string = ""
  complaintId: number = 0

  constructor(private route: ActivatedRoute,
              private router: Router,
              private complaintDetailService: ComplaintDetailService) { }

  ngOnInit(): void {
    this.complaintId = Number(this.route.snapshot.paramMap.get('id'));
    if(this.complaintId) {
      this.getComplaint(this.complaintId);
      this.getResponses(this.complaintId);
    }
  }

  getComplaint(id: number): void {
    this.complaintDetailService.getComplaint(id).subscribe({
      next: complaint => this.complaint = complaint,
      error: err => this.errorMessage = err
    });
  }

  getResponses(id: number): void {
    this.complaintDetailService.getResponses().subscribe(
      responses => {
        this.responses = responses.filter(response => response.complaintId == id);
      },
      error => this.errorMessage = <any> error
    )
  }

  onBack(): void {
    this.router.navigate(['/complaints']);
  }

  deleteResponse(id: number){
    if (window.confirm('Are you sure you want to delete this response?')){
      this.complaintDetailService.deleteResponse(id).subscribe( data => {
        this.getResponses(this.complaintId);
      });
    }
  }
}
