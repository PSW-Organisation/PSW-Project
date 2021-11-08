import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { BuildingFloorsComponent } from './building-floors/building-floors.component';

const routes: Routes = [
  { path: 'building/:buidingId/floor/:floorId', component: BuildingFloorsComponent }
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
export class RoomsRoutingModule { }
