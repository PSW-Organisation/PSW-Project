import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { RoomsRoutingModule } from './rooms-routing.module';

import { BuildingFloorsComponent } from './building-floors/building-floors.component';
import { RoomsViewComponent } from './rooms-view/rooms-view.component';
import { RoomInfoComponent } from './room-info/room-info.component';
import { EditRoomComponent } from './edit-room/edit-room.component';

@NgModule({
  declarations: [
    BuildingFloorsComponent,
    RoomsViewComponent,
    RoomInfoComponent,
    EditRoomComponent
  ],
  imports: [
    SharedModule,
    RoomsRoutingModule
  ],
  exports:[
    SharedModule
  ]
})
export class RoomsViewModule { }
