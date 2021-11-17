import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { SidenavService } from 'src/app/shared/responsive-sidebar/sidenav.service';
import { IFloor } from '../building-floors/floor';
import { IRoom, RoomType } from '../room';
import { IRoomGraphic } from '../roomGraphic';
import { RoomService } from '../rooms.service';

@Component({
  selector: 'app-rooms-view',
  templateUrl: './rooms-view.component.html',
  styleUrls: ['./rooms-view.component.css'],
})
export class RoomsViewComponent implements OnInit {
  @Input() floor!: IFloor;
  @Output() selectedRoomGraphic: EventEmitter<IRoomGraphic> =
    new EventEmitter();
  fillColor!: string;

  constructor(
    private _sidenav: SidenavService,
    private _roomService: RoomService
  ) {}

  ngOnInit(): void {}

  roomColor(type: RoomType): string {
    return (this.fillColor = this._roomService.getRoomColor(type));
  }

  getViewBox(width: number, height: number): string {
    return `0 0 ${width} ${height}`;
  }

  selectRoom(room: IRoomGraphic) {
    this.selectedRoomGraphic.emit(room);
    this._sidenav.open();
  }
  getAcronym(text: string): string {
    return this._roomService.getAcronym(text);
  }
}
