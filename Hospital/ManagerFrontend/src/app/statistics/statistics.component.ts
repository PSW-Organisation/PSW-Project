import { Component, Input, OnInit } from '@angular/core';
import {Chart, registerables} from 'chart.js'
import { StatisticsService } from './statistics.service';

@Component({
  selector: 'app-statistics',
  templateUrl: './statistics.component.html',
  styleUrls: ['./statistics.component.css']
})
export class StatisticsComponent implements OnInit {
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
  @Input() apiKey: string = "";

  constructor(private statisticService: StatisticsService) { }

  ngOnInit(): void {
    this.getChartWinningsStat(this.apiKey);
    this.getChartParticipateStat("bc56df25-0d34-4801-b76a-931e61b4c752");
    this.getChartWinnerOffersStat("bc56df25-0d34-4801-b76a-931e61b4c752");
    this.getActiveTenderOffersStat("bc56df25-0d34-4801-b76a-931e61b4c752");
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
    }, 1000);
  }

  getChartWinningsStat(apikey: string){
    this.statisticService.getStatWinnDefeat(apikey).subscribe(
      ret => {this.chartWinningsStat = ret.statistic;}
    )
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