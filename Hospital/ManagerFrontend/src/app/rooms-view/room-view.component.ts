import { Component, OnInit, Input} from '@angular/core';
import { IRoom } from './room';

@Component({
  selector: 'app-room-view',
  templateUrl: './room-view.component.html',
  styleUrls: ['./room-view.component.css']
})
export class RoomViewComponent implements OnInit {

  constructor() { }

  @Input() room! : IRoom ;

  ngOnInit(): void {
  
    
  }
  doorColor : string = 'rgb(255, 255, 255)';

  changeColor() :void {
   
  }

}
