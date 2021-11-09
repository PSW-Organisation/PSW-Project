import { Component, OnInit, AfterViewInit } from '@angular/core';
import { Feedback } from '../feedback/feedback';
import { FeedbackService } from '../feedback/feedback.service';

@Component({
  selector: 'app-welcome',
  templateUrl: './welcome.component.html',
  styleUrls: ['./welcome.component.css']
})
export class WelcomeComponent implements OnInit, AfterViewInit {

  feedbacks: Array<Feedback> = [];
  constructor(private feedbackService: FeedbackService) { }
  ngAfterViewInit(): void {
    this.getAllFeedbacks();
  }

  ngOnInit(): void {
  }

  getAllFeedbacks(): void{ 
    this.feedbackService.getAllFeedbacks().subscribe(feedbacks => this.feedbacks = feedbacks.filter(f => f.isPublished == true), 
      error => console.log(error));
  }
}
