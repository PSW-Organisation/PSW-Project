import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { WelcomeComponent } from './welcome/welcome.component';
import { ComplaintsViewComponent } from './complaints-view/complaints-view.component';
import { HospitalViewComponent} from './hospital-view/hospital-view.component'
import { ReportsViewComponent } from './reports-view/reports-view.component';

const routes: Routes = [
{ path: '', component: WelcomeComponent },
{ path: 'complaints', component: ComplaintsViewComponent},
{ path: 'hospitals', component: HospitalViewComponent},
{ path: 'reports', component: ReportsViewComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
