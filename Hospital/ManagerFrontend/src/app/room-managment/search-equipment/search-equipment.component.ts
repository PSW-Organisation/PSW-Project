import { Component, OnInit } from '@angular/core';
import { async } from '@angular/core/testing';
import { Router } from '@angular/router';
import { IEquipment } from '../move-equipment/room-equipment';
import { RoomEqupimentService } from '../move-equipment/room-equpiment.service';
import { IRoom } from '../rooms-view/room';
import { RoomService } from '../rooms-view/rooms.service';

@Component({
  selector: 'app-search-equipment',
  templateUrl: './search-equipment.component.html',
  styleUrls: ['./search-equipment.component.css']
})
export class SearchEquipmentComponent implements OnInit {

  title = 'Search equipment';
  equipment!: IEquipment[];
  filteredEquipment!: IEquipment[];
  searchText = '';
  room!: IRoom;

  constructor(private _roomEquipmentService: RoomEqupimentService,
    private _router: Router,
    private _roomService: RoomService) { }

  ngOnInit(): void {
    this._roomEquipmentService.getAllRoomEquipment().subscribe(roomEquipment => {
      this.equipment = roomEquipment
      this.filteredEquipment = this.equipment;
    });

  }

  search(searchText: string) {
    console.log(searchText);
    if (searchText != '')
      this.filteredEquipment = this.equipment.filter(eq => eq.name.toLowerCase().includes(searchText.toLowerCase()));
    else
      this.filteredEquipment = this.equipment;
  }

  findOnMap(roomId: number): void {
    this._roomService.getRoomById(roomId).subscribe(room => {
      this._roomService.getBuildingForRoom(roomId).subscribe(building => {
        console.log(building)
        this._router.navigateByUrl(`roomManagment/building/${building}/floor/${room.floor}/room/${room.id}`);
      })
    });
  }
}
