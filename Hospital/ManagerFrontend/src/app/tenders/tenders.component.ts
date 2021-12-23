import { Component, OnInit } from '@angular/core';
import { IMedicine } from './medicine';
import { ITender } from './tender';
import { TenderService } from './tender.service';

@Component({
  selector: 'app-tenders',
  templateUrl: './tenders.component.html',
  styleUrls: ['./tenders.component.css']
})
export class TendersComponent implements OnInit {
  newTender: any={ id: 0, medicineTransactions: [ { medicineName: "aaaaaaaaaa", medicineAmount: 0}] , 
                  tenderOpenDate: "", tenderCloseDate: "", open: true, 
                tenderResponses: [{}] }
  tenderResponse: any={}
  tenders: ITender[]=[]
  medicine : IMedicine= {medicineName: "", medicineAmount: 0}


  constructor(private tenderService: TenderService) { }

  ngOnInit(): void {
    this.loadTenders();
  }

  loadTenders(){}
       
addNewTender(tender: any){
 this.tenders = tender;
}
addMedicine(medicine: any){
  this.newTender.medicineTransactions.push(medicine);
}
  
}
