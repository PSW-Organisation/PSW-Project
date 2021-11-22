import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { IRoom } from '../rooms-view/room';
import { RoomService } from '../rooms-view/rooms.service';
import { IEquipment, IEquipmentQuantity } from './room-equipment';

import { RoomEqupimentService } from './room-equpiment.service';


@Component({
  selector: 'app-move-equipment',
  templateUrl: './move-equipment.component.html',
  styleUrls: ['./move-equipment.component.css'],
})
export class MoveEquipmentComponent implements OnInit {
  isLinear = true;
  firstFormGroup!: FormGroup;
  secondFormGroup!: FormGroup;
  thirdFormGroup!: FormGroup;
  forthFormGroup!: FormGroup;
  selectedEquipment!: IEquipmentQuantity;
  equipments!: IEquipment[];
  equipmentsDTO!: IEquipmentQuantity[];
  selectedRoomWithEquipment!: IEquipment;
  roomsWithoutSource!: IRoom[];
  selectedDestinationRoom!: IRoom;
  equipmentAmount!: number;

  constructor(private _formBuilder: FormBuilder,
    private _roomEquipmentService: RoomEqupimentService,
    private _roomService: RoomService) { }

  activateSecond() {
    this._roomEquipmentService.getRoomEquipment(this.selectedEquipment.name).subscribe(roomEquipment => this.equipments = roomEquipment);
  }

  activateThird() {
    this.thirdFormGroup = this._formBuilder.group({

      thirdCtrl: new FormControl("", [Validators.max(this.selectedRoomWithEquipment.quantity), Validators.min(0)])
    });
  }

  activateForth() {
    this._roomService.getRooms().subscribe(rooms => {
      this.roomsWithoutSource = rooms;
      this.roomsWithoutSource = this.roomsWithoutSource.filter(room => room.id !== this.selectedRoomWithEquipment.roomId);
    });

  }

  ngOnInit() {
    this.firstFormGroup = this._formBuilder.group({
      firstCtrl: ['', Validators.required],
    });
    this.secondFormGroup = this._formBuilder.group({
      secondCtrl: ['', Validators.required],
    });
    this.thirdFormGroup = this._formBuilder.group({
      thirdCtrl: ['', Validators.required],
    });
    this.forthFormGroup = this._formBuilder.group({
      forthCtrl: ['', Validators.required],
    });


    this._roomEquipmentService.getRoomEquipmentQuantity().subscribe(roomEquipment => this.equipmentsDTO = roomEquipment);

  }
}
