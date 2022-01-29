import { Component, OnInit } from '@angular/core';
import { Chart } from 'chart.js';
import { EventService } from './event.service';

@Component({
  selector: 'app-event-statistics',
  templateUrl: './event-statistics.component.html',
  styleUrls: ['./event-statistics.component.css']
})
export class EventStatisticsComponent implements OnInit {

  schedulingAbortionStats: any;
  stepDurationStats: any;
  successfullScheduling: any;
  unsuccessfullScheduling: any;
  schedulingAttempts: any;
  unsuccessfullSchedulingByAgeGroup: any;
  stats: any;

  constructor(private eventService: EventService) { }

  ngOnInit(): void {
    this.eventService.getAbortStepBreakdown().subscribe({
      next: response => {
        this.schedulingAbortionStats = response.body
        this.initChart1();
      }
    })
    this.eventService.getStepDurationBreakdown().subscribe({
      next: response => {
        this.stepDurationStats = response.body
        this.initChart2();
      }
    })
    this.eventService.getSchedulingPerTimeOfDay().subscribe({
      next: response => {
        this.schedulingAttempts = response.body
        this.initChart4();
      }
    })
    this.eventService.getUnsuccessfullSchedulingByAgeGroup().subscribe({
      next: response => {
        this.unsuccessfullSchedulingByAgeGroup = response.body
        this.initChart5();
      }
    })
    this.eventService.getSuccessfullSchedulingPerMonth().subscribe({
      next: response => {
        this.successfullScheduling = response.body
        this.eventService.getUnsuccessfullSchedulingPerMonth().subscribe({
          next: response => {
            this.unsuccessfullScheduling = response.body;
            this.initChart3();
          }
        })
      }
    })
    this.eventService.getAverageStats().subscribe({
      next: response => {
        this.stats = response.body;
      }
    });
  }

