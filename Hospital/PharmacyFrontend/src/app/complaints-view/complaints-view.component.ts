import { Component, OnInit } from '@angular/core';
import { IComplaint } from './complaint';
import { ComplaintsService } from './complaint.service';


@Component({
  selector: 'app-complaints-view',
  templateUrl: './complaints-view.component.html',
  styleUrls: ['./complaints-view.component.css']
})
export class ComplaintsViewComponent implements OnInit {
  complaints: IComplaint[]=[]
  complaint: any
  response:any = {  responseId: 0, date: "2021-11-05T18:42:03.155742", content: "", complaintId: 0}
  errorMessage: string = ""

  constructor(private _complaintService: ComplaintsService) { }

  ngOnInit(): void {

   this.loadComplaints();
  }

  loadComplaints() {
    this._complaintService.getComplaints().subscribe(
      complaints => {
        this.complaints = complaints;
      }
    );
  }
  deleteComplaint(complaint: any){
    this._complaintService.deleteComplaint(complaint).subscribe( data =>  this.loadComplaints());
  
    
  }

  responseToComplaint(complaintId: any){
    this.response.complaintId = complaintId;
    this._complaintService.sendResponse(this.response)
  }
}
