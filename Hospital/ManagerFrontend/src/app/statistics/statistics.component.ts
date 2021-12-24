import { Component, OnInit } from '@angular/core';
import {Chart, registerables} from 'chart.js'

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
  constructor() { }

  ngOnInit(): void {
    this.chartOfferInACtiveTender = document.getElementById('offerInACtiveTenderChart');
    this.chartWinnings = document.getElementById('winningsChart');
    this.chartWinningPrice = document.getElementById('winningPriceChart');
    this.chartParticipate = document.getElementById('participateChart');
    Chart.register(...registerables);
    this.loadChartOffesrInACtiveTender();
    this.loadChartWinnings();
    this.loadchartWinningPrice();
    this.loadChartParticipate();
  }

  loadChartOffesrInACtiveTender()  : void {
    new Chart( this.chartOfferInACtiveTender, {
      type: 'bar',
      data: {
          labels: ['10.12.2021.', '16.12.2021.', '20.12.2021.', '24.12.2021.'],
          datasets: [{
              label: '#ponude u toku aktivnog tendera',
              data: [80000, 60000, 70000, 50000],
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
          data: [6,2],
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
          labels: ['11.01.2021.', '23.05.2021.', '20.06.2021.', '24.09.2021.', '24.10.2021.'],
          datasets: [{
              label: '# pobednicke ponude',
              data: [80000, 60000, 70000, 50000, 65000],
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
          data: [6,3],
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
