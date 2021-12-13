import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { MoveEquipmentComponent } from './move-equipment/move-equipment.component';
import { RoomManagmentRoutingModule } from './room-managment-routing.module';
import { RoomManagmentComponent } from './room-managment/room-managment.component';
import { RoomsViewModule } from './rooms-view/rooms-view.module';
import { SearchRoomsComponent } from './search-rooms/search-rooms.component';
import { SearchEquipmentComponent } from './search-equipment/search-equipment.component';
import { RenovateRoomsComponent } from './renovate-rooms/renovate-rooms.component';
import { RoomScheduleModule } from './room-schedule/room-schedule.module';

@NgModule({
  declarations: [
    RoomManagmentComponent,
    SearchRoomsComponent,
    MoveEquipmentComponent,
    SearchEquipmentComponent,
    RenovateRoomsComponent,
  ],
  imports: [SharedModule, RoomManagmentRoutingModule, RoomsViewModule, RoomScheduleModule],
  exports: [SharedModule],
})
export class RoomManagmentModule {}
