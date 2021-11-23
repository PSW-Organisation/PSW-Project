import { Component, Input, OnInit, SimpleChanges } from '@angular/core';
import { IEquipment } from '../../move-equipment/room-equipment';
import { RoomEqupimentService } from '../../move-equipment/room-equpiment.service';
import { IRoom } from '../room';
import { IRoomGraphic } from '../roomGraphic';

@Component({
  selector: 'app-room-equipment',
  templateUrl: './room-equipment.component.html',
  styleUrls: ['./room-equipment.component.css']
})
export class RoomEquipmentComponent implements OnInit {
  @Input() roomGraphic!: IRoomGraphic;
  equipments!: IEquipment[];

  constructor(private _roomEquipmentService: RoomEqupimentService) { }

  ngOnInit(): void {
  }
  
  ngOnChanges(changes: SimpleChanges) {
    if (changes.roomGraphic.currentValue)
      this.getEquipment();
  }


  private getEquipment(): void {
    this._roomEquipmentService.getAllRoomEquipmentInRoom(this.roomGraphic.room.id).subscribe(
      roomEquipment => this.equipments = roomEquipment
    );
  }
}
