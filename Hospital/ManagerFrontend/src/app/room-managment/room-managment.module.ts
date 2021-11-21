import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { RoomManagmentRoutingModule } from './room-managment-routing.module';
import { RoomManagmentComponent } from './room-managment/room-managment.component';
import { RoomsViewModule } from './rooms-view/rooms-view.module';
import { SearchRoomsComponent } from './search-rooms/search-rooms.component';


@NgModule({
  declarations: [
    RoomManagmentComponent,
    SearchRoomsComponent
  ],
  imports: [
    SharedModule,
    RoomManagmentRoutingModule,
    RoomsViewModule
  ],
  exports:[
    SharedModule
  ]
})
export class RoomManagmentModule { }
