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
    this.floor = +this._route.snapshot.paramMap.get('floorId')!;
    /*this._route.paramMap.subscribe((params : ParamMap)=> {  
      this.floor=+params.get('id')!;    
    });*/
    this._roomService.getRooms()
    .subscribe(rooms =>this.rooms=rooms,
      error=>this.errorMessage = <any>error);

  }
  roomColor(type: string): string {

    if (type === 'OperacionaSala') {
      this.fillColor = '#FFE5CC';
    }
    else if (type === 'Salter'){
      this.fillColor = '#999FFF';
    }
    else if (type === 'SalaZaPregled'){
      this.fillColor = '#FBD9FC';
    }
    else if (type=== 'WC'){
      this.fillColor = '#CCFFFF';
    }
    else if (type === 'Č'){
      this.fillColor = '#E5FFCC';
    }
    return this.fillColor;
  }

  ngOnChange(): void{
    
  }

  getViewBox(width:number,height:number): string {
    return `0 0 ${width} ${height}`
  }

  onBack(): void{
    this._router.navigate(['/welcome']);
  }

}
