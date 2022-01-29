import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDatepickerInputEvent } from '@angular/material/datepicker';
import { filter } from 'rxjs-compat/operator/filter';
import { IRoom } from '../rooms-view/room';
import { RoomService } from '../rooms-view/rooms.service';
import { EventMoveEquipment, IMoveEquipmentActions } from './moveEquipmentActions';
import { IEquipment, IEquipmentQuantity, IFreeTerms, IParamsOfRelocationEquipment, ParamsOfRelocationEquipment } from './room-equipment';

import { RoomEqupimentService } from './room-equpiment.service';
import { ToastrService } from 'ngx-toastr';


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
  eventMoveEquipment!:  EventMoveEquipment; 
  filteredequipmentActions: IMoveEquipmentActions[] = [];
  endYear!: number;
  endMonth!: number;
  endDay!: number;
  endHours!: number;
  endMinutes!: number;
  
  duration!: number;

  savedActive: boolean = false;

  showRow : boolean = false;

  equipmentActions!: IMoveEquipmentActions[];

  title: string = "Event sourcing";

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
    private _roomService: RoomService,
    private toastr: ToastrService) {
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

  activateThirdFromAction(equipmentAction: IMoveEquipmentActions){
    let selectedEquipmentAction =this.equipmentsDTO.find((equ)=> equ.name === equipmentAction.nameOfEquipment);
    if(selectedEquipmentAction !=undefined ){
      this.selectedEquipment ={ 
      name: equipmentAction.nameOfEquipment,
      quantity :100
      };
    }
    else{
      this.toastr.error('No such equipment name anymore!', 'Try with stepper!');
      this.firstFormGroup = this._formBuilder.group({
        firstCtrl: ['', Validators.required],
      });
      this.secondFormGroup = this._formBuilder.group({
        secondCtrl: ['', Validators.required],
      });
      this.savedActive = false;
      return;
    }
    this._roomEquipmentService.getRoomEquipment(equipmentAction.nameOfEquipment).subscribe(roomEquipment => {this.equipments = roomEquipment
      if(this.equipments != undefined){
        let selectedRoomAction = this.equipments.find((equ)=> equ.roomId === equipmentAction.sourceRoomID);  
        if(selectedRoomAction !=undefined ){
        this.selectedRoomWithEquipment ={
          id: 1,
          quantity: 10, 
          name: equipmentAction.nameOfEquipment, 
          type: "",
          roomId: equipmentAction.sourceRoomID
        }
        }
        else{
          this.toastr.error('Not enough quantity in the selected source room anymore!', 'Try with stepper!');
          this.firstFormGroup = this._formBuilder.group({
            firstCtrl: ['', Validators.required],
          });
          this.secondFormGroup = this._formBuilder.group({
            secondCtrl: ['', Validators.required],
          });
          this.savedActive = false;
          return;
        }
      }
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
    this.paramsOfRelocationEquipment.EndTime = new Date(Date.UTC(this.endYear, this.endMonth, this.endDay, this.endHours, this.endMinutes));
    this.paramsOfRelocationEquipment.DurationInMinutes = this.duration;
    this._roomEquipmentService.getAllPosibleRelocationTerms(this.paramsOfRelocationEquipment).subscribe(free => {this.freeTerms = free});
  }

  
  activateLast() {
    this.paramsOfRelocationEquipment.StartTime = this.selectedFreeTerm.startTime;
    this.paramsOfRelocationEquipment.EndTime = this.selectedFreeTerm.endTime;
    this._roomEquipmentService.createTermOfRelocation(this.paramsOfRelocationEquipment).subscribe(create => { this.termOfRelocationEquipment = create; 
    this.eventMoveEquipment = {
        idUser: "jagodica",
        timeStamp: new Date(),
        sourceRoomID: this.paramsOfRelocationEquipment.IdSourceRoom,
        destinationRoomID: this.paramsOfRelocationEquipment.IdDestinationRoom,
        nameOfEquipment:  this.paramsOfRelocationEquipment.NameOfEquipment
      };
    this._roomEquipmentService.addMoveEquipmentAction(this.eventMoveEquipment);
    });
  }

  savedActionsOffers(event:Event){
     event.preventDefault();
     this.savedActive = true;
     this.firstFormGroup = this._formBuilder.group({
      firstCtrl: ['', !Validators.required],
    });
    this.secondFormGroup = this._formBuilder.group({
      secondCtrl: ['', !Validators.required],
    });
  }

  filterRows(){
    this.filteredequipmentActions = this.equipmentActions;
    this.filteredequipmentActions = this.filteredequipmentActions.filter(a => a.numberOfEvents >= 2);
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
    this._roomEquipmentService.getAllEventActions("jagodica").subscribe(equipmentActions =>{ this.equipmentActions = equipmentActions;     this.filterRows();
    });
  }
}
