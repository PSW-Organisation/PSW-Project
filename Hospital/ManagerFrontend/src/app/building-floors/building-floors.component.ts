import { AfterViewInit, Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DrawableElement } from '../hospital-exterior-view/drawableElement';
import { IBuilding } from './building';
import { IFloor } from './floor';

@Component({
  selector: 'app-building-floors',
  templateUrl: './building-floors.component.html',
  styleUrls: ['./building-floors.component.css']
})
export class BuildingFloorsComponent implements OnInit {

  drawableElement!: DrawableElement;
  building: IBuilding = {
    floors: [{ level: -1 }, { level: 0 }, { level: 1 }, { level: 2 }]
  };
  selectedFloor: string | null = null;

  constructor(private router: Router,
    private route: ActivatedRoute) {
  }

  ngOnInit(): void {
    this.drawableElement = new DrawableElement(2, "ZGR2", 380, 120, 180, 110, "building");
    this.drawableElement = new DrawableElement(1, "ZGR1", 180, 30, 100, 200, "building");
    this.building = { floors: [{ level: -1 }, { level: 0 }, { level: 1 }, { level: 2 }] };
    this.switchWidthAndHight();
    this.selectedFloor = this.route.snapshot.paramMap.get("id");
  }

  getViewBox(): string {
    return `0 0 ${this.drawableElement.width} ${this.drawableElement.height}`
  }

  switchWidthAndHight(): void {
    if (this.drawableElement.height > this.drawableElement.width) {
      let width = this.drawableElement.width;
      this.drawableElement.width = this.drawableElement.height;
      this.drawableElement.height = width;
    }
  }

  changeFloor(floor: IFloor): void {
    this.router.navigate(['/building/' + this.route.snapshot.paramMap.get("buidingId") + '/floor/' + floor.level]);
  }

  floorChecked(floor: IFloor): boolean {
    return String(floor.level) === this.route.snapshot.paramMap.get("id") ? true : false;
  }

}
