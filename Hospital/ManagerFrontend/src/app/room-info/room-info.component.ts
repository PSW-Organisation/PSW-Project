import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-room-info',
  templateUrl: './room-info.component.html',
  styleUrls: ['./room-info.component.css']
})
export class RoomInfoComponent implements OnInit {

  fillColor!: string;
  room: any = {
    "id": 0,
    "doorPosition": "right",
    "width": 100,
    "height": 100,
    "x": 0,
    "y": 0,
    "name": "Š1",
    "floor": 0,
    "type": "Salter",
    "roomName": "Šalter 1"
};

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
    else if (type === 'Č'){
      this.fillColor = '#E5FFCC';
    }
    return this.fillColor;
  }

}
