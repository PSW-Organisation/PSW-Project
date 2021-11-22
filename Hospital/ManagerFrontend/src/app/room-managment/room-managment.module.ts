import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { MoveEquipmentComponent } from './move-equipment/move-equipment.component';
import { RoomManagmentRoutingModule } from './room-managment-routing.module';
import { RoomManagmentComponent } from './room-managment/room-managment.component';
import { RoomsViewModule } from './rooms-view/rooms-view.module';
import { SearchRoomsComponent } from './search-rooms/search-rooms.component';
import { SearchEquipmentComponent } from './search-equipment/search-equipment.component';

@NgModule({
  declarations: [
    RoomManagmentComponent,
    SearchRoomsComponent,
    MoveEquipmentComponent,
    SearchEquipmentComponent,
  ],
  imports: [SharedModule, RoomManagmentRoutingModule, RoomsViewModule],
  exports: [SharedModule],
})
export class RoomManagmentModule {}
