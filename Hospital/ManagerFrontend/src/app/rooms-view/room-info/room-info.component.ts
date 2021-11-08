import { Component, Input, OnInit } from '@angular/core';
import { IRoom } from '../room';

@Component({
  selector: 'app-room-info',
  templateUrl: './room-info.component.html',
  styleUrls: ['./room-info.component.css']
})
export class RoomInfoComponent implements OnInit {

  @Input() room!: IRoom;
  fillColor!: string;

  constructor() { }

  ngOnInit(): void {
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
    else if (type === 'Cekaonica'){
      this.fillColor = '#E5FFCC';
    }
    return this.fillColor;
  }

}
