import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PecurkaComponent } from './pecurka/pecurka.component';
import { ConfigService } from './config/config.service';
import { FeedbackComponent } from './feedback/feedback.component';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { LottieModule } from 'ngx-lottie';
import player from 'lottie-web';
import { WelcomeComponent } from './welcome/welcome.component';

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
    AppRoutingModule,
    HttpClientModule,
    FormsModule , 
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
