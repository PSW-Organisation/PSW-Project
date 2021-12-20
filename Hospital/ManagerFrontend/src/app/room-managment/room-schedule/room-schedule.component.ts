import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { IRoom } from '../rooms-view/room';
import { RoomScheduleService } from './room-schedule.service';
import { IScheduleTerm, StateOfRenovation } from './schedule-term';
import dateFormat from "dateformat";
import { RoomService } from '../rooms-view/rooms.service';
import { TermOfRenovationService } from '../renovate-rooms/term-of-renovation.service';
import { RoomEqupimentService } from '../move-equipment/room-equpiment.service';

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
    private _roomService: RoomService,
    private _renovationService: TermOfRenovationService,
    private _relocationService: RoomEqupimentService) { }

  ngOnInit(): void {
    this.getTerms();
  }

  getTerms():void {
      this.roomId = this._route.snapshot.paramMap.get('roomId');
    let roomId = Number(this.roomId);
    this._roomService.getRoomById(roomId).subscribe(rooms=>{
    this._roomScheduleService.getAllRelocationTermsForRoom(roomId).subscribe(relocationTerms => {
      this._roomScheduleService.getAllRenovationTermsForRoom(roomId).subscribe(renovationTerms => {
        this._roomScheduleService.getAllAppointmentsForRoom(roomId).subscribe(appointments => {
        this.room = rooms;
        this.title = this.room.name+"'s "+'Terms Schedule';
        console.log(renovationTerms);
        this.terms = relocationTerms.concat(renovationTerms).concat(appointments);
      });
    });
  });
  });
 }
  
  formatDate(date:Date):string{
    return dateFormat(date, "dddd, mmmm dS, yyyy, h:MM:ss TT");
  }
  termShow(renovationState:StateOfRenovation):boolean{
    let show = true;
    if(renovationState === StateOfRenovation.pending){
      show = true;
    }
    else if(renovationState === StateOfRenovation.successfull){
      show = true;
    }
    else if(renovationState === StateOfRenovation.unsuccessfull){
      show = false;
    }
    else if(renovationState === StateOfRenovation.cancelled){
      show = false;
    }
    return show;
  }

  cancelTerm(term: IScheduleTerm):void {
  if(term.type === 'Renovation'){
    this._renovationService.cancelTermOfRenovation(term.id).subscribe((a) => { this.getTerms(); }
    );
  }
  else if(term.type === 'Relocation'){
    this._relocationService.cancelTermOfRelocation(term.id).subscribe((a) => { this.getTerms(); }
    );
  }
}


}
