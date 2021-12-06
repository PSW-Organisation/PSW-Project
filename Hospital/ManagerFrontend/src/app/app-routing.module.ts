import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PharmaciesViewComponent } from './pharmacies-view/pharmacies-view.component';

import { FeedBackComponent } from './feedback/feedback.component'
import { WelcomeComponent } from './welcome/welcome.component';
import { ComplaintsViewComponent } from './complaints-view/complaints-view.component';
import { ComplaintDetailComponent } from './complaint-detail/complaint-detail.component';
import { OrderingMedicineComponent } from './ordering-medicine/ordering-medicine.component';
import { MedicineConsumptionComponent } from './medicine-consumption/medicine-consumption.component';
import { HospitalExteriorViewComponent } from './room-managment/hospital-exterior-view/hospital-exterior-view.component';
import { SurveyComponent } from './survey/survey.component';
import { EditPharmacyComponent } from './edit-pharmacy/edit-pharmacy.component';
import { PharmacyProfileComponent } from './pharmacy-profile/pharmacy-profile.component';

import { BenefitsViewComponent } from './benefits-view/benefits-view.component';
import { ReportsViewComponent } from './reports-view/reports-view.component';
import { NotificationsComponent } from './notifications/notifications.component';

const routes: Routes = [
  { path: '', component: WelcomeComponent },
  { path: 'pharmacies', component: PharmaciesViewComponent },
  { path: 'complaints', component: ComplaintsViewComponent },
  { path: 'complaint/:id', component: ComplaintDetailComponent },
  { path: 'feedback', component: FeedBackComponent },
  { path: 'hospitalExterior', component: HospitalExteriorViewComponent },
  { path: 'orderingMedicine', component: OrderingMedicineComponent },
  { path: 'createReport', component: MedicineConsumptionComponent},
  { path:'benefits', component: BenefitsViewComponent},
  { path: 'survey', component: SurveyComponent },
  { path: 'reports', component: ReportsViewComponent},
  { path: 'editPharmacy', component: EditPharmacyComponent},
  { path: 'pharmacy/:id', component: PharmacyProfileComponent},
  {path: 'notifications', component: NotificationsComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
