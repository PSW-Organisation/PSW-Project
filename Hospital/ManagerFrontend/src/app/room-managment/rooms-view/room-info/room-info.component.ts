import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { RoomScheduleService } from '../../room-schedule/room-schedule.service';
import { RoomType } from '../room';
import { IRoomGraphic } from '../roomGraphic';
import { RoomService } from '../rooms.service';

@Component({
  selector: 'app-room-info',
  templateUrl: './room-info.component.html',
  styleUrls: ['./room-info.component.css'],
})
export class RoomInfoComponent implements OnInit {
  @Input() roomGraphic!: IRoomGraphic;
  fillColor!: string;

  constructor(private _roomService: RoomService,
    private _router: Router) {}

  ngOnInit(): void {}

  roomColor(type: RoomType): string {
    return (this.fillColor = this._roomService.getRoomColor(type));
  }

  getRoomTypeText(type: RoomType): string {
    return this._roomService.getRoomTypeText(type);
  }
  getAcronym(text: string): string {
    return this._roomService.getAcronym(text);
  }

  showRoomSchedule(): void {
      this._router.navigateByUrl(`roomManagment/roomSchedule/${this.roomGraphic.room.id}`);
  }
}
