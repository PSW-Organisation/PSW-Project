import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IRoom } from '../rooms-view/room';
import { RoomService } from '../rooms-view/rooms.service';

@Component({
  selector: 'app-search-rooms',
  templateUrl: './search-rooms.component.html',
  styleUrls: ['./search-rooms.component.css']
})
export class SearchRoomsComponent implements OnInit {

  title = 'Search rooms';
  searchText = '';
  rooms!: Array<IRoom>;
  errorMessage = '';

  constructor(
    private _roomService: RoomService,
    private _router: Router
  ) { }

  ngOnInit(): void {
    this.getRooms();
  }

  getRooms(): void {
    this._roomService.getRooms().subscribe(
      (rooms) => {
        this.rooms = rooms;
      },
      (error) => (this.errorMessage = <any>error)
    );
  }
  
  search(): void {
    this.getRoomsByName()
  }

  private getRoomsByName() {
    this._roomService.getRoomsByName(this.searchText).subscribe(
      (rooms) => {
        this.rooms = rooms;
      },
      (error) => (this.errorMessage = <any>error)
    );
  }
  
  findOnMap(room: IRoom): void {
    this._roomService.getBuildingForRoom(room.id).subscribe(building => {
      this._router.navigateByUrl(`roomManagment/building/${building}/floor/${room.floor}/room/${room.id}`);
    })
    
  }
}
