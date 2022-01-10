import { Component, OnInit, AfterViewInit } from '@angular/core';
import { Feedback } from '../feedback/feedback';
import { FeedbackService } from '../feedback/feedback.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { switchMap } from 'rxjs/operators';
import { RegistrationService } from '../registration/registration.service';
import { ToastrService } from 'ngx-toastr';
import { Location } from '@angular/common';
import { AuthService } from './auth.service';
import { UserService } from './user.service';
import { ProfileService } from '../profile/profile.service';

@Component({
  selector: 'app-welcome',
  templateUrl: './welcome.component.html',
  styleUrls: ['./welcome.component.css']
})
export class WelcomeComponent implements OnInit, AfterViewInit {

  feedbacks: Array<Feedback> = [];
  token: string = '';
  username: string = '';
  password: string = '';

  constructor(private feedbackService: FeedbackService, private route: ActivatedRoute,
    private regitrationService: RegistrationService, private toastr: ToastrService, 
    private location: Location, private authService: AuthService, private userService: UserService,
    private profileService: ProfileService, private router: Router) { }
  
    
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
      this.location.replaceState('/home')
    }
    this.router.navigate(['/home']);
  }

  getAllFeedbacks(): void {
    this.feedbackService.getAllFeedbacks().subscribe(feedbacks => this.feedbacks = feedbacks.filter(f => f.isPublished == true),
      error => console.log(error));
  }

  login() {
    this.authService.login(this.username, this.password).subscribe(res => {
      this.profileService.getProfileData(this.username).subscribe((res: any) => {
        if (res.loginType === 0) {
          this.router.navigate(['/profile']);
        } else {
         this.showError('Incorrect username or password!')
        }
      });
    });
  }

  showSuccess(message: string) {
    this.toastr.success(message);
  }

  showError(message: string) {
    this.toastr.error(message);
  }
}
