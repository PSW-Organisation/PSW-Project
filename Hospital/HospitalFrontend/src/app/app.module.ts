import { NgModule, LOCALE_ID } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FeedbackService } from './feedback/feedback.service';
import { FeedbackComponent } from './feedback/feedback.component';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgbDateAdapter, NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { LottieModule } from 'ngx-lottie';
import player from 'lottie-web';
import { WelcomeComponent } from './welcome/welcome.component';
import { ToastrModule } from 'ngx-toastr';
import { RandomUserService } from './random-user/random-user.service';
import { DatePipe, Location } from '@angular/common';
import { RegistrationComponent } from './registration/registration.component';
import { AngularMultiSelectModule } from 'angular2-multiselect-dropdown';
import { SurveyComponent } from './survey/survey.component';
import { ProfileComponent } from './profile/profile.component';
import { registerLocaleData } from '@angular/common';
import localeSr from '@angular/common/locales/sr-Latn';
import { NgbDateParserFormatter } from '@ng-bootstrap/ng-bootstrap';
import { CustomAdapter, CustomDateParserFormatter } from './shared/services/date-formatter.service';
import { AppointmentsComponent } from './appointments/appointments.component';
import { StepperComponent } from './stepper/stepper.component';
import { RecommendedAppointmentSchedulingComponent } from './recommended-appointment-scheduling/recommended-appointment-scheduling.component';
import { NavbarComponent } from './navbar/navbar.component';

export function playerFactory() {
  return player;
}

@NgModule({
  declarations: [
    AppComponent,
    FeedbackComponent,
    WelcomeComponent,
    RegistrationComponent,
    SurveyComponent,
    ProfileComponent,
    AppointmentsComponent,
    StepperComponent,
    RecommendedAppointmentSchedulingComponent,
    NavbarComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    ToastrModule.forRoot({
      positionClass: 'toast-custom',
      progressBar: true,
      progressAnimation: 'increasing'
    }),
    RouterModule.forRoot([
      { path: '', component: WelcomeComponent },
      { path: 'home', component: WelcomeComponent },
      { path: 'registration', component: RegistrationComponent },
      { path: 'verification', component: WelcomeComponent },
      { path: 'survey', component: SurveyComponent},
      { path: 'profile', component: ProfileComponent },
      { path: 'appointments', component: AppointmentsComponent },
      { path: 'basic-scheduling', component: StepperComponent },
      { path: 'recommended-scheduling', component: RecommendedAppointmentSchedulingComponent },
      { path: '**', redirectTo: '' }
    ]),
    NgbModule,
    LottieModule.forRoot({ player: playerFactory }),
    AngularMultiSelectModule
  ],
  providers: [FeedbackService, RandomUserService, DatePipe, Location, 
    //{ provide: LOCALE_ID, useValue: 'sr-Latn'},
    {provide: NgbDateAdapter, useClass: CustomAdapter},
    {provide: NgbDateParserFormatter, useClass: CustomDateParserFormatter}
  ],
    
  bootstrap: [AppComponent]
})
export class AppModule { }
