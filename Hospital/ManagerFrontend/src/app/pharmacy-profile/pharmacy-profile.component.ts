import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { PharmaciesService } from '../pharmacies-view/pharmacies.service';
import { IPharmacy } from '../pharmacies-view/pharmacy';
import { EditPharmacyService } from '../edit-pharmacy/edit-pharmacy.service';
import { StatisticsService } from '../statistics/statistics.service';
import { Chart, registerables } from 'chart.js';

@Component({
  selector: 'app-pharmacy-profile',
  templateUrl: './pharmacy-profile.component.html',
  styleUrls: ['./pharmacy-profile.component.css']
})
export class PharmacyProfileComponent implements OnInit {
 
pharmacyId: number=0 
pharmacy: any = { pharmacyId:"", pharmacyUrl: "", pharmacyName:"", pharmacyAddress:"", hospitalApiKey:"", comment: ""};
pharmacyApiKey : string = "";
picture: any;

//----------------------------------------STATISTIKA--------------------------------------
  chartOfferInACtiveTender: any;
  chartWinnings: any;
  chartWinningPrice: any;
  chartParticipate: any;
  chartWinningsStat : any;
  chartParticipateStat: any;
  chartWinnerOffersStatX: any;
  chartWinnerOffersStatY: any;
  chartActiveTenderOffersStatX: any;
  chartActiveTenderOffersStatY: any;


  constructor(private route: ActivatedRoute,
    private router: Router, private pharmacyService: PharmaciesService, private statisticService: StatisticsService) { }

  ngOnInit(): void { 
    this.pharmacyId = Number(this.route.snapshot.paramMap.get('id'));
    if(this.pharmacyId) {
      this.showProfilePharmacy(this.pharmacyId);
      
    }
    //----------------------------------------STATISTIKA--------------------------------------
    setTimeout(() => {
      this.getChartWinningsStat(this.pharmacyApiKey);
      this.getChartParticipateStat(this.pharmacyApiKey);
      this.getChartWinnerOffersStat(this.pharmacyApiKey);
      this.getActiveTenderOffersStat(this.pharmacyApiKey);
      setTimeout(() => {
        this.chartOfferInACtiveTender = document.getElementById('offerInACtiveTenderChart');
        this.chartWinnings = document.getElementById('winningsChart');
        this.chartWinningPrice = document.getElementById('winningPriceChart');
        this.chartParticipate = document.getElementById('participateChart');
        Chart.register(...registerables);
        this.loadChartOffesrInACtiveTender();
        this.loadChartWinnings();
        this.loadchartWinningPrice();
        this.loadChartParticipate();
      }, 2000);
    }, 1000)
  }

  showProfilePharmacy(pharmacyId: number) {
    this.pharmacyService.showProfilePharmacy(pharmacyId).subscribe(
      pharmacy =>  {
        var picture = "../../assets/images/" + pharmacy.picture
        this.pharmacy = pharmacy;
        this.pharmacy.picture= picture;
        this.pharmacyApiKey = pharmacy.hospitalApiKey;
        alert("IMAM API KEY")
      }

    )
  }

  editPharmacy(pharmacy: any) {
   this.pharmacyService.editPharmacy(pharmacy).subscribe(
    pharmacy =>  {
    
      this.pharmacy = pharmacy;
      this.showProfilePharmacy(this.pharmacyId);
    }

  )
  }

  //----------------------------------------STATISTIKA--------------------------------------

  getChartWinningsStat(apikey: string){
    //alert("UZIMAM PODATKE ZA CHART")
    this.statisticService.getStatWinnDefeat(apikey).subscribe(
      ret => {this.chartWinningsStat = ret.statistic;}
    )
    alert("UZIMAM PODATKE ZA CHART")
  }

  getChartParticipateStat(apikey: string){
    this.statisticService.getStatParticipate(apikey).subscribe(
      ret => {this.chartParticipateStat = ret.statistic;}
    ) 
  }

