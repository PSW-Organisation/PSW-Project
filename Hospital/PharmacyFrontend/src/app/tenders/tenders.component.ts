import { Component, OnInit } from '@angular/core';
import { ITender } from './tender';
import { ITenderItem } from './tenderItem';
import { ITenderResponse } from './tenderResponse';
import { TendersService } from './tenders.service';

@Component({
  selector: 'app-tenders',
  templateUrl: './tenders.component.html',
  styleUrls: ['./tenders.component.css']
})
export class TendersComponent implements OnInit {
  tenderItems: ITenderItem[]=[];
  item : any;
  modalTender: ITender = {id: 0, tenderItems: [ ] ,
    tenderOpenDate: new Date, tenderCloseDate: new Date, open: true};
  tenders: ITender[] = [];
  tenderOffer: ITenderResponse = {tender: {id: 0, tenderItems: [ ] ,
    tenderOpenDate: new Date, tenderCloseDate: new Date, open: true}, tenderId: 0, tenderItems: []}
  tenderItem : ITenderItem ={tenderItemName: "", tenderItemQuantity: 0, tenderItemPrice:0};
  constructor(private tenderService: TendersService) { }

  ngOnInit(): void {
    this.getTenders()
  }
  addMedicine(medicine: ITenderItem){
    this.tenderItems.push(medicine);
  }
  setModalTender(tender: any): void{
    this.modalTender = tender
    console.log(this.modalTender)
  }

  sendTenderOffer(): void{
    this.tenderOffer.tender = this.modalTender
    this.tenderOffer.tenderId = this.modalTender.id
    this.tenderOffer.tenderItems = this.tenderItems;
    console.log('cao')
    this.tenderService.sendOffer(this.tenderOffer).subscribe(
      data=>{
        this.tenderOffer = {tender: {id: 0, tenderItems: [ ] ,
          tenderOpenDate: new Date, tenderCloseDate: new Date, open: true}, tenderId: 0, tenderItems: []};
          this.getTenders();

      }, err=> console.log(err)
    );
  }
  getTenders(): void {
    console.log('cao')
    this.tenderService.getTenders().subscribe(
      tenders => {
        this.tenders = tenders;
      }
    )
  }

}
