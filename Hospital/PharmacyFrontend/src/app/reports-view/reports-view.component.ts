import { Component, OnInit } from '@angular/core';
import { ReportService } from './report.service';

@Component({
  selector: 'app-reports-view',
  templateUrl: './reports-view.component.html',
  styleUrls: ['./reports-view.component.css']
})
export class ReportsViewComponent implements OnInit {

  reportNames: string[] = []
  directory = ''

  constructor(private _reportService: ReportService) { }

  ngOnInit(): void {
    this.directory = "Consumption reports"
    this.getReportNames()
  }

  getReportNames() {
      this._reportService.getReportNames(this.directory).subscribe(
        reportNames => {
          this.reportNames = reportNames;
        }
      );
  }

  getReport(reportName: string) {
      this._reportService.getReport(this.directory, reportName)
  }
}
