import { Component, OnInit } from '@angular/core';
import { Chart, registerables, ChartItem, ChartType } from 'chart.js';
import { DoctorStatisticsService } from './doctor-statistics.service';

@Component({
  selector: 'app-doctor-statistics',
  templateUrl: './doctor-statistics.component.html',
  styleUrls: ['./doctor-statistics.component.css'],
})
export class DoctorStatisticsComponent implements OnInit {
  appChart!: Chart;
  patiChart!: Chart;
  onCallChart!: Chart;
  currentTime: Date = new Date();
  appChartItem: any;
  patiChartItem: any;
  onCallChartItem: any;
  yearLabels: string[] = [
    (this.currentTime.getFullYear() - 2).toString(),
    (this.currentTime.getFullYear() - 1).toString(),
    this.currentTime.getFullYear().toString(),
    (this.currentTime.getFullYear() + 1).toString(),
  ];
  monthsLabels: string[] = [
    'January',
    'February',
    'March',
    'April',
    'May',
    'June',
    'July',
    'August',
    'September',
    'October',
    'November',
    'December',
  ];
  daysLabels: string[] = [];
  hoursLabels: string[] = [
    '1',
    '2',
    '3',
    '4',
    '5',
    '6',
    '7',
    '8',
    '9',
    '10',
    '11',
    '12',
    '13',
    '14',
    '15',
    '16',
    '17',
    '18',
    '19',
    '20',
    '21',
    '22',
    '23',
    '24',
  ];
  labels: string[] = [];
  yearAppSum: number[] = [0, 0, 0];
  monthsAppSum: number[] = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0];
  daysAppSum: number[] = [0, 0, 0, 0];
  hoursAppSum: number[] = [
    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
  ];
  data: number[] = [
    10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 110, 120, 130, 140, 150, 160, 170,
    180, 190, 200, 210, 220, 230, 240, 250, 260, 270, 280, 290, 300, 310,
  ];
  data1: number[] = [
    10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 110, 120, 130, 140, 150, 160, 170,
    180, 190, 200, 210, 220, 230, 240, 250, 260, 270, 280, 290, 300, 310,
  ];
  data2: number[] = [
    10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 110, 120, 130, 140, 150, 160, 170,
    180, 190, 200, 210, 220, 230, 240, 250, 260, 270, 280, 290, 300, 310,
  ];

  constructor(private _doctorStatisticsService: DoctorStatisticsService) {}

  ngOnInit(): void {
    this.appChartItem = document.getElementById('appChart');
    this.patiChartItem = document.getElementById('patiChart');
    this.onCallChartItem = document.getElementById('onCallChart');
    Chart.register(...registerables);
    this.loadChartAppointment();
    this.loadChartPatient();
    this.loadChartOnCall();
    console.log(this.yearLabels);
    this.daysLabels = this.addDaysLabels();
    this.appChart.data.labels = this.monthsLabels;
    this.appChart.update();
    this._doctorStatisticsService
      .getPatientCountWeekly('nelex')
      .subscribe((data) => {
        this.patiChart.data.datasets[0].data = data.weeklySum;
        this.patiChart.update();
      });
  }

  addDaysLabels(): string[] {
    let labelsDays: string[] = [];
    var month = this.currentTime.getMonth();
    var d = new Date(this.currentTime.getFullYear(), month, 0);
    var lastDay = d.getDate();
    console.log(lastDay.toString());
    for (let i = 1; i <= 3; i++) {
      labelsDays.push(String(i * 7));
      console.log(i);
    }
    labelsDays.push(String(lastDay));
    return labelsDays;
  }

  appChartYearly() {
    this.appChart.data.labels = this.yearLabels;
    this._doctorStatisticsService
      .getAppointmentsCountYearly('nelex')
      .subscribe((data) => {
        this.appChart.data.datasets[0].data = data.yearlySum;
        this.appChart.update();
      });
    this.appChart.config.type = 'pie' as ChartType;
    this.appChart.update();
  }
  appChartMonthly() {
    this.appChart.data.labels = this.monthsLabels;
    this.appChart.config.type = 'bar' as ChartType;
    this._doctorStatisticsService
      .getAppointmentsCountMonthly('nelex')
      .subscribe((data) => {
        this.appChart.data.datasets[0].data = data.monthlySum;
        this.appChart.update();
      });
    this.appChart.update();
  }
  appChartWeekly() {
    this.appChart.data.labels = this.daysLabels;
    this.appChart.config.type = 'bar' as ChartType;
    this._doctorStatisticsService
      .getAppointmentsCountWeekly('nelex')
      .subscribe((data) => {
        this.appChart.data.datasets[0].data = data.weeklySum;
        this.appChart.update();
      });
    this.appChart.update();
  }
  appChartDaily() {
    this.appChart.data.labels = this.hoursLabels;
    this.appChart.config.type = 'bar' as ChartType;
    this._doctorStatisticsService
      .getAppointmentsCountDaily('nelex')
      .subscribe((data) => {
        this.appChart.data.datasets[0].data = data.dailySum;
        this.appChart.update();
      });
    this.appChart.update();
  }

  patiChartYearly() {
    this.patiChart.data.labels = this.yearLabels;
    this.patiChart.config.type = 'pie' as ChartType;
    this._doctorStatisticsService
      .getPatientCountYearly('nelex')
      .subscribe((data) => {
        this.patiChart.data.datasets[0].data = data.yearlySum;
        this.patiChart.update();
      });
    this.patiChart.update();
  }
  patiChartMonthly() {
    this.patiChart.data.labels = this.monthsLabels;
    this.patiChart.config.type = 'bar' as ChartType;
    this._doctorStatisticsService
      .getPatientCountMonthly('nelex')
      .subscribe((data) => {
        this.patiChart.data.datasets[0].data = data.monthlySum;
        this.patiChart.update();
      });
    this.patiChart.update();
  }
  patiChartWeekly() {
    this.patiChart.data.labels = this.daysLabels;
    this.patiChart.config.type = 'bar' as ChartType;
    this._doctorStatisticsService
      .getPatientCountWeekly('nelex')
      .subscribe((data) => {
        this.patiChart.data.datasets[0].data = data.weeklySum;
        this.patiChart.update();
      });
    this.patiChart.update();
  }
  patiChartlDaily() {
    this.patiChart.data.labels = this.hoursLabels;
    this.patiChart.config.type = 'bar' as ChartType;
    this._doctorStatisticsService
      .getPatientCountDaily('nelex')
      .subscribe((data) => {
        this.patiChart.data.datasets[0].data = data.dailySum;
        this.patiChart.update();
      });
    this.patiChart.update();
  }

  onCallChartYearly() {
    this.onCallChart.data.labels = this.yearLabels;
    this.onCallChart.config.type = 'pie' as ChartType;
    this.onCallChart.data.datasets[0].data = [10, 20, 30, 40];
    this.onCallChart.update();
  }
  onCallChartMonthly() {
    this.onCallChart.data.labels = this.monthsLabels;
    this.onCallChart.config.type = 'bar' as ChartType;
    this.onCallChart.data.datasets[0].data = [
      10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 110, 120, 130, 140, 150, 160,
      170, 180, 190, 200, 210, 220, 230, 240, 250, 260, 270, 280, 290, 300, 310,
    ];
    this.onCallChart.update();
  }
  onCallChartWeekly() {
    this.onCallChart.data.labels = this.daysLabels;
    this.onCallChart.config.type = 'bar' as ChartType;
    this.onCallChart.data.datasets[0].data = [
      10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 110, 120, 130, 140, 150, 160,
      170, 180, 190, 200, 210, 220, 230, 240, 250, 260, 270, 280, 290, 300, 310,
    ];
    this.onCallChart.update();
  }
  onCallChartlDaily() {
    this.onCallChart.data.labels = this.hoursLabels;
    this.onCallChart.config.type = 'bar' as ChartType;
    this.onCallChart.data.datasets[0].data = [
      10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 110, 120, 130, 140, 150, 160,
      170, 180, 190, 200, 210, 220, 230, 240, 250, 260, 270, 280, 290, 300, 310,
    ];
    this.onCallChart.update();
  }

  loadChartAppointment(): void {
    this.appChart = new Chart(this.appChartItem as ChartItem, {
      type: 'bar' as ChartType,
      data: {
        labels: this.labels,
        datasets: [
          {
            label: '#Number of appointments',
            data: this.data,
            backgroundColor: [
              'rgba(255, 99, 132, 0.2)',
              'rgba(54, 162, 235, 0.2)',
              'rgba(255, 206, 86, 0.2)',
              'rgba(75, 192, 192, 0.2)',
              'rgba(153, 102, 255, 0.2)',
              'rgba(255, 159, 64, 0.2)',
              'rgba(155, 159, 64, 0.2)',
              'rgba(205, 205, 64, 0.2)',
            ],
            borderColor: [
              'rgba(255, 99, 132, 1)',
              'rgba(54, 162, 235, 1)',
              'rgba(255, 206, 86, 1)',
              'rgba(75, 192, 192, 1)',
              'rgba(153, 102, 255, 1)',
              'rgba(255, 159, 64, 1)',
              'rgba(155, 159, 64, 1)',
              'rgba(205, 205, 64, 1)',
            ],
            borderWidth: 1,
          },
        ],
      },
      options: {
        scales: {
          y: {
            beginAtZero: true,
          },
        },
      },
    });
  }

  loadChartPatient(): void {
    this.patiChart = new Chart(this.patiChartItem as ChartItem, {
      type: 'bar' as ChartType,
      data: {
        labels: this.labels,
        datasets: [
          {
            label: '#Number of patients',
            data: this.data1,
            backgroundColor: [
              'rgba(255, 99, 132, 0.2)',
              'rgba(54, 162, 235, 0.2)',
              'rgba(255, 206, 86, 0.2)',
              'rgba(75, 192, 192, 0.2)',
              'rgba(153, 102, 255, 0.2)',
              'rgba(255, 159, 64, 0.2)',
            ],
            borderColor: [
              'rgba(255, 99, 132, 1)',
              'rgba(54, 162, 235, 1)',
              'rgba(255, 206, 86, 1)',
              'rgba(75, 192, 192, 1)',
              'rgba(153, 102, 255, 1)',
              'rgba(255, 159, 64, 1)',
            ],
            borderWidth: 1,
          },
        ],
      },
      options: {
        scales: {
          y: {
            beginAtZero: true,
          },
        },
      },
    });
  }

  loadChartOnCall(): void {
    this.onCallChart = new Chart(this.onCallChartItem as ChartItem, {
      type: 'bar' as ChartType,
      data: {
        labels: this.labels,
        datasets: [
          {
            label: '#Number of on-call shifts',
            data: this.data2,
            backgroundColor: [
              'rgba(255, 99, 132, 0.2)',
              'rgba(54, 162, 235, 0.2)',
              'rgba(255, 206, 86, 0.2)',
              'rgba(75, 192, 192, 0.2)',
              'rgba(153, 102, 255, 0.2)',
              'rgba(255, 159, 64, 0.2)',
              'rgba(155, 159, 64, 0.2)',
              'rgba(205, 205, 64, 0.2)',
            ],
            borderColor: [
              'rgba(255, 99, 132, 1)',
              'rgba(54, 162, 235, 1)',
              'rgba(255, 206, 86, 1)',
              'rgba(75, 192, 192, 1)',
              'rgba(153, 102, 255, 1)',
              'rgba(255, 159, 64, 1)',
              'rgba(155, 159, 64, 1)',
              'rgba(205, 205, 64, 1)',
            ],
            borderWidth: 1,
          },
        ],
      },
      options: {
        scales: {
          y: {
            beginAtZero: true,
          },
        },
      },
    });
  }
}
