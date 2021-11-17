import { Component, Input, OnInit } from '@angular/core';
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

  constructor(private _roomService: RoomService) {}

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
}
