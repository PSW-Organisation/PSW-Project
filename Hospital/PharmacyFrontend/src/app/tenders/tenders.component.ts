import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { ITender } from './tender';
import { ITenderItem } from './tenderItem';
import { ITenderResponse } from './tenderResponse';
import { TendersService } from './tenders.service';
import {
  trigger,
  state,
  style,
  animate,
  transition,
  // ...
} from '@angular/animations';

@Component({
  selector: 'app-tenders',
  templateUrl: './tenders.component.html',
  styleUrls: ['./tenders.component.css']
})
export class TendersComponent implements OnInit {
  tenderItems: ITenderItem[]=[];
  item : any;
  modalTender: ITender = {id: 0, tenderItems: [ ] ,
    tenderOpenDate: new Date, tenderCloseDate: new Date, open: true, isWon: false};
  tenders: ITender[] = [];
  tenderOffer: ITenderResponse = {tender: {id: 0, tenderItems: [ ] ,
    tenderOpenDate: new Date, tenderCloseDate: new Date, open: true, isWon: false}, tenderId: 0, tenderItems: []}
  tenderItem : ITenderItem ={tenderItemName: "", tenderItemQuantity: 0, tenderItemPrice:0};
  constructor(private tenderService: TendersService, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.getTenders()
  }
  addMedicine(medicine: ITenderItem){
    this.tenderItems.push(Object.assign({}, medicine));
  }
  setModalTender(tender: any): void{
    this.modalTender = tender
    console.log(this.modalTender)
  }
  closeTender(tender: ITender){
    this.tenderService.closeTender(tender).subscribe(
      res => {
        alert("Tender has been closed");
        this.sendNotificationForConfirmation("Flos pharmacy confirmed her offer. You can close Tender " + tender.id);
      }
    );
  }
  sendTenderOffer(): void{
    this.tenderOffer.tender = this.modalTender
    this.tenderOffer.tenderId = this.modalTender.id
    this.tenderOffer.tenderItems = this.tenderItems;
    console.log('cao')
    this.tenderService.sendOffer(this.tenderOffer).subscribe(
      data=>{
        this.tenderOffer = {tender: {id: 0, tenderItems: [ ] ,
          tenderOpenDate: new Date, tenderCloseDate: new Date, open: true, isWon: false}, tenderId: 0, tenderItems: []};
          this.getTenders();
          this.sendNotificationToHospital();

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
sendNotificationToHospital() {
  this.tenderService.sendNotificationToHospital("You have new tender offer for Tender " + this.modalTender.id + "from Flos Pharmacy. ")
}
sendNotificationForConfirmation(message: string) {
  this.tenderService.sendNotificationConfirmationToHospital(message);
}
showToastrSuccess(message: string, title: string){
  this.toastr.success(message, title,
   { timeOut: 3000, 
    progressBar: true,
     progressAnimation: 'increasing'})
}
}