import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { WelcomeComponent } from './welcome/welcome.component';
import { HospitalExteriorViewComponent } from './room-managment/hospital-exterior-view/hospital-exterior-view.component';
import { PharmaciesViewComponent } from './pharmacies-view/pharmacies-view.component';
import { EditPharmacyComponent } from './edit-pharmacy/edit-pharmacy.component';
import { ComplaintsViewComponent } from './complaints-view/complaints-view.component';
import { ComplaintDetailComponent } from './complaint-detail/complaint-detail.component';
import { SurveyComponent } from './survey/survey.component';
import { PharmaciesService } from './pharmacies-view/pharmacies.service';
import { EditPharmacyService } from './edit-pharmacy/edit-pharmacy.service';

import { FeedBackComponent } from './feedback/feedback.component';
import { MatButtonToggleModule } from '@angular/material/button-toggle';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { FormsModule, ReactiveFormsModule } from '@angular/forms'; 
import { FeedbackService } from './feedback/feedback.service';
import { OrderingMedicineComponent } from './ordering-medicine/ordering-medicine.component';
import { SearchPharmaciesPipe } from './ordering-medicine/search-pharmacies.pipe';
import { RoomManagmentModule } from './room-managment/room-managment.module';
import { MedicineConsumptionComponent } from './medicine-consumption/medicine-consumption.component';

import { BenefitsViewComponent } from './benefits-view/benefits-view.component';
import { SurveyService } from './survey/survey.service';
import { ReportsViewComponent } from './reports-view/reports-view.component';

@NgModule({
  declarations: [
    AppComponent,
    WelcomeComponent,
    EditPharmacyComponent,
    ComplaintsViewComponent,
    ComplaintDetailComponent,
    HospitalExteriorViewComponent,
    PharmaciesViewComponent,
    FeedBackComponent,
    OrderingMedicineComponent,
    SearchPharmaciesPipe,
    MedicineConsumptionComponent,
    BenefitsViewComponent,
    SurveyComponent,
    ReportsViewComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    RoomManagmentModule
  ],
  providers: [
    PharmaciesService,
    FeedbackService,
    EditPharmacyService,
    SurveyService
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
