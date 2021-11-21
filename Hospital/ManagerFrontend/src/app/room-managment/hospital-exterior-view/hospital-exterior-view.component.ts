import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DrawableElement } from './drawableElement';
import { HospitalExteriorService } from './hospital-exterior.service';

@Component({
  selector: 'app-hospital-exterior-view',
  templateUrl: './hospital-exterior-view.component.html',
  styleUrls: ['./hospital-exterior-view.component.css']
})
export class HospitalExteriorViewComponent implements OnInit {

  drawableElements: Array<DrawableElement>;

  constructor(private router: Router, private _hospitalService: HospitalExteriorService) {
    this.drawableElements = [];
  }

  ngOnInit(): void {
    // toDo: ovde cemo napraviti pozive ka bekendu ...
    /*
    this.drawableElements.push(new DrawableElement(1, "ZGR1", 180, 30, 100, 200, "building"));
    this.drawableElements.push(new DrawableElement(2, "ZGR2", 380, 120, 180, 110, "building"));
    this.drawableElements.push(new DrawableElement(-1, "", 0, 250, 600, 50, "road"));
    this.drawableElements.push(new DrawableElement(-1, "", 0, 290, 50, 110, "road"));
    this.drawableElements.push(new DrawableElement(-1, "", 305, 0, 50, 400, "road"));
    this.drawableElements.push(new DrawableElement(-1, "P", 245, 310, 50, 80, "parking"));
    this.drawableElements.push(new DrawableElement(-1, "P", 380, 20, 50, 80, "parking"));
    */

    this._hospitalService.getExteriorGraphic().subscribe(exteriorGraphic => this.drawableElements = exteriorGraphic);

  }

  youClickedMe(element: DrawableElement): void {
    if (element.type == 'building') {
      this.router.navigate(['roomManagment/building/' + element.idElement + '/floor/0']);
    }
  }

  dynamicSelectStyle(element: DrawableElement): string {
    return element.type;
  }



}
