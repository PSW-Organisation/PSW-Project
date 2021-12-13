import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { IRoom } from '../rooms-view/room';
import { RoomScheduleService } from './room-schedule.service';
import { IScheduleTerm } from './schedule-term';
import dateFormat from "dateformat";
import { RoomService } from '../rooms-view/rooms.service';

@Component({
  selector: 'app-room-schedule',
  templateUrl: './room-schedule.component.html',
  styleUrls: ['./room-schedule.component.css']
})
export class RoomScheduleComponent implements OnInit {

  title = 'Terms Schedule';
  terms!: IScheduleTerm[];
  room!: IRoom;
  roomId!: string | null;

  constructor(private _roomScheduleService: RoomScheduleService,
    private _route: ActivatedRoute,
    private _roomService: RoomService) { }

  ngOnInit(): void {
    this.roomId = this._route.snapshot.paramMap.get('roomId');
    let roomId = Number(this.roomId);
    this._roomService.getRoomById(roomId).subscribe(rooms=>{
    this._roomScheduleService.getAllRelocationTermsForRoom(roomId).subscribe(relocationTerms => {
      this._roomScheduleService.getAllRelocationTermsForRoom(roomId).subscribe(renovationTerms => {
        this.room = rooms;
        this.title = this.room.name+"'s "+'Terms Schedule';
        this.terms = relocationTerms;
        this.terms.concat(renovationTerms);
      });
    });
  });
  }
  formatDate(date:Date):string{
    return dateFormat(date, "dddd, mmmm dS, yyyy, h:MM:ss TT");
  }
}
