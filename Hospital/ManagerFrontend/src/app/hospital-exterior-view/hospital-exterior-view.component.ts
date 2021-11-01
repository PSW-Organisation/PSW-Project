import { Component, OnInit } from '@angular/core';
import { DrawableElement } from './drawableElement';

@Component({
  selector: 'app-hospital-exterior-view',
  templateUrl: './hospital-exterior-view.component.html',
  styleUrls: ['./hospital-exterior-view.component.css']
})
export class HospitalExteriorViewComponent implements OnInit {

  drawableElements: Array<DrawableElement>;

  constructor() {
    this.drawableElements = [];
  }

  ngOnInit(): void {
    // toDo: ovde cemo napraviti pozive ka bekendu ...
    this.drawableElements.push(new DrawableElement(1, "ZGR1", 180, 30, 100, 200, "building"));
    this.drawableElements.push(new DrawableElement(2, "ZGR2", 380, 120, 180, 110, "building"));
    this.drawableElements.push(new DrawableElement(-1, "", 0, 250, 600, 50, "road"));
    this.drawableElements.push(new DrawableElement(-1, "", 0, 290, 50, 110, "road"));
    this.drawableElements.push(new DrawableElement(-1, "", 305, 0, 50, 400, "road"));
    this.drawableElements.push(new DrawableElement(-1, "P", 245, 310, 50, 80, "parking"));
    this.drawableElements.push(new DrawableElement(-1, "P", 380, 20, 50, 80, "parking"));
  }

  youClickedMe(element: DrawableElement): void {
    if (element.type == 'building') {
      alert('clicked ' + element.name);  
    }
  }

  dynamicSelectStyle(element: DrawableElement): string {
    return element.type;
  }



}
