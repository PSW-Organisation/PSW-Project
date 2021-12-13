import { Component, OnInit } from '@angular/core';
import { ChartData, ChartType } from 'chart.js';

@Component({
  selector: 'app-file-compression-view',
  templateUrl: './file-compression-view.component.html',
  styleUrls: ['./file-compression-view.component.css']
})
export class FileCompressionViewComponent implements OnInit {
  public free_space = 300;
  public doughnutChartLabels = ['Free Space', 'Perscriptions', 'Consumption stats'];
  public doughnutChartData: ChartData<'doughnut'> = {
    labels: this.doughnutChartLabels,
    datasets: [

      { data: [ this.free_space, 130, 70 ] }
    ]
  };
  public doughnutChartType: ChartType = 'doughnut';

  constructor() { }

  ngOnInit(): void {
  }

}
