import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HospitalExteriorViewComponent } from './hospital-exterior-view/hospital-exterior-view.component';

@NgModule({
  declarations: [
    AppComponent,
    HospitalExteriorViewComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
