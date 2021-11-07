import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PharmaciesViewComponent } from './pharmacies-view/pharmacies-view.component';
import { BuildingFloorsComponent } from './building-floors/building-floors.component';
import { HospitalExteriorViewComponent } from './hospital-exterior-view/hospital-exterior-view.component';
import { WelcomeComponent } from './welcome/welcome.component';
import { ComplaintsViewComponent } from './complaints-view/complaints-view.component';
import { ComplaintDetailComponent } from './complaint-detail/complaint-detail.component';

const routes: Routes = [
  { path: '', component: WelcomeComponent},
  { path: 'pharmacies', component: PharmaciesViewComponent },
  { path: 'building/:buidingId/floor/:id', component: BuildingFloorsComponent },
  { path: 'hospitalExterior', component: HospitalExteriorViewComponent },
  { path: 'complaints', component: ComplaintsViewComponent},
  { path: 'complaint/:id', component: ComplaintDetailComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
