import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { RoomsViewModule } from './rooms-view/rooms-view.module';

import { AppComponent } from './app.component';
import { WelcomeComponent } from './welcome/welcome.component';
import { HospitalExteriorViewComponent } from './hospital-exterior-view/hospital-exterior-view.component';
import { PharmaciesViewComponent } from './pharmacies-view/pharmacies-view.component';
import { EditPharmacyComponent } from './edit-pharmacy/edit-pharmacy.component';
import { ComplaintsViewComponent } from './complaints-view/complaints-view.component';
import { ComplaintDetailComponent } from './complaint-detail/complaint-detail.component';
import { PharmaciesService } from './pharmacies-view/pharmacies.service';
import { EditPharmacyService } from './edit-pharmacy/edit-pharmacy.service';

import { FeedBackComponent } from './feedback/feedback.component';
import { MatButtonToggleModule } from '@angular/material/button-toggle';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { FormsModule, ReactiveFormsModule } from '@angular/forms'; 
import { FeedbackService } from './service/feedback.service';

@NgModule({
  declarations: [
    AppComponent,
    WelcomeComponent,
    EditPharmacyComponent,
    ComplaintsViewComponent,
    ComplaintDetailComponent,
    HospitalExteriorViewComponent,
    PharmaciesViewComponent,
    FeedBackComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    RoomsViewModule
  ],
  providers: [ 
    PharmaciesService,
    FeedbackService,
    EditPharmacyService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }