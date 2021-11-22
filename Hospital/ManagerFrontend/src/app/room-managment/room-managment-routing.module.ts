import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { RoomManagmentComponent } from './room-managment/room-managment.component';
import { SearchRoomsComponent } from './search-rooms/search-rooms.component';
import { HospitalExteriorViewComponent } from './hospital-exterior-view/hospital-exterior-view.component';
import { BuildingFloorsComponent } from './rooms-view/building-floors/building-floors.component';

const routes: Routes = [
  { path: 'roomManagment', component: RoomManagmentComponent,
      children: [
        { path: 'searchRooms', component: SearchRoomsComponent },
        { path: 'hospitalExterior', component: HospitalExteriorViewComponent },
        { path: 'building/:buidingId/floor/:floorId', component: BuildingFloorsComponent },
        { path: 'building/:buidingId/floor/:floorId/room/:roomId', component: BuildingFloorsComponent }
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
