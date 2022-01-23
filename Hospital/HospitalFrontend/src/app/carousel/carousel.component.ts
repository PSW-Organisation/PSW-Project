import { Component, OnInit } from '@angular/core';
import * as moment from 'moment';
import { filter } from 'rxjs/operators';
import { forEach } from 'xregexp/types';
import { AdsService } from './ads.service';
import { Advertisement } from './advertisement';

@Component({
  selector: 'app-carousel',
  templateUrl: './carousel.component.html',
  styleUrls: ['./carousel.component.css']
})
export class CarouselComponent implements OnInit {
  ads: Advertisement[] = [];
  filteredAds: Advertisement[] = [];

  constructor(private adsService: AdsService) { }

  ngOnInit(): void {
    this.adsService.getAllAds().subscribe({
      next: response => {
        this.ads = response
        this.ads.forEach(ad => this.filterAds(ad))
        //console.log(this.filteredAds)
      }
    })
  }

  filterAds(ad : any){
    if(moment(ad.creationDate).isBefore() && moment(ad.promotionEndTime).isAfter()){
      this.filteredAds.push(ad)
    }
  }

  checkIfEmpty(){
    //this.filteredAds = []
    if(this.filteredAds.length === 0)
      return false
    return true
  }

  findImage(i : number) : string {
    if(i % 3 == 0)
      return "assets/images/med1.jpg"
    if(i % 3 == 1)
      return "assets/images/med2.jpg"
    return "assets/images/med3.jpg"
  }
}
