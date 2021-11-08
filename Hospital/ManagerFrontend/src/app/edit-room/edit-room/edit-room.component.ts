import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-edit-room',
  templateUrl: './edit-room.component.html',
  styleUrls: ['./edit-room.component.css'],
})
export class EditRoomComponent implements OnInit {
  rooms: any[] = [
    {
      id: 1,
      type: 'ROOM',
    },
    {
      id: 1,
      type: 'OPERATION HALL',
    },
  ];
  constructor() {}

  ngOnInit(): void {}
}
