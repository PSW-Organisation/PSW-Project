import { Component, EventEmitter, Input, OnInit, Output, SimpleChanges } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { ResponsiveSidebarComponent } from 'src/app/shared/responsive-sidebar/responsive-sidebar.component';
import { IFloor } from '../building-floors/floor';
import { RoomType } from '../room';
import { IRoomGraphic } from '../roomGraphic';
import { RoomService } from '../rooms.service';

@Component({
  selector: 'app-rooms-view',
  templateUrl: './rooms-view.component.html',
  styleUrls: ['./rooms-view.component.css'],
})
export class RoomsViewComponent implements OnInit {
  @Input() floor!: IFloor;
  @Input() sidenav!: ResponsiveSidebarComponent;
  @Output() selectedRoomGraphic: EventEmitter<IRoomGraphic> =
    new EventEmitter();
  selectedRoomId: number = -1
  selectedRoom: IRoomGraphic = {
    id: -1,
    name: "",
    x: 0,
    y: 0,
    width: 0,
    height: 0,
    doorPosition: "",
    room: {
      id: 0,
      name: "",
      sector: "",
      floor: 0,
      roomType: RoomType.examination,
      isRenovated: true,
      isRenovatedUntil: "",
      numOfTakenBeds: 0
    }
  };
  fillColor!: string;

  constructor(
    private _roomService: RoomService,
    private _route: ActivatedRoute
  ) { }

  ngOnInit(): void { }
    
  ngOnChanges(changes: SimpleChanges) {
    if (changes.floor.currentValue)
      this.setSelectedRoom();
  }

  roomColor(type: RoomType): string {
    return (this.fillColor = this._roomService.getRoomColor(type));
  }

  getViewBox(width: number, height: number): string {
    return `0 0 ${width} ${height}`;
  }

  selectRoom(room: IRoomGraphic) {
    this.selectedRoom = room;
    this.selectedRoomGraphic.emit(this.selectedRoom);
    this.sidenav.open();
  }
  getAcronym(text: string): string {
    return this._roomService.getAcronym(text);
  }

  private setSelectedRoom() {
    this._route.paramMap.subscribe((params: ParamMap) => {
      this.selectedRoomId = +params.get('roomId')!;
    });
    if (!this.selectedRoomId) return;
    let room: IRoomGraphic = this.floor.roomGraphics.filter(
      r => r.room.id === this.selectedRoomId
    )[0];
    this.selectRoom(room);
  }
}
