import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RoomScheduleComponent } from './room-schedule.component';
import { SharedModule } from 'src/app/shared/shared.module';

@NgModule({
  declarations: [RoomScheduleComponent],
  imports: [
    CommonModule,
    SharedModule
  ]
})
export class RoomScheduleModule { }
