import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { RoomManagmentComponent } from './room-managment/room-managment.component';
import { SearchRoomsComponent } from './search-rooms/search-rooms.component';
import { HospitalExteriorViewComponent } from './hospital-exterior-view/hospital-exterior-view.component';
import { BuildingFloorsComponent } from './rooms-view/building-floors/building-floors.component';
import { MoveEquipmentComponent } from './move-equipment/move-equipment.component';
import { SearchEquipmentComponent } from './search-equipment/search-equipment.component';
import { RenovateRoomsComponent } from './renovate-rooms/renovate-rooms.component';
import { RoomScheduleComponent } from './room-schedule/room-schedule.component';
import { DoctorStatisticsComponent } from './doctor-statistics/doctor-statistics.component';



const routes: Routes = [
  { path: 'roomManagment', component: RoomManagmentComponent,
      children: [
        { path: 'searchEquipment', component: SearchEquipmentComponent},
        { path: 'searchRooms', component: SearchRoomsComponent },
        { path: 'hospitalExterior', component: HospitalExteriorViewComponent },
        { path: 'building/:buidingId/floor/:floorId', component: BuildingFloorsComponent },
        { path: 'building/:buidingId/floor/:floorId/room/:roomId', component: BuildingFloorsComponent },
        { path: 'moveEquipment', component: MoveEquipmentComponent },
        { path: 'renovateRooms', component: RenovateRoomsComponent },
        { path: 'roomSchedule/:roomId', component: RoomScheduleComponent },
        { path: 'testChart', component: DoctorStatisticsComponent }
      ]
  }
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
  ],
  exports: [
    RouterModule
  ]
})
export class RoomManagmentRoutingModule { }
