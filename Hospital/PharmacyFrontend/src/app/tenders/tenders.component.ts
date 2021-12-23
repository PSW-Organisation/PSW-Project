import { Component, OnInit } from '@angular/core';
import { ITenderItem } from './tenderItem';

@Component({
  selector: 'app-tenders',
  templateUrl: './tenders.component.html',
  styleUrls: ['./tenders.component.css']
})
export class TendersComponent implements OnInit {
  medicineItems: ITenderItem[]=[];
  item : any;
  medicine : ITenderItem ={name: "", amount: 0, price:0};
  constructor() { }

  ngOnInit(): void {
  }
  addMedicine(medicine: ITenderItem){
    this.medicineItems.push(medicine);
  }

}
