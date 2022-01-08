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
  tenderOpenDate: "", tenderCloseDate: "", open: true, 
  tenderResponses: [{}] }

  tenderResponse: any={}

  tenders: ITender[]=[]
  tenderItem : ITenderItem= {tenderItemName: "", tenderItemQuantity: 0, tenderItemPrice: 0}

  constructor(private tenderService: TendersService) { }

  ngOnInit(): void {
    this.getTenders();
  }
  addTenderItem(medicine: any){
    this.newTender.tenderItems.push(medicine);
  }

  getTenders(): void {
    this.tenderService.getTenders().subscribe(
      tenders => {
        this.tenders = tenders;
      }
    )
  }
}
