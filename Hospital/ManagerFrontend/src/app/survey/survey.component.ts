import { AfterViewInit, Component, Inject } from "@angular/core";
import { OnInit } from "@angular/core";
import {
  Chart, LinearScale, BarController, BarElement, CategoryScale,
  Decimation, Filler, Title, Tooltip, SubTitle
} from "chart.js";
import { DOCUMENT } from '@angular/common';
import { SurveyService } from "./survey.service";
import { SurveyStats } from "./surveyStats";
Chart.register(LinearScale, BarController, BarElement, CategoryScale, Decimation, Filler, Title, Tooltip, SubTitle);

@Component({
  selector: 'survey',
  templateUrl: './survey.component.html',
  styleUrls: ['./survey.component.css']
})

export class SurveyComponent implements OnInit {
  stats: SurveyStats[] = [];
  staffAverage: number = 0;
  hospitalAverage: number = 0;
  portalAverage: number = 0;
  allQueastionsAverage: number = 0; 
  constructor(@Inject(DOCUMENT) private document: Document, private service: SurveyService) { }
  ngOnInit(): void {
    this.getSurveyStats();
  }
  initSurveyStats() {
    let ctx1 = 'myChart1';
    let ctx2 = 'myChart2';
    let ctx3 = 'myChart3';
    let delayed: any;
    let myChart1 = new Chart(ctx1, {
      type: 'bar',
      data: {
        labels: ['Question 1', 'Question 2', 'Question 3', 'Question 4', 'Question 5'],
        datasets: [{
          data: [this.stats[0].avg.toFixed(2), this.stats[1].avg.toFixed(2), this.stats[2].avg.toFixed(2), this.stats[3].avg.toFixed(2), this.stats[4].avg.toFixed(2)],
          backgroundColor: [
            'rgba(255, 99, 132, 0.2)',
            'rgba(54, 162, 235, 0.2)',
            'rgba(255, 206, 86, 0.2)',
            'rgba(75, 192, 192, 0.2)',
            'rgba(153, 102, 255, 0.2)'
          ],
          borderColor: [
            'rgba(255, 99, 132, 1)',
            'rgba(54, 162, 235, 1)',
            'rgba(255, 206, 86, 1)',
            'rgba(75, 192, 192, 1)',
            'rgba(153, 102, 255, 1)'
          ],
          borderWidth: 1,
        }]
      },
      options: {
        animation: {
          onComplete: () => {
            delayed = true;
          },
          delay: (context) => {
            let delay = 0;
            delay = context.dataIndex * 300 + context.datasetIndex * 100;
            return delay;
          },
        },
        scales: {
          x: {
            stacked: true,
          },
          y: {
            stacked: true,
            max: 5
          }
        },
        responsive: true,
        plugins: {
          legend: {
            position: 'top',
          },
          title: {
            display: true,
            text: 'STAFF'
          },
          tooltip: {
            callbacks: {
              label: (context) => {
                if (context.label === 'Question 1')
                  return [`average: ${context.raw}`, `one star: ${this.stats[0].one}`, `two stars: ${this.stats[0].two}`, `three stars: ${this.stats[0].three}`, `four stars: ${this.stats[0].four}`, `five stars: ${this.stats[0].five}`]
                else if (context.label === 'Question 2')
                  return [`average: ${context.raw}`, `one star: ${this.stats[1].one}`, `two stars: ${this.stats[1].two}`, `three stars: ${this.stats[1].three}`, `four stars: ${this.stats[1].four}`, `five stars: ${this.stats[1].five}`]
                else if (context.label === 'Question 3')
                  return [`average: ${context.raw}`, `one star: ${this.stats[2].one}`, `two stars: ${this.stats[2].two}`, `three stars: ${this.stats[2].three}`, `four stars: ${this.stats[2].four}`, `five stars: ${this.stats[2].five}`]
                else if (context.label === 'Question 4')
                  return [`average: ${context.raw}`, `one star: ${this.stats[3].one}`, `two stars: ${this.stats[3].two}`, `three stars: ${this.stats[3].three}`, `four stars: ${this.stats[3].four}`, `five stars: ${this.stats[3].five}`]
                return [`average: ${context.raw}`, `one star: ${this.stats[4].one}`, `two stars: ${this.stats[4].two}`, `three stars: ${this.stats[4].three}`, `four stars: ${this.stats[4].four}`, `five stars: ${this.stats[4].five}`]
              }
            }
          }
        },

      }
    });
    let myChart2 = new Chart(ctx2, {
      type: 'bar',
      data: {
        labels: ['Question 1', 'Question 2', 'Question 3', 'Question 4', 'Question 5'],
        datasets: [{
          data: [this.stats[5].avg.toFixed(2), this.stats[6].avg.toFixed(2), this.stats[7].avg.toFixed(2), this.stats[8].avg.toFixed(2), this.stats[9].avg.toFixed(2)],
          backgroundColor: [
            'rgba(255, 99, 132, 0.2)',
            'rgba(54, 162, 235, 0.2)',
            'rgba(255, 206, 86, 0.2)',
            'rgba(75, 192, 192, 0.2)',
            'rgba(153, 102, 255, 0.2)'
          ],
          borderColor: [
            'rgba(255, 99, 132, 1)',
            'rgba(54, 162, 235, 1)',
            'rgba(255, 206, 86, 1)',
            'rgba(75, 192, 192, 1)',
            'rgba(153, 102, 255, 1)'
          ],
          borderWidth: 1
        }]
      },
      options: {
        animation: {
          onComplete: () => {
            delayed = true;
          },
          delay: (context) => {
            let delay = 0;
            delay = context.dataIndex * 300 + context.datasetIndex * 100;
            return delay;
          },
        },
        scales: {
          x: {
            stacked: true,
          },
          y: {
            stacked: true,
            max: 5
          }
        },
        responsive: true,
        plugins: {
          legend: {
            position: 'top',
            labels: {
            }
          },
          title: {
            display: true,
            text: 'HOSPITAL'
          },
          tooltip: {
            callbacks: {
              label: (context) => {
                if (context.label === 'Question 1')
                  return [`average: ${context.raw}`, `one star: ${this.stats[5].one}`, `two stars: ${this.stats[5].two}`, `three stars: ${this.stats[5].three}`, `four stars: ${this.stats[5].four}`, `five stars: ${this.stats[5].five}`]
                else if (context.label === 'Question 2')
                  return [`average: ${context.raw}`, `one star: ${this.stats[6].one}`, `two stars: ${this.stats[6].two}`, `three stars: ${this.stats[6].three}`, `four stars: ${this.stats[6].four}`, `five stars: ${this.stats[6].five}`]
                else if (context.label === 'Question 3')
                  return [`average: ${context.raw}`, `one star: ${this.stats[7].one}`, `two stars: ${this.stats[7].two}`, `three stars: ${this.stats[7].three}`, `four stars: ${this.stats[7].four}`, `five stars: ${this.stats[7].five}`]
                else if (context.label === 'Question 4')
                  return [`average: ${context.raw}`, `one star: ${this.stats[8].one}`, `two stars: ${this.stats[8].two}`, `three stars: ${this.stats[8].three}`, `four stars: ${this.stats[8].four}`, `five stars: ${this.stats[8].five}`]
                return [`average: ${context.raw}`, `one star: ${this.stats[9].one}`, `two stars: ${this.stats[9].two}`, `three stars: ${this.stats[9].three}`, `four stars: ${this.stats[9].four}`, `five stars: ${this.stats[9].five}`]
              }
            }
          }
        }
      },


    });
    let myChart3 = new Chart(ctx3, {
      type: 'bar',
      data: {
        labels: ['Question 1', 'Question 2', 'Question 3', 'Question 4', 'Question 5'],
        datasets: [{
          data: [this.stats[10].avg.toFixed(2), this.stats[11].avg.toFixed(2), this.stats[12].avg.toFixed(2), this.stats[13].avg.toFixed(2), this.stats[14].avg.toFixed(2)],
          backgroundColor: [
            'rgba(255, 99, 132, 0.2)',
            'rgba(54, 162, 235, 0.2)',
            'rgba(255, 206, 86, 0.2)',
            'rgba(75, 192, 192, 0.2)',
            'rgba(153, 102, 255, 0.2)'
          ],
          borderColor: [
            'rgba(255, 99, 132, 1)',
            'rgba(54, 162, 235, 1)',
            'rgba(255, 206, 86, 1)',
            'rgba(75, 192, 192, 1)',
            'rgba(153, 102, 255, 1)'
          ],
          borderWidth: 1
        }]
      },
      options: {
        animation: {
          onComplete: () => {
            delayed = true;
          },
          delay: (context) => {
            let delay = 0;
            delay = context.dataIndex * 300 + context.datasetIndex * 100;
            return delay;
          },
        },
        scales: {
          x: {
            stacked: true,
          },
          y: {
            stacked: true,
            max: 5
          }
        },
        responsive: true,
        plugins: {
          legend: {
            position: 'top',
          },
          title: {
            display: true,
            text: 'PORTAL'
          },
          tooltip: {
            callbacks: {
              label: (context) => {
                if (context.label === 'Question 1')
                  return [`average: ${context.raw}`, `one star: ${this.stats[10].one}`, `two stars: ${this.stats[10].two}`, `three stars: ${this.stats[10].three}`, `four stars: ${this.stats[10].four}`, `five stars: ${this.stats[10].five}`]
                else if (context.label === 'Question 2')
                  return [`average: ${context.raw}`, `one star: ${this.stats[11].one}`, `two stars: ${this.stats[11].two}`, `three stars: ${this.stats[11].three}`, `four stars: ${this.stats[11].four}`, `five stars: ${this.stats[11].five}`]
                else if (context.label === 'Question 3')
                  return [`average: ${context.raw}`, `one star: ${this.stats[12].one}`, `two stars: ${this.stats[12].two}`, `three stars: ${this.stats[12].three}`, `four stars: ${this.stats[12].four}`, `five stars: ${this.stats[12].five}`]
                else if (context.label === 'Question 4')
                  return [`average: ${context.raw}`, `one star: ${this.stats[13].one}`, `two stars: ${this.stats[13].two}`, `three stars: ${this.stats[13].three}`, `four stars: ${this.stats[13].four}`, `five stars: ${this.stats[13].five}`]
                return [`average: ${context.raw}`, `one star: ${this.stats[14].one}`, `two stars: ${this.stats[14].two}`, `three stars: ${this.stats[14].three}`, `four stars: ${this.stats[14].four}`, `five stars: ${this.stats[14].five}`]
              }
            }
          }
        },
      }
    });
  }

  getSurveyStats(): void {
    this.service.getSurveyStats().subscribe({
      next: (response: any[]) => {
        this.stats = response;
        this.initSurveyStats();
        this.initCategoryAverage();
      }, error: (e: any) => (console.log(e))
    })
  }

  initCategoryAverage(){
    let sum: number = 0;
    this.staffAverage = (this.stats[0].avg + this.stats[1].avg + this.stats[2].avg + this.stats[3].avg + this.stats[4].avg) / 5;
    this.hospitalAverage = (this.stats[5].avg + this.stats[6].avg + this.stats[7].avg + this.stats[8].avg + this.stats[9].avg) / 5;
    this.portalAverage = (this.stats[10].avg + this.stats[11].avg + this.stats[12].avg + this.stats[13].avg + this.stats[14].avg) / 5;
    for (var stat of this.stats) {
      sum = sum + stat.avg;
    }
    this.allQueastionsAverage = sum / 15;
  }
}