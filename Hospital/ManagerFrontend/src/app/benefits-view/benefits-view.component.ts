import { Component, OnInit } from '@angular/core';
import { BenefitsService } from './benefits.service';
import { Benefits } from './benefits';
@Component({
  selector: 'app-benefits-view',
  templateUrl: './benefits-view.component.html',
  styleUrls: ['./benefits-view.component.css']
})
export class BenefitsViewComponent implements OnInit {
  benefits: Benefits[] = []
  errorMessage: string = "";

  constructor(private _benefitsService: BenefitsService) { }

  ngOnInit(): void {
      this.refreshBenefits();
  }
  refreshBenefits(){
    this._benefitsService.getBenefits().subscribe(
      benefits => {
        this.benefits = benefits;
      },
      error => this.errorMessage = <any> error
    );
  }
  unpublishBenefit(benefit: any){
    this._benefitsService.unpublishBenefit(benefit).subscribe(data =>
      {this.refreshBenefits();}
      );
  }
}
