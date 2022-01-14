import { Component } from "@angular/core";
import { ToastrService } from "ngx-toastr";
import { Feedback } from "./feedback";
import { FeedbackService } from "./feedback.service";

@Component({
    selector: 'feedback',
    templateUrl: './feedback.component.html',
    styleUrls: ['./feedback.component.css']
  })

export class FeedBackComponent {
        feedbacks: Array<Feedback> = [];

        constructor(private service: FeedbackService, private toastr: ToastrService){}
        
        ngOnInit(): void {
            this.getAllFeedbacks();
        }

        publishFeedback(feedback: Feedback): void {
            feedback.isPublished = !feedback.isPublished;
            this.service.publishFeedback(feedback, feedback.id).subscribe(response =>{ 
              if(response.status === 200){
                this.toastr.success("Request successful!");
              }else{
                feedback.isPublished = !feedback.isPublished;
                this.toastr.error("Request failed")
              }
            })
        }
        
        getAllFeedbacks(): void{ 
            this.service.getAllFeedbacks().subscribe(feedbacks => {
              this.feedbacks = feedbacks
              this.feedbacks = this.feedbacks.sort((a, b) => a.id - b.id)
            }, 
              error => console.log(error));
          }
    }