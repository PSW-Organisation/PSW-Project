import { Component, OnInit } from '@angular/core';
import { IEquipment } from '../move-equipment/room-equipment';
import { RoomEqupimentService } from '../move-equipment/room-equpiment.service';

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

  constructor(private _roomEquipmentService: RoomEqupimentService) { }

  ngOnInit(): void {
    this._roomEquipmentService.getAllRoomEquipment().subscribe(roomEquipment => {
      this.equipment = roomEquipment
      this.filteredEquipment = this.equipment;
    });

  }

  search(searchText:string) {
    console.log(searchText);
    if(searchText!='')
      this.filteredEquipment = this.equipment.filter(eq => eq.name.toLowerCase().includes(searchText.toLowerCase()));
    else 
      this.filteredEquipment = this.equipment;
  }

}
