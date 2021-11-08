import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PharmaciesViewComponent } from './pharmacies-view/pharmacies-view.component';
import { HospitalExteriorViewComponent } from './hospital-exterior-view/hospital-exterior-view.component';
import { WelcomeComponent } from './welcome/welcome.component';
import { ComplaintsViewComponent } from './complaints-view/complaints-view.component';
import { ComplaintDetailComponent } from './complaint-detail/complaint-detail.component';

const routes: Routes = [
  { path: '', component: WelcomeComponent },
  { path: 'pharmacies', component: PharmaciesViewComponent },
  { path: 'complaints', component: ComplaintsViewComponent },
  { path: 'complaint/:id', component: ComplaintDetailComponent },
  { path: 'hospitalExterior', component: HospitalExteriorViewComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
