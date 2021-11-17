import { Component, OnInit, AfterViewInit } from '@angular/core';
import { Feedback } from '../feedback/feedback';
import { FeedbackService } from '../feedback/feedback.service';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { switchMap } from 'rxjs/operators';
import { RegistrationService } from '../registration/registration.service';
import { ToastrService } from 'ngx-toastr';
import { Location } from '@angular/common';

@Component({
  selector: 'app-welcome',
  templateUrl: './welcome.component.html',
  styleUrls: ['./welcome.component.css']
})
export class WelcomeComponent implements OnInit, AfterViewInit {

  feedbacks: Array<Feedback> = [];
  token: string = '';
  constructor(private feedbackService: FeedbackService, private route: ActivatedRoute,
    private regitrationService: RegistrationService, private toastr: ToastrService, private location: Location) { }
  ngAfterViewInit(): void {
    this.getAllFeedbacks();
  }

  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      this.token = params['token'];
    });
    if (this.token !== undefined) {
      this.regitrationService.activate(this.token).subscribe({
        next: response => {
          this.toastr.success('Your account has been activated!');
        }, error: e => {
          if (e.statusText === 'Not Found')
            this.showError('Invalid activation token.')
          else this.showError('Your account is already activated.')
        }
      })
      this.location.replaceState('/')
    }
  }

  getAllFeedbacks(): void {
    this.feedbackService.getAllFeedbacks().subscribe(feedbacks => this.feedbacks = feedbacks.filter(f => f.isPublished == true),
      error => console.log(error));
  }

  showSuccess(message: string) {
    this.toastr.success(message);
  }

  showError(message: string) {
    this.toastr.error(message);
  }
}
