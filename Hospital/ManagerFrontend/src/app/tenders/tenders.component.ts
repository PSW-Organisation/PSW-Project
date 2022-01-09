import { Component, OnInit } from '@angular/core';
import { ITender } from './tender';
import { ITenderItem } from './tenderItem';
import { TendersService } from './tenders.service';

@Component({
  selector: 'app-tenders',
  templateUrl: './tenders.component.html',
  styleUrls: ['./tenders.component.css']
})
export class TendersComponent implements OnInit {
  newTender: any={ id: 0, tenderItems: [ ] , 
  tenderOpenDate: new Date, tenderCloseDate: new Date, open: true, 
  tenderResponses: [ ] }

  tenderResponse: any={}

  tenders: ITender[]=[]
  tenderItem : ITenderItem= {tenderItemName: "", tenderItemQuantity: 0, tenderItemPrice: 0}

  constructor(private tenderService: TendersService) { }

  ngOnInit(): void {
    this.getTenders();
  }
  addTenderItem(tenderItem: any){
    this.newTender.tenderItems.push(Object.assign({}, tenderItem));
    this.tenderItem = {tenderItemName: "", tenderItemQuantity: 0, tenderItemPrice: 0}
  }

  getTenders(): void {
    this.tenderService.getTenders().subscribe(
      tenders => {
        this.tenders = tenders;
      }
    )
  }

  saveTender(): void {
    this.tenderService.saveTender(this.newTender).subscribe(
      data => {
        this.newTender = { id: 0, tenderItems: [ ] , tenderOpenDate: new Date, tenderCloseDate: new Date, open: true, tenderResponses: [ ] };
        this.tenderItem = {tenderItemName: "", tenderItemQuantity: 0, tenderItemPrice: 0}
        this.getTenders();
      },
      err => console.log(err)
    );
  }
}
