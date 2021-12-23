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
  newTender: any={ id: 0, medicineTransactions: [ ] , 
  tenderOpenDate: "", tenderCloseDate: "", open: true, 
tenderResponses: [{}] }
tenderResponse: any={}
tenders: ITender[]=[]
medicine : ITenderItem= {medicineName: "", medicineAmount: 0}

  constructor(private tenderService: TendersService) { }

  ngOnInit(): void {
  }
  addMedicine(medicine: any){
    this.newTender.medicineTransactions.push(medicine);
  }
}
