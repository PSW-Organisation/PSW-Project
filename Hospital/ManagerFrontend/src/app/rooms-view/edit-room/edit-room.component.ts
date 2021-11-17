import { isExpressionFactoryMetadata } from '@angular/compiler/src/render3/r3_factory';
import {
  Component,
  EventEmitter,
  Input,
  OnChanges,
  OnInit,
  Output,
} from '@angular/core';
import { IRoom, RoomType } from '../room';

@Component({
  selector: 'app-edit-room',
  templateUrl: './edit-room.component.html',
  styleUrls: ['./edit-room.component.css'],
})
export class EditRoomComponent implements OnInit, OnChanges {
  @Input() roomInfo!: IRoom;
  @Output() selectionChange: EventEmitter<IRoom> = new EventEmitter<IRoom>();
  value!: RoomType;
  selectedType!: RoomType;
  newName: string = '';
  newSector: string = '';
  newRoom!: IRoom;
  types: any[] = [
    {
      RoomType: RoomType.examination,
      text: 'Examination',
    },
    {
      RoomType: RoomType.operation,
      text: 'Operation hall',
    },
    {
      RoomType: RoomType.restingRoom,
      text: 'Resting room',
    },
    {
      RoomType: RoomType.restroom,
      text: 'Restroom',
    },
    {
      RoomType: RoomType.counter,
      text: 'Counter',
    },
    {
      RoomType: RoomType.waitingRoom,
      text: 'Waiting room',
    },
  ];
  constructor() {}

  select() {
    this.newRoom = { ...this.roomInfo };
    console.log(this.selectedType);
    if (typeof this.selectedType !== 'undefined') {
      this.newRoom.roomType = this.selectedType;
    }
    if (this.newName !== '') {
      this.newRoom.name = this.newName;
    }
    if (this.newSector !== '') {
      this.newRoom.sector = this.newSector;
    }
    this.selectionChange.emit(this.newRoom);
  }
  ngOnInit(): void {
    this.selectedType = this.roomInfo.roomType;
    this.newName = this.roomInfo.name;
    this.newSector = this.roomInfo.sector;
  }
  ngOnChanges() {
    this.selectedType = this.roomInfo.roomType;
    this.newName = this.roomInfo.name;
    this.newSector = this.roomInfo.sector;
  }
}
