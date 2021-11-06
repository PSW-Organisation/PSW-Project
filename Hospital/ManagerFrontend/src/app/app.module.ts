import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HospitalExteriorViewComponent } from './hospital-exterior-view/hospital-exterior-view.component';
import { PharmaciesViewComponent } from './pharmacies-view/pharmacies-view.component';
import { BuildingFloorsComponent } from './building-floors/building-floors.component';
import { MatButtonToggleModule } from '@angular/material/button-toggle';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { WelcomeComponent } from './welcome/welcome.component';
import { RoomsViewModule } from './rooms-view/rooms-view.module';

import { FormsModule, ReactiveFormsModule } from '@angular/forms'; 
import { HttpClientModule } from '@angular/common/http';
import { PharmaciesService } from './pharmacies-view/pharmacies.service';

@NgModule({
  declarations: [
    AppComponent,
    HospitalExteriorViewComponent,
    PharmaciesViewComponent,
    BuildingFloorsComponent,
    WelcomeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatButtonToggleModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    RoomsViewModule
  ],
  providers: [ PharmaciesService],
  bootstrap: [AppComponent]
})
export class AppModule {
 
 }
