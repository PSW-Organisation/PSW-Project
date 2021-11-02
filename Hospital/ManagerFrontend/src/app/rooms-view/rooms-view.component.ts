import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router, ParamMap } from '@angular/router';
import { IRoom } from './room';
import { RoomService } from './rooms.service';

@Component({
  selector: 'app-rooms-view',
  templateUrl: './rooms-view.component.html',
  styleUrls: ['./rooms-view.component.css'],
})
export class RoomsViewComponent implements OnInit {

  rooms: IRoom[] = [];
  fillColor!: string;
  errorMessage!: string;
  floor: number = 0;
  constructor(private _route: ActivatedRoute,
    private _router: Router,
    private _roomService: RoomService) { }
  ngOnInit(): void {
    this.floor = +this._route.snapshot.paramMap.get('id')!;
    /*this._route.paramMap.subscribe((params : ParamMap)=> {  
      this.floor=+!params.get('id');    
    });*/
    alert(this.floor);
    this._roomService.getRooms()
    .subscribe(rooms =>this.rooms=rooms,
      error=>this.errorMessage = <any>error);

  }
  roomColor(roomId: string): string {

    if (roomId.indexOf('OP') > -1) {
      this.fillColor = '#FFE5CC';
    }
    else if (roomId.indexOf('SP') > -1){
      this.fillColor = '#FBD9FC';
    }
    else if (roomId.indexOf('WC') > -1){
      this.fillColor = '#CCFFFF';
    }
    else if (roomId === 'C'){
      this.fillColor = '#E5FFCC';
    }
    return this.fillColor;
  }

  ngOnChange(): void{
    
  }

  onBack(): void{
    this._router.navigate(['/welcome']);
  }

}
