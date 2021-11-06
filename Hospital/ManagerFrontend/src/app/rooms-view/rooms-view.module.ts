import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { RoomsViewComponent } from './rooms-view.component';
import { RoomViewComponent } from './room-view.component';
import { RoomsRoutingModule } from './rooms-routing.module';


@NgModule({
  declarations: [
    RoomsViewComponent,
    RoomViewComponent
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    RoomsRoutingModule
  ],
  exports:[
    RoomViewComponent
  ]
})
export class RoomsViewModule { }
