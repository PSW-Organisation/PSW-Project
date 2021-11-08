import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HospitalExteriorViewComponent } from './hospital-exterior-view/hospital-exterior-view.component';
import { PharmaciesViewComponent } from './pharmacies-view/pharmacies-view.component';
import { BuildingFloorsComponent } from './building-floors/building-floors.component';
import { MatButtonToggleModule } from '@angular/material/button-toggle';
import { MatSidenavModule } from '@angular/material/sidenav';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatListModule } from '@angular/material/list';
import { WelcomeComponent } from './welcome/welcome.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { RoomsViewModule } from './rooms-view/rooms-view.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { PharmaciesService } from './pharmacies-view/pharmacies.service';
import { ResponsiveSidebarComponent } from './responsive-sidebar/responsive-sidebar.component';
import { EditRoomComponent } from './edit-room/edit-room/edit-room.component';
import { RoomInfoComponent } from './room-info/room-info.component';
import { EditPharmacyComponent } from './edit-pharmacy/edit-pharmacy.component';
import { EditPharmacyService } from './edit-pharmacy/edit-pharmacy.service';
import { ComplaintsViewComponent } from './complaints-view/complaints-view.component';
import { ComplaintDetailComponent } from './complaint-detail/complaint-detail.component';

@NgModule({
  declarations: [
    AppComponent,
    HospitalExteriorViewComponent,
    PharmaciesViewComponent,
    BuildingFloorsComponent,
    WelcomeComponent,
    ResponsiveSidebarComponent,
    RoomInfoComponent,
    EditPharmacyComponent,
    ComplaintsViewComponent,
    ComplaintDetailComponent,
    EditRoomComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatButtonToggleModule,
    MatSidenavModule,
    MatCardModule,
    MatButtonModule,
    MatListModule,
    MatFormFieldModule,
    MatSidenavModule,
    MatSelectModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    RoomsViewModule,
  ],
  providers: [PharmaciesService, EditPharmacyService],
  bootstrap: [AppComponent],
})
export class AppModule {}
