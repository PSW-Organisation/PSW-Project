import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { WelcomeComponent } from './welcome/welcome.component';
import { ComplaintsViewComponent } from './complaints-view/complaints-view.component';
import { HospitalViewComponent} from './hospital-view/hospital-view.component'
import { ReportsViewComponent } from './reports-view/reports-view.component';
import { NotificationsComponent } from './notifications/notifications.component';

const routes: Routes = [
{ path: '', component: WelcomeComponent },
{ path: 'complaints', component: ComplaintsViewComponent},
{ path: 'hospitals', component: HospitalViewComponent},
{ path: 'reports', component: ReportsViewComponent},
{ path: 'notifications', component: NotificationsComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
