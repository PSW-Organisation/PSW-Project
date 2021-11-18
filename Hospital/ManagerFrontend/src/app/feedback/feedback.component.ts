import { Component } from "@angular/core";
import { Feedback } from "./feedback";
import { FeedbackService } from "./feedback.service";

@Component({
    selector: 'feedback',
    templateUrl: './feedback.component.html',
    styleUrls: ['./feedback.component.css']
  })

export class FeedBackComponent {
        feedbacks: Array<Feedback> = [];

        constructor(private service: FeedbackService){}
        
        ngOnInit(): void {
            this.getAllFeedbacks();
        }

        publishFeedback(feedback: Feedback): void {
            feedback.isPublished = !feedback.isPublished;
            this.service.publishFeedback(feedback, feedback.id).subscribe(response =>{ 
              if(response.status === 200){
                alert("SUCESS");
              }else{
                feedback.isPublished = !feedback.isPublished;
                console.log("FAILED");
              }
            })
        }
        
        getAllFeedbacks(): void{ 
            this.service.getAllFeedbacks().subscribe(feedbacks => this.feedbacks = feedbacks, 
              error => console.log(error));
          }
    }