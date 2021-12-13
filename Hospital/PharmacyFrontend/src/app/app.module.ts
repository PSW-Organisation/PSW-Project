import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { WelcomeComponent } from './welcome/welcome.component';
import { HttpClientModule } from '@angular/common/http';
import { RegistrationService } from './welcome/reistration.service';
import { FormsModule } from '@angular/forms';
import { ComplaintsViewComponent } from './complaints-view/complaints-view.component';
import { HospitalViewComponent } from './hospital-view/hospital-view.component';
import { ReportsViewComponent } from './reports-view/reports-view.component';
import { NotificationsComponent } from './notifications/notifications.component';
import { FileCompressionViewComponent } from './file-compression-view/file-compression-view.component';
import { NgChartsModule } from 'ng2-charts';

@NgModule({
  declarations: [
    AppComponent,
    WelcomeComponent,
    ComplaintsViewComponent,
    HospitalViewComponent,
    ReportsViewComponent,
    NotificationsComponent,
    FileCompressionViewComponent,

  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule,
    NgChartsModule
    ],
  providers: [ RegistrationService],
  bootstrap: [AppComponent]
})
export class AppModule { }
