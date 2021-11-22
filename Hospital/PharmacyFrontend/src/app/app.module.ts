import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { WelcomeComponent } from './welcome/welcome.component';
import { HttpClientModule } from '@angular/common/http';
import { RegistrationService } from './welcome/reistration.service';
import { FormsModule } from '@angular/forms';
import { ComplaintsViewComponent } from './complaints-view/complaints-view.component';
import { HospitalViewComponent } from './hospital-view/hospital-view.component';


@NgModule({
  declarations: [
    AppComponent,
    WelcomeComponent,
    ComplaintsViewComponent,
    HospitalViewComponent,
  
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule
  ],
  providers: [ RegistrationService],
  bootstrap: [AppComponent]
})
export class AppModule { }
