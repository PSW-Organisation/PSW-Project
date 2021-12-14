import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { MatDatepickerInputEvent } from '@angular/material/datepicker';
import { IRoom, RoomType } from '../rooms-view/room';
import { RoomService } from '../rooms-view/rooms.service';
import { RenovationType } from './renovation-type';
import { BreakpointObserver } from '@angular/cdk/layout';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { StepperOrientation } from '@angular/material/stepper';
import { EquipmentLogic, IParamsOfRenovation } from './params-of-renovation';
import { IFreeTerms } from '../move-equipment/room-equipment';
import { TermOfRenovationService } from './term-of-renovation.service';

@Component({
  selector: 'app-renovate-rooms',
  templateUrl: './renovate-rooms.component.html',
  styleUrls: ['./renovate-rooms.component.css'],
})
export class RenovateRoomsComponent implements OnInit {
  isLinear = true;
  stepperOrientation: Observable<StepperOrientation>;
  firstFormGroup!: FormGroup;
  secondFormGroup!: FormGroup;
  thirdFormGroup!: FormGroup;
  forthFormGroup!: FormGroup;
  fiveFormGroup!: FormGroup;
  sixFormGroup!: FormGroup;

  renovationTypeKeys!: number[];
  renovationTypes = RenovationType;
  selectedRenovationType: RenovationType = RenovationType.split;

  selectedRoom!: IRoom;
  rooms!: IRoom[];

  selectedRoomB!: IRoom;
  roomsB!: IRoom[];

  minDate!: Date;

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

  roomTypeKeys!: number[];
  roomTypes = RoomType;

  selectedRoom1Type!: RoomType;
  newRoom1Name!: string;
  newRoom1Sector!: string;

  selectedRoom2Type!: RoomType;
  newRoom2Name!: string;
  newRoom2Sector!: string;

  equipmentLogicKeys!: number[];
  equipmentLogicTypes = EquipmentLogic;
  selectedEquipmentLogic!: EquipmentLogic;

  termOfRelocationEquipment!: IParamsOfRenovation;
  paramsOfRenovation!: IParamsOfRenovation;
  freeTerms!: IFreeTerms[];
  selectedFreeTerm!: IFreeTerms;

  constructor(
    private _formBuilder: FormBuilder,
    private _roomService: RoomService,
    private _termOfRenovationService: TermOfRenovationService,
    breakpointObserver: BreakpointObserver
  ) {
    this.stepperOrientation = breakpointObserver
      .observe('(min-width: 800px)')
      .pipe(map(({ matches }) => (matches ? 'horizontal' : 'vertical')));
  }

  selectRoomA() {
    this._roomService
      .getAllPossibleRoomsForMergWithRoom(this.selectedRoom.id)
      .subscribe((rooms) => (this.roomsB = rooms));
  }

  addEvent(type: string, event: MatDatepickerInputEvent<Date>) {
    if (event.value != null) {
      if (type === 'inputStart' || type === 'changeStart') {
        this.startYear = event.value.getFullYear();
        this.startMonth = event.value.getMonth();
        this.startDay = event.value.getDate();
      } else if (type === 'inputEnd' || type === 'changeEnd') {
        this.endYear = event.value.getFullYear();
        this.endMonth = event.value.getMonth();
        this.endDay = event.value.getDate();
      }
    }
  }

  activateSecond() {
    this._roomService.getRooms().subscribe((rooms) => (this.rooms = rooms));
  }

  activateThird() {}

  activateForth() {}

  activateFive() {}

  activateSix() {
    this.paramsOfRenovation.StartTime = new Date(
      Date.UTC(
        this.startYear,
        this.startMonth,
        this.startDay,
        this.startHours,
        this.startMinutes
      )
    );
    this.paramsOfRenovation.EndTime = new Date(
      Date.UTC(
        this.endYear,
        this.endMonth,
        this.endDay,
        this.endHours,
        this.endMinutes
      )
    );
    this.paramsOfRenovation.DurationInMinutes = this.duration;
    this.paramsOfRenovation.IdRoomA = this.selectedRoom.id;
    if (this.selectedRenovationType == RenovationType.split) {
      this.paramsOfRenovation.IdRoomB = -1;
      this.paramsOfRenovation.TypeOfRenovation = RenovationType.split;
    } else {
      this.paramsOfRenovation.IdRoomB = this.selectedRoomB.id;
      this.paramsOfRenovation.TypeOfRenovation = RenovationType.merge;
    }

    this.paramsOfRenovation.EquipmentLogic = this.selectedEquipmentLogic;
    this.paramsOfRenovation.NewNameForRoomA = this.newRoom1Name;
    this.paramsOfRenovation.NewSectorForRoomA = this.newRoom1Sector;
    this.paramsOfRenovation.NewRoomTypeForRoomA = this.selectedRoom1Type;
    this.paramsOfRenovation.NewNameForRoomB = this.newRoom2Name;
    this.paramsOfRenovation.NewSectorForRoomB = this.newRoom2Sector;
    this.paramsOfRenovation.NewRoomTypeForRoomB = this.selectedRoom2Type;
    this._termOfRenovationService
      .getAllPosibleRenovationTerms(this.paramsOfRenovation)
      .subscribe((free) => {
        this.freeTerms = free;
      });
  }

  activateLast() {
    this.paramsOfRenovation.StartTime = this.selectedFreeTerm.startTime;
    this.paramsOfRenovation.EndTime = this.selectedFreeTerm.endTime;
    this._termOfRenovationService
      .createTermOfRelocation(this.paramsOfRenovation)
      .subscribe((create) => {
        this.termOfRelocationEquipment = create;
      });
  }

  ngOnInit() {
    this.renovationTypeKeys = Object.keys(this.renovationTypes)
      .filter((f) => !isNaN(Number(f)))
      .map(Number);
    this.roomTypeKeys = Object.keys(this.roomTypes)
      .filter((f) => !isNaN(Number(f)))
      .map(Number);
    this.equipmentLogicKeys = Object.keys(this.equipmentLogicTypes)
      .filter((f) => !isNaN(Number(f)))
      .map(Number);

    this.firstFormGroup = this._formBuilder.group({
      firstCtrl: ['', Validators.required],
    });
    this.secondFormGroup = this._formBuilder.group({
      secondCtrl: ['', Validators.required],
    });
    this.thirdFormGroup = this._formBuilder.group({
      startHoursCtrl: ['', Validators.required],
      startMinutesCtrl: ['', Validators.required],
      endHoursCtrl: ['', Validators.required],
      endMinutesCtrl: ['', Validators.required],
    });
    this.forthFormGroup = this._formBuilder.group({
      forthCtrl: ['', Validators.required],
    });
    this.fiveFormGroup = this._formBuilder.group({
      fiveCtrl: ['', Validators.required],
    });
    this.sixFormGroup = this._formBuilder.group({
      sixCtrl: ['', Validators.required],
    });
    this.minDate = new Date(Date.now());
    this.paramsOfRenovation = {
      TypeOfRenovation: 1, // na bekendu 1 je split, a na frontu je 0 split
      StartTime: new Date(),
      EndTime: new Date(),
      DurationInMinutes: 0,
      IdRoomA: -1,
      IdRoomB: -1,
      EquipmentLogic: 0,
      NewNameForRoomA: '',
      NewSectorForRoomA: '',
      NewRoomTypeForRoomA: 0,
      NewNameForRoomB: '',
      NewSectorForRoomB: '',
      NewRoomTypeForRoomB: 0,
    };
  }
}
