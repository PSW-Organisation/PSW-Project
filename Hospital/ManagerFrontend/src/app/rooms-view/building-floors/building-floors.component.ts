import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { DrawableElement } from '../../hospital-exterior-view/drawableElement';
import { IRoom } from '../room';
import { RoomService } from '../rooms.service';
import { IFloor } from './floor';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-building-floors',
  templateUrl: './building-floors.component.html',
  styleUrls: ['./building-floors.component.css']
})
export class BuildingFloorsComponent implements OnInit {

  drawableElement!: DrawableElement;
  selectedFloorNumber: number = 0;
  floors!: Array<IFloor>;
  selectedFloor!: IFloor;
  errorMessage!: string;
  room!: IRoom;
  editing: boolean = false;
  postId!: string;
  payload = { type: 'ROOM' };

  constructor(private _router: Router,
              private _route: ActivatedRoute,
              private _roomService: RoomService,
              private _http: HttpClient) { }
  
  ngOnInit(): void {
    this.setSelectedFloor();
    this.getFloors();
  }

  edit() {
    this.editing = true;
  }

  change() {
    this._http
      .put<any>('https://jsonplaceholder.typicode.com/posts/1', this.payload)
      .subscribe((data) => (this.postId = data.id));
  }
  
  private getFloors() {
    this._roomService.getRooms()
      .subscribe(
        floors => {
          this.floors = floors;
          this.selectedFloor = this.floors.filter((floor) => {
            return floor.floor === this.selectedFloorNumber;
          })[0];
        },
        error => this.errorMessage = <any>error
      );
  }

  private setSelectedFloor() {
    this._route.paramMap.subscribe((params: ParamMap) => {
      this.selectedFloorNumber = +params.get('floorId')!;
    });
  }

  getViewBox(): string {
    return `0 0 ${this.drawableElement.width} ${this.drawableElement.height}`
  }

  changeFloor(floor: IFloor): void {
    this.selectedFloor = floor;
    this._router.navigate(['/building/' + this._route.snapshot.paramMap.get("buidingId") + '/floor/' + floor.floor]);
  }

  floorChecked(floor: IFloor): boolean {
    return String(floor.floor) === this._route.snapshot.paramMap.get("floorId") ? true : false;
  }

}
