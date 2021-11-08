import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';
import { Router } from '@angular/router';
import { SidenavService } from 'src/app/shared/responsive-sidebar/sidenav.service';
import { IFloor } from '../building-floors/floor';
import { IRoom } from '../room';

@Component({
  selector: 'app-rooms-view',
  templateUrl: './rooms-view.component.html',
  styleUrls: ['./rooms-view.component.css'],
})
export class RoomsViewComponent implements OnInit {

  @Input() floor!: IFloor;
  @Output() redirect:EventEmitter<any> = new EventEmitter();
  fillColor!: string;

  constructor(private _sidenav: SidenavService,
              private _router: Router) { }

  ngOnInit(): void {
  }

  roomColor(type: string): string {

    if (type === 'OperacionaSala') {
      this.fillColor = '#FFE5CC';
    }
    else if (type === 'Salter') {
      this.fillColor = '#999FFF';
    }
    else if (type === 'SalaZaPregled') {
      this.fillColor = '#FBD9FC';
    }
    else if (type === 'WC') {
      this.fillColor = '#CCFFFF';
    }
    else if (type === 'Cekaonica') {
      this.fillColor = '#E5FFCC';
    }
    return this.fillColor;
  }

  getViewBox(width: number, height: number): string {
    return `0 0 ${width} ${height}`
  }

  toggleSidenav(room: IRoom) {
    this.redirect.emit(room);
    this._sidenav.open();
  }
}
