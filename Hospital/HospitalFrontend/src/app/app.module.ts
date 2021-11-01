import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PecurkaComponent } from './pecurka/pecurka.component';
import { ConfigService } from './config/config.service';
import { FeedbackComponent } from './feedback/feedback.component';
import { RouterModule } from '@angular/router';
import { FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { LottieModule } from 'ngx-lottie';
import player from 'lottie-web';
import { WelcomeComponent } from './welcome/welcome.component';
import { ToastrModule } from 'ngx-toastr';

export function playerFactory() {
  return player;
}

@NgModule({
  declarations: [
    AppComponent,
    PecurkaComponent,
    FeedbackComponent,
    WelcomeComponent
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
      { path: '', component: WelcomeComponent},
      { path: 'feedback', component: FeedbackComponent}
    ]), 
    NgbModule,
    LottieModule.forRoot({ player: playerFactory }),
  ],
  providers: [ConfigService],
  bootstrap: [AppComponent]
})
export class AppModule { }
