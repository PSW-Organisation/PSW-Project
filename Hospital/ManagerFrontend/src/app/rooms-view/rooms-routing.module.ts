import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import {RoomsViewComponent} from './rooms-view.component';


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild([
      { path: 'rooms/:floorId',component:RoomsViewComponent},
    ]),
  ],
  exports: [
    RouterModule
  ]
})
export class RoomsRoutingModule { }