  initChart1() {
    let ctx1 = 'myChart1';
    let myChart1 = new Chart(ctx1, {
      type: 'pie',
      data: {
        labels: ['First step', 'Second step', 'Third step', 'Fourth step'],
        datasets: [{
          data: [this.schedulingAbortionStats.firstStepAbortions,
          this.schedulingAbortionStats.secondStepAbortions,
          this.schedulingAbortionStats.thirdStepAbortions,
          this.schedulingAbortionStats.fourthStepAbortions],
          backgroundColor: [
            'rgba(255, 99, 132, 1)',
            'rgba(54, 162, 235, 1)',
            'rgba(255, 206, 86, 1)',
            'rgba(75, 192, 192, 1)'
          ],
          borderColor: [
            'rgba(255, 99, 132, 1)',
            'rgba(54, 162, 235, 1)',
            'rgba(255, 206, 86, 1)',
            'rgba(75, 192, 192, 1)'
          ],
          borderWidth: 1,
        }]
      },
      options: {
        responsive: true,
        plugins: {
          legend: {
            position: 'top',
            display: true
          },
          title: {
            display: true,
            text: 'Number of scheduling abortions per step'
          }
        }
      }
    });
  }
  initChart2() {
    let ctx2 = 'myChart2';
    let myChart2 = new Chart(ctx2, {
      type: 'doughnut',
      data: {
        labels: ['First step', 'Second step', 'Third step', 'Fourth step'],
        datasets: [{
          data: [this.stepDurationStats.firstStepDuration.toFixed(0),
          this.stepDurationStats.secondStepDuration.toFixed(0),
          this.stepDurationStats.thirdStepDuration.toFixed(0),
          this.stepDurationStats.fourthStepDuration.toFixed(0)],
          backgroundColor: [
            'rgba(255, 99, 132, 1)',
            'rgba(54, 162, 235, 1)',
            'rgba(255, 206, 86, 1)',
            'rgba(75, 192, 192, 1)'
          ],
          borderColor: [
            'rgba(255, 99, 132, 1)',
            'rgba(54, 162, 235, 1)',
            'rgba(255, 206, 86, 1)',
            'rgba(75, 192, 192, 1)'
          ],
          borderWidth: 1,
        }]
      },
      options: {
        responsive: true,
        plugins: {
          legend: {
            position: 'top',
            display: true
          },
          title: {
            display: true,
            text: 'Step duration in seconds'
          }
        }
      }
    });
  }
  initChart3() {
    let ctx3 = 'myChart3';
    let myChart3 = new Chart(ctx3, {
      type: 'bar',
      data: {
        labels: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'],
        datasets: [{
          label: 'Successfull scheduling',
          data: [this.successfullScheduling.jan, this.successfullScheduling.feb, this.successfullScheduling.mar,
          this.successfullScheduling.apr, this.successfullScheduling.may, this.successfullScheduling.jun,
          this.successfullScheduling.jul, this.successfullScheduling.aug, this.successfullScheduling.sep,
          this.successfullScheduling.oct, this.successfullScheduling.nov, this.successfullScheduling.dec],
          backgroundColor: 'rgba(54, 162, 235, 1)'
        },
        {
          label: 'Unsuccessfull scheduling',
          data: [this.unsuccessfullScheduling.jan, this.unsuccessfullScheduling.feb, this.unsuccessfullScheduling.mar,
          this.unsuccessfullScheduling.apr, this.unsuccessfullScheduling.may, this.unsuccessfullScheduling.jun,
          this.unsuccessfullScheduling.jul, this.unsuccessfullScheduling.aug, this.unsuccessfullScheduling.sep,
          this.unsuccessfullScheduling.oct, this.unsuccessfullScheduling.nov, this.unsuccessfullScheduling.dec],
          backgroundColor: 'rgba(255, 99, 132, 1)'
        }]
      },
      options: {
        responsive: true,
        plugins: {
          legend: {
            position: 'top',
            display: true
          },
          title: {
            display: true,
            text: 'Number of successfull and unsuccessfull schedulings per month'
          }
        },
      }
    });
  }
  initChart4() {
    let ctx4 = 'myChart4';
    let myChart4 = new Chart(ctx4, {
      type: 'polarArea',
      data: {
        labels: ['Morning', 'Midday', 'Evening', 'Night'],
        datasets: [{
          label: 'Successfull scheduling',
          data: [this.schedulingAttempts.morning, this.schedulingAttempts.midday,
          this.schedulingAttempts.evening, this.schedulingAttempts.night],
          backgroundColor: [
            'rgba(255, 99, 132, 0.5)',
            'rgba(54, 162, 235, 0.5)',
            'rgba(255, 206, 86, 0.5)',
            'rgba(75, 192, 192, 0.5)'
          ],
          borderColor: [
            'rgba(255, 99, 132, 0.5)',
            'rgba(54, 162, 235, 0.5)',
            'rgba(255, 206, 86, 0.5)',
            'rgba(75, 192, 192, 0.5)'
          ],
          borderWidth: 1,
        }]
      },
      options: {
        responsive: true,
        plugins: {
          legend: {
            position: 'top',
            display: true
          },
          title: {
            display: true,
            text: 'Scheduling attempts per time of day'
          }
        },
      }
    });
  }
  initChart5() {
    let ctx5 = 'myChart5';
    let myChart5 = new Chart(ctx5, {
      type: 'pie',
      data: {
        labels: ['Young adults (18-30)', 'Middle-aged adults (31-45)', 'Old-aged adults (45+)'],
        datasets: [{
          data: [this.unsuccessfullSchedulingByAgeGroup.young, 
            this.unsuccessfullSchedulingByAgeGroup.middleAged,
            this.unsuccessfullSchedulingByAgeGroup.oldAged
          ],
          backgroundColor: [
            'rgba(255, 99, 132, 1)',
            'rgba(54, 162, 235, 1)',
            'rgba(255, 206, 86, 1)'
          ],
          borderColor: [
            'rgba(255, 99, 132, 1)',
            'rgba(54, 162, 235, 1)',
            'rgba(255, 206, 86, 1)'
          ],
          borderWidth: 1,
        }]
      },
      options: {
        responsive: true,
        plugins: {
          legend: {
            position: 'top',
            display: true
          },
          title: {
            display: true,
            text: 'Scheduling attempts per age group'
          }
        },
      }
    });
  }
}
