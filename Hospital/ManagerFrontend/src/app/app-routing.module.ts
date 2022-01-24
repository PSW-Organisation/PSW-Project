import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PharmaciesViewComponent } from './pharmacies-view/pharmacies-view.component';

import { FeedBackComponent } from './feedback/feedback.component';
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
import { MaliciousPatientsComponent } from './malicious-patients/malicious-patients.component';
import { ManagerGuard } from './shared/jwt/jwt-guard';
import { TendersComponent } from './tenders/tenders.component';
import { DoctorsComponent } from './doctors/doctors.component';
import { DoctorViewComponent } from './doctor-view/doctor-view.component';
import { HomePageComponent } from './home-page/home-page.component';
import { ScheduleComponent } from './doctor-vacation/schedule/schedule.component';
import { DoctorOnCallShiftComponent } from './doctor-on-call-shift/doctor-on-call-shift.component';
import { ManageShiftsComponent } from './manage-shifts/manage-shifts.component';
import { AddPharmacyComponent } from './add-pharmacy/add-pharmacy.component';

const routes: Routes = [
  { path: '', component: WelcomeComponent },
  { path: 'pharmacies', component: PharmaciesViewComponent, canActivate: [ManagerGuard] },
  { path: 'complaints', component: ComplaintsViewComponent, canActivate: [ManagerGuard] },
  { path: 'complaint/:id', component: ComplaintDetailComponent, canActivate: [ManagerGuard] },
  { path: 'feedback', component: FeedBackComponent, canActivate: [ManagerGuard] },
  { path: 'hospitalExterior', component: HospitalExteriorViewComponent, canActivate: [ManagerGuard] },
  { path: 'orderingMedicine', component: OrderingMedicineComponent, canActivate: [ManagerGuard] },
  { path: 'createReport', component: MedicineConsumptionComponent, canActivate: [ManagerGuard] },
  { path: 'benefits', component: BenefitsViewComponent, canActivate: [ManagerGuard] },
  { path: 'survey', component: SurveyComponent, canActivate: [ManagerGuard] },
  { path: 'reports', component: ReportsViewComponent, canActivate: [ManagerGuard] },
  { path: 'editPharmacy', component: EditPharmacyComponent, canActivate: [ManagerGuard] },
  { path: 'pharmacy/:id', component: PharmacyProfileComponent, canActivate: [ManagerGuard] },
  { path: 'notifications', component: NotificationsComponent, canActivate: [ManagerGuard] },
  { path: 'malicious', component: MaliciousPatientsComponent, canActivate: [ManagerGuard] },
  { path: 'tenders', component: TendersComponent, canActivate: [ManagerGuard] },
  { path: 'doctors', component: DoctorsComponent, canActivate: [ManagerGuard] },
  { path: 'doctorView/:id', component: DoctorViewComponent, canActivate: [ManagerGuard] },
  { path: 'home', component: HomePageComponent, canActivate: [ManagerGuard] },
  { path: 'doctorVacation/:doctorId', component: ScheduleComponent, canActivate: [ManagerGuard] },
  { path: 'doctorOnCallShift', component: DoctorOnCallShiftComponent, canActivate: [ManagerGuard]},
  { path: 'manageShifts', component: ManageShiftsComponent, canActivate: [ManagerGuard]},
  { path: 'addPharmacy', component: AddPharmacyComponent, canActivate: [ManagerGuard] }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
