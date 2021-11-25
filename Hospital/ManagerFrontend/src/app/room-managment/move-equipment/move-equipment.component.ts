import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDatepickerInputEvent } from '@angular/material/datepicker';
import { IRoom } from '../rooms-view/room';
import { RoomService } from '../rooms-view/rooms.service';
import { IEquipment, IEquipmentQuantity, IFreeTerms, IParamsOfRelocationEquipment, ParamsOfRelocationEquipment } from './room-equipment';

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
  fiveFormGroup!: FormGroup;
  sixFormGroup!: FormGroup;
  sevenFormGroup!: FormGroup;
  selectedEquipment!: IEquipmentQuantity;
  equipments!: IEquipment[];
  equipmentsDTO!: IEquipmentQuantity[];
  selectedRoomWithEquipment!: IEquipment;
  roomsWithoutSource!: IRoom[];
  selectedDestinationRoom!: IRoom;
  equipmentAmount!: number;
  paramsOfRelocationEquipment!: IParamsOfRelocationEquipment;
  freeTerms!: IFreeTerms[];
  minDate!: Date;
  selectedFreeTerm!: IFreeTerms;
  termOfRelocationEquipment!: IParamsOfRelocationEquipment;

  startYear!: number;
  startMonth!: number;
  startDay!: number;
  startHours!: number;
  startMinutes!: number;

  endYear!: number;
  endMonth!: number;
  endDay!: number;
  endHours!: number;
  endMinutes!: number;
  
  duration!: number;

  addEvent(type: string, event: MatDatepickerInputEvent<Date>) {
    if (event.value != null) {
      if (type === 'inputStart' || type === 'changeStart') {
        this.startYear = event.value.getFullYear();
        this.startMonth = event.value.getMonth();
        this.startDay = event.value.getDate();
      }
      else if (type === 'inputEnd' || type === 'changeEnd') {
        this.endYear = event.value.getFullYear();
        this.endMonth = event.value.getMonth();
        this.endDay = event.value.getDate();
      }

    }
  }


  constructor(private _formBuilder: FormBuilder,
    private _roomEquipmentService: RoomEqupimentService,
    private _roomService: RoomService) {
    this.paramsOfRelocationEquipment = new ParamsOfRelocationEquipment(-1, -1, '', -1, new Date(), new Date(), 0);
  }

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

  activateFive() {
    
  }

  activateSix() {
  }

  activateSeven() {
    this.paramsOfRelocationEquipment.NameOfEquipment = this.selectedEquipment.name;
    this.paramsOfRelocationEquipment.IdSourceRoom = this.selectedRoomWithEquipment.roomId;
    this.paramsOfRelocationEquipment.IdDestinationRoom = this.selectedDestinationRoom.id;
    this.paramsOfRelocationEquipment.QuantityOfEquipment = this.equipmentAmount;
    this.paramsOfRelocationEquipment.StartTime = new Date(Date.UTC(this.startYear, this.startMonth, this.startDay, this.startHours, this.startMinutes));
    this.paramsOfRelocationEquipment.endTime = new Date(Date.UTC(this.endYear, this.endMonth, this.endDay, this.endHours, this.endMinutes));
    this.paramsOfRelocationEquipment.durationInMinutes = this.duration;
    this._roomEquipmentService.getAllPosibleRelocationTerms(this.paramsOfRelocationEquipment).subscribe(free => {this.freeTerms = free});
  }

  
  activateLast() {
    this.paramsOfRelocationEquipment.StartTime = this.selectedFreeTerm.startTime;
    this.paramsOfRelocationEquipment.endTime = this.selectedFreeTerm.endTime;
    this._roomEquipmentService.createTermOfRelocation(this.paramsOfRelocationEquipment).subscribe(create => { this.termOfRelocationEquipment = create; });
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
    this.fiveFormGroup = this._formBuilder.group({
      startHoursCtrl: ['', Validators.required],
      startMinutesCtrl: ['', Validators.required],
      endHoursCtrl: ['', Validators.required],
      endMinutesCtrl: ['', Validators.required],
    });
    this.sixFormGroup = this._formBuilder.group({
      sixCtrl: ['', Validators.required],
    });
    this.sevenFormGroup = this._formBuilder.group({
      sevenCtrl: ['', Validators.required],
    });
    

    this.minDate = new Date(Date.now());

    this._roomEquipmentService.getRoomEquipmentQuantity().subscribe(roomEquipment => this.equipmentsDTO = roomEquipment);

  }
}
