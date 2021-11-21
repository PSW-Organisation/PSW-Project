import {
  Component,
  Input,
  OnInit,
  ɵAPP_ID_RANDOM_PROVIDER,
} from '@angular/core';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { IRoomGraphic } from '../roomGraphic';
import { RoomService } from '../rooms.service';
import { IFloor } from './floor';
import { HttpClient } from '@angular/common/http';
import { IRoom, RoomType } from '../room';

@Component({
  selector: 'app-building-floors',
  templateUrl: './building-floors.component.html',
  styleUrls: ['./building-floors.component.css'],
})
export class BuildingFloorsComponent implements OnInit {
  @Input() updatedRoom!: IRoom;
  selectedFloorNumber: number = 0;
  floors!: Array<IFloor>;
  selectedFloor!: IFloor;
  errorMessage!: string;
  roomGraphic!: IRoomGraphic;
  editing: boolean = false;
  postId!: number;

  constructor(
    private _router: Router,
    private _route: ActivatedRoute,
    private _roomService: RoomService,
    private _http: HttpClient
  ) {}

  ngOnInit(): void {
    this.setSelectedFloor();
    this.getFloors();
  }

  edit() {
    this.editing = true;
  }

  change() {
    this._http
      .put<any>('http://localhost:42789/api/rooms', this.updatedRoom)
      .subscribe((data) => {
        this.postId = data.id;
        this.floors[this.selectedFloorNumber].roomGraphics.filter(
          (r) => r.id === this.postId
        )[0].room = data;

        console.log(data);
      });
    this.editing = false;
  }

  private getFloors() {
    this._roomService.getFloors().subscribe(
      (floors) => {
        this.floors = floors.filter((floor: IFloor) => {
          return (
            floor.buildingId === this._route.snapshot.paramMap.get('buidingId')
          );
        });
        this.selectedFloor = this.floors.filter((floor) => {
          return floor.floor === this.selectedFloorNumber;
        })[0];
      },
      (error) => (this.errorMessage = <any>error)
    );
  }

  private setSelectedFloor() {
    this._route.paramMap.subscribe((params: ParamMap) => {
      this.selectedFloorNumber = +params.get('floorId')!;
    });
  }

  changeFloor(floor: IFloor): void {
    this.selectedFloor = floor;
    this._router.navigate([
      'roomManagment/building/' +
        this._route.snapshot.paramMap.get('buidingId') +
        '/floor/' +
        floor.floor,
    ]);
  }

  floorChecked(floor: IFloor): boolean {
    return String(floor.floor) === this._route.snapshot.paramMap.get('floorId')
      ? true
      : false;
  }
}
