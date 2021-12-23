import { Component, OnInit } from '@angular/core';
import { IMedicine } from './medicine';

@Component({
  selector: 'app-tenders',
  templateUrl: './tenders.component.html',
  styleUrls: ['./tenders.component.css']
})
export class TendersComponent implements OnInit {
medicineItems: IMedicine[]=[];
item : any;
medicine : IMedicine ={name: "", amount: 0, price:0};

  constructor() { }

  ngOnInit(): void {
  }


  addMedicine(medicine: IMedicine){
    this.medicineItems.push(medicine);
  }

}
