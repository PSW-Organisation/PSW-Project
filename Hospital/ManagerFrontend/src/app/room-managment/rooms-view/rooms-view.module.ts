import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { RoomsRoutingModule } from './rooms-routing.module';

import { BuildingFloorsComponent } from './building-floors/building-floors.component';
import { RoomsViewComponent } from './rooms-view/rooms-view.component';
import { RoomInfoComponent } from './room-info/room-info.component';
import { EditRoomComponent } from './edit-room/edit-room.component';
import { RouterModule } from '@angular/router';
import { RoomEquipmentComponent } from './room-equipment/room-equipment.component';

@NgModule({
  declarations: [
    BuildingFloorsComponent,
    RoomsViewComponent,
    RoomInfoComponent,
    EditRoomComponent,
    RoomEquipmentComponent,
  ],
  imports: [
    SharedModule
  ]
})
export class RoomsViewModule {}
