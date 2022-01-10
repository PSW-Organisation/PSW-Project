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
  tenderOpenDate: new Date, tenderCloseDate: null, open: true,
  tenderResponses: [ ] }

  tenderResponse: any={}
  tenders: ITender[]=[]
  closedTenders: ITender[] = []
  tenderItem : ITenderItem= {tenderItemName: "", tenderItemQuantity: 0, tenderItemPrice: 0}

  constructor(private tenderService: TendersService) { }

  ngOnInit(): void {
    this.getTenders();
  }
  addTenderItem(tenderItem: any){
    this.newTender.tenderItems.push(Object.assign({}, tenderItem));
    this.tenderItem = {tenderItemName: "", tenderItemQuantity: 0, tenderItemPrice: 0}
  }
  compareDates(date: Date){
    var date2 = new Date(2199, 12,12)
    var date1 = new Date(date)
    var year1 = date1.getFullYear()
    var year2 = date2.getFullYear()

    return year1 < year2

  }
  getTenders(): void {
    this.tenderService.getTenders().subscribe(
      tenders => {
        this.tenders = []
        this.closedTenders = []
        tenders.forEach(tender => {
          if(tender.open) {
            this.tenders.push(tender)
          }
          else {
            this.closedTenders.push(tender);
          }
        })
      }
    )
  }

  saveTender(): void {
    this.tenderService.saveTender(this.newTender).subscribe(
      data => {
        this.newTender = { id: 0, tenderItems: [ ] , tenderOpenDate: new Date, tenderCloseDate: null, open: true, tenderResponses: [ ] };
        this.tenderItem = {tenderItemName: "", tenderItemQuantity: 0, tenderItemPrice: 0}
        this.getTenders();
      },
      err => console.log(err)
    );
  }

  closeTender(id: number):void {
    this.tenderService.closeTender(id).subscribe(
      data => {
        this.newTender = { id: 0, tenderItems: [ ] , tenderOpenDate: new Date, tenderCloseDate: null, open: true, tenderResponses: [ ] };
        this.tenderItem = {tenderItemName: "", tenderItemQuantity: 0, tenderItemPrice: 0}
        this.getTenders();
      },
      err => console.log(err)
    );
  }
}