  getChartWinnerOffersStat(apikey: string){
    this.statisticService.getStatWinnerOffers(apikey).subscribe(
      ret => {
        this.chartWinnerOffersStatX = ret.x;
        this.chartWinnerOffersStatY = ret.y;
      }
    )
  }

  getActiveTenderOffersStat(apikey: string){
    this.statisticService.getStatActiveTenderOffers(apikey).subscribe(
      ret => {
        this.chartActiveTenderOffersStatX = ret.x;
        this.chartActiveTenderOffersStatY = ret.y;
      }
    )
  }

  loadChartOffesrInACtiveTender()  : void {
    new Chart( this.chartOfferInACtiveTender, {
      type: 'bar',
      data: {
          labels: this.chartActiveTenderOffersStatX,
          datasets: [{
              label: '#ponude u toku aktivnog tendera',
              data: this.chartActiveTenderOffersStatY,
              backgroundColor: [
                  'rgba(255, 99, 132, 0.2)',
                  'rgba(54, 162, 235, 0.2)',
                  'rgba(255, 206, 86, 0.2)',
                  'rgba(75, 192, 192, 0.2)',
                  'rgba(153, 102, 255, 0.2)',
                  'rgba(255, 159, 64, 0.2)'
              ],
              borderColor: [
                  'rgba(255, 99, 132, 1)',
                  'rgba(54, 162, 235, 1)',
                  'rgba(255, 206, 86, 1)',
                  'rgba(75, 192, 192, 1)',
                  'rgba(153, 102, 255, 1)',
                  'rgba(255, 159, 64, 1)'
              ],
              borderWidth: 1
          }]
      },
      options: {
          scales: {
              y: {
                  beginAtZero: true
              }
          }
      }
  }
    )
  }

  loadChartWinnings() : void {
    alert("CRTAM CHART")
    new Chart( this.chartWinnings,{
      type: 'pie',
      data: {
        labels: [
          'Osvojila',
          'Izgubila'
        ],
        datasets: [{
          label: 'Pobede u tenderima',
          data: this.chartWinningsStat,
          backgroundColor: [
            'rgb(255, 99, 132)',
            'rgb(54, 162, 235)',
            'rgb(255, 205, 86)'
          ],
          hoverOffset: 4
        }]
      }
    })
  }

  loadchartWinningPrice(): void {
    new Chart( this.chartWinningPrice, {
      type: 'bar',
      data: {
          labels: this.chartWinnerOffersStatX,
          datasets: [{
              label: '# pobednicke ponude',
              data: this.chartWinnerOffersStatY,
              backgroundColor: [
                  'rgba(255, 99, 132, 0.2)',
                  'rgba(54, 162, 235, 0.2)',
                  'rgba(255, 206, 86, 0.2)',
                  'rgba(75, 192, 192, 0.2)',
                  'rgba(153, 102, 255, 0.2)',
                  'rgba(255, 159, 64, 0.2)'
              ],
              borderColor: [
                  'rgba(255, 99, 132, 1)',
                  'rgba(54, 162, 235, 1)',
                  'rgba(255, 206, 86, 1)',
                  'rgba(75, 192, 192, 1)',
                  'rgba(153, 102, 255, 1)',
                  'rgba(255, 159, 64, 1)'
              ],
              borderWidth: 1
          }]
      },
      options: {
          scales: {
              y: {
                  beginAtZero: true
              }
          }
      }
  }
    )
  }

  loadChartParticipate(): void {
    new Chart( this.chartParticipate,{
      type: 'pie',
      data: {
        labels: [
          'Ucetvovala',
          'Nije ucestvovala'
        ],
        datasets: [{
          label: 'Ucesca',
          data: this.chartParticipateStat,
          backgroundColor: [
            'rgb(255, 99, 132)',
            'rgb(54, 162, 235)',
            'rgb(255, 205, 86)'
          ],
          hoverOffset: 4
        }]
      }
    })
  }


}
