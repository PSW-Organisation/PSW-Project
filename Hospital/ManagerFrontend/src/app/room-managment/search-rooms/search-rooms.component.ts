import { Component, OnInit } from '@angular/core';
import { IRoom } from '../rooms-view/room';
import { IRoomGraphic } from '../rooms-view/roomGraphic';
import { RoomService } from '../rooms-view/rooms.service';

@Component({
  selector: 'app-search-rooms',
  templateUrl: './search-rooms.component.html',
  styleUrls: ['./search-rooms.component.css']
})
export class SearchRoomsComponent implements OnInit {

  title = 'Search rooms and buildings';
  searchText = '';
  rooms!: Array<IRoom>;
  errorMessage = '';

  constructor(private _roomService: RoomService) { }

  ngOnInit(): void {
  }

  private getRoomsByName() {
    this._roomService.getRoomsByName(this.searchText).subscribe(
      (rooms) => {
        this.rooms = rooms;
      },
      (error) => (this.errorMessage = <any>error)
    );
  }

  search(): void {
    this.getRoomsByName()
  }

}
