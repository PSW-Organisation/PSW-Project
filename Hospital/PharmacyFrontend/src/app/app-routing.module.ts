import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MedicineReportComponent } from './medicine-report/medicine-report.component';
import { WelcomeComponent } from './welcome/welcome.component';

const routes: Routes = [
{ path: '', component: WelcomeComponent },
{ path: 'medicineReport', component: MedicineReportComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
