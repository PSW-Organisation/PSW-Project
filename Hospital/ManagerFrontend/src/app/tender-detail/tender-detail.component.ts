import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TenderDetailService } from './tender-detail.service';

@Component({
  selector: 'app-tender-detail',
  templateUrl: './tender-detail.component.html',
  styleUrls: ['./tender-detail.component.css']
})
export class TenderDetailComponent implements OnInit {
  tender: any={ id: 0, tenderItems: [ ] , 
  tenderOpenDate: new Date, tenderCloseDate: new Date, open: true, 
  tenderResponses: [ ] }
  tenderId: number = 0

  constructor(private route: ActivatedRoute,
              private tenderDetailService: TenderDetailService) { }

  ngOnInit(): void {
    this.tenderId = Number(this.route.snapshot.paramMap.get('id'));
    if(this.tenderId) {
      this.getTender(this.tenderId);
    }
  }

  getTender(id: number): void {
    this.tenderDetailService.getTender(id).subscribe(
      tender => {
        this.tender = tender;
      }
    )
  }

  acceptOffer(id: number): void {
    this.tenderDetailService.acceptOffer(id).subscribe(
      response => {this.getTender(this.tenderId); }
    )
  }
}
