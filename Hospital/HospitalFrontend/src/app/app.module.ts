import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FeedbackService } from './feedback/feedback.service';
import { FeedbackComponent } from './feedback/feedback.component';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { LottieModule } from 'ngx-lottie';
import player from 'lottie-web';
import { WelcomeComponent } from './welcome/welcome.component';
import { ToastrModule } from 'ngx-toastr';
import { RandomUserService } from './random-user/random-user.service';
import { DatePipe, Location } from '@angular/common';
import { RegistrationComponent } from './registration/registration.component';
import { AngularMultiSelectModule } from 'angular2-multiselect-dropdown';
import { SurveyComponent } from './survey/survey.component';

export function playerFactory() {
  return player;
}

@NgModule({
  declarations: [
    AppComponent,
    FeedbackComponent,
    WelcomeComponent,
    RegistrationComponent,
    SurveyComponent
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
      { path: 'feedback', component: FeedbackComponent },
      { path: 'registration', component: RegistrationComponent },
      { path: 'verification', component: WelcomeComponent },
      { path: 'survey', component: SurveyComponent},
      { path: '**', redirectTo: '' },
    ]),
    NgbModule,
    LottieModule.forRoot({ player: playerFactory }),
    AngularMultiSelectModule
  ],
  providers: [FeedbackService, RandomUserService, DatePipe, Location],
  bootstrap: [AppComponent]
})
export class AppModule { }
