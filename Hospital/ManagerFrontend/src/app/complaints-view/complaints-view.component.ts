import { Component, OnInit } from '@angular/core';
import { IComplaint } from './complaint';
import { ComplaintsService } from './complaints.service';

@Component({
  selector: 'app-complaints-view',
  templateUrl: './complaints-view.component.html',
  styleUrls: ['./complaints-view.component.css']
})
export class ComplaintsViewComponent implements OnInit {
  complaints: IComplaint[] = []
  errorMessage: string = ""

  constructor(private _complaintsService: ComplaintsService) { }

  ngOnInit(): void {
    this.refreshComplaints();
  }


  refreshComplaints() {
    this._complaintsService.getComplaints().subscribe(
      complaints => {
        this.complaints = complaints;
      },
      error => this.errorMessage = <any> error
    );
  }
}
