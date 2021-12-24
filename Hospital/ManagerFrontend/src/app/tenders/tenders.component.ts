import { Component, OnInit } from '@angular/core';
import { IMedicine } from './medicine';
import { ITender } from './tender';
import { TenderService } from './tender.service';
import {Chart, registerables} from 'chart.js'
import { jsPDF } from "jspdf";

@Component({
  selector: 'app-tenders',
  templateUrl: './tenders.component.html',
  styleUrls: ['./tenders.component.css']
})
export class TendersComponent implements OnInit {
  newTender: any={ id: 0, medicineTransactions: [ { medicineName: "aaaaaaaaaa", medicineAmount: 0}] , 
                  tenderOpenDate: "", tenderCloseDate: "", open: true, 
                tenderResponses: [{}] }
  tenderResponse: any={}
  tenders: ITender[]=[]
  medicine : IMedicine= {medicineName: "", medicineAmount: 0}

  chartOfferInACtiveTender: any;
  chartWinnings: any;
  canvas: any;
  canvas2: any;
  canvas3: any;
  canvas4: any;
  chartsParticipation: any;
  chartsWinn: any;
  pdf: any;

  constructor(private tenderService: TenderService) { }

  ngOnInit(): void {
    this.loadTenders();

    this.chartOfferInACtiveTender = document.getElementById('offerInACtiveTenderChart');
    this.chartWinnings = document.getElementById('winningsChart');
    this.chartsWinn = document.getElementById('chartsWinn');
    this.chartsParticipation = document.getElementById('chartsParticipation');
    Chart.register(...registerables);
    this.loadChartOffesrInACtiveTender();
    this.loadChartWinnings();
    this.loadWinnChart();
    this.loadParticipateChart();
  }

  loadTenders(){}
       
addNewTender(tender: any){
 this.tenders = tender;
}
addMedicine(medicine: any){
  this.newTender.medicineTransactions.push(medicine);
}

loadWinnChart(): void {
  const labels = [
        'Jankovic',
        'Flos',
        'Benu',
        'Zegin',
        'Melem'
      ]
  const dataWinn = [5, 8, 9, 3, 6]
  const dataLose = [5, 2, 1, 7, 4]
  new Chart( this.chartsWinn, {
    type: 'bar',
    data: {
      labels: labels,
      datasets: [
        {
          label: 'Osvojila',
            data: dataWinn,
            backgroundColor: [
                'rgba(75, 192, 192, 0.2)',
                'rgba(75, 192, 192, 0.2)',
                'rgba(75, 192, 192, 0.2)',
                'rgba(75, 192, 192, 0.2)',
                'rgba(75, 192, 192, 0.2)'
            ]
        },
        {
          label: 'Izgubila',
          data: dataLose,
          backgroundColor: [
            'rgba(255, 206, 86, 0.2)',
            'rgba(255, 206, 86, 0.2)',
            'rgba(255, 206, 86, 0.2)',
            'rgba(255, 206, 86, 0.2)',
            'rgba(255, 206, 86, 0.2)'
        ]
        },
      ]
    }

  })
}

loadParticipateChart(): void {
  const labels = [
        'Jankovic',
        'Flos',
        'Benu',
        'Zegin',
        'Melem'
      ]
  const dataWinn = [10, 18, 9, 3, 11]
  const dataLose = [5, 7, 6, 12, 4]
  new Chart( this.chartsParticipation, {
    type: 'bar',
    data: {
      labels: labels,
      datasets: [
        {
          label: 'Ucestvovala',
            data: dataWinn,
            backgroundColor: [
              'rgba(75, 192, 192, 0.2)',
              'rgba(75, 192, 192, 0.2)',
              'rgba(75, 192, 192, 0.2)',
              'rgba(75, 192, 192, 0.2)',
              'rgba(75, 192, 192, 0.2)'
            ]
        },
        {
          label: 'Nije ucestvovala',
          data: dataLose,
          backgroundColor: [
            'rgba(255, 206, 86, 0.2)',
            'rgba(255, 206, 86, 0.2)',
            'rgba(255, 206, 86, 0.2)',
            'rgba(255, 206, 86, 0.2)',
            'rgba(255, 206, 86, 0.2)'
        ]
        },
      ]
    }

  })
}
  
loadChartOffesrInACtiveTender()  : void {
  new Chart( this.chartOfferInACtiveTender, {
    type: 'bar',
    data: {
        labels: ['Tender 1', 'Tender 2', 'Tender 3', 'Tender 4'],
        datasets: [{
            label: '#pobednicke ponude',
            data: [80000, 60000, 70000, 50000],
            backgroundColor: [
                'rgba(255, 99, 132, 0.2)',
                'rgba(255, 99, 132, 0.2)',
                'rgba(255, 99, 132, 0.2)',
                'rgba(255, 99, 132, 0.2)'
            ],
            borderColor: [
                'rgba(255, 99, 132, 0.2)',
                'rgba(255, 99, 132, 0.2)',
                'rgba(255, 99, 132, 0.2)',
                'rgba(255, 99, 132, 0.2)'
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
        'Jankovic',
        'Flos',
        'Benu',
        'Zegin',
        'Melem'
      ],
      datasets: [{
        label: 'Zarada apoteka u tenderima',
        data: [60000,12000,50000,80000,70000],
        backgroundColor: [
          'rgba(255, 99, 132, 1)',
          'rgba(54, 162, 235, 1)',
          'rgba(255, 206, 86, 1)',
          'rgba(75, 192, 192, 1)',
          'rgba(153, 102, 255, 1)'
        ],
        hoverOffset: 4
      }]
    }
  })
}

generateReportPdf(){
  this.canvas = document.getElementById('offerInACtiveTenderChart');
  this.canvas2 = document.getElementById('winningsChart');
  this.canvas3 = document.getElementById('chartsWinn');
  this.canvas4 = document.getElementById('chartsParticipation');
  //create image
  const canvasImage = this.canvas.toDataURL('image/jpeg', 1.0);
  const canvasImage2 = this.canvas2.toDataURL('image/jpeg', 1.0);
  const canvasImage3 = this.canvas3.toDataURL('image/jpeg', 1.0);
  const canvasImage4 = this.canvas4.toDataURL('image/jpeg', 1.0);
  // image must go to pdf
  this.pdf = new jsPDF("p", "mm", "a4");
  this.pdf.setFontSize(8);
  this.pdf.text(10,10,"Adresa: Bulevar Oslobodjenja 5");
  this.pdf.text(10,13,"21000 Novi Sad, Srbija");
  this.pdf.text(10,16,"Kontak telefon: 021/156-668");
  this.pdf.text(10,19,"E-mail adresa: leanon@gmail.com");
  this.pdf.setFontSize(13);
  this.pdf.text(168, 17, "LeanOn Hospital")
  this.pdf.addImage("../../assets/favicon.png", 'PNG',155,8, 15, 15)
  this.pdf.setFontSize(20);
  this.pdf.text(60,50,"Izvestaj o proteklim tenderima");
  this.pdf.setFontSize(13);
  this.pdf.text(10,70,"U periodu od 23.01.2021. godine do 28.12.2021. odrzano je ukupno 10 tendera.");
  this.pdf.text(10,76,"Na tenderima je ucestvovalo 25 bolnica. Na graficima koji slede su prikazane statistike o");
  this.pdf.text(10,82,"uspesnosti pojedinacnih apoteka tokom svih tendera.")
  this.pdf.addImage(canvasImage, 'JPEG', 10, 90 ,107, 80)
  this.pdf.setFontSize(10);
  this.pdf.text(37,177,"Grafik o pobednickim ponudama");
  this.pdf.addImage(canvasImage2, 'JPEG', 123, 90 ,80, 80)
  this.pdf.text(138,177,"Grafik o zaradi apoteka");
  this.pdf.addImage(canvasImage3, 'JPEG', 10, 190 ,95, 80)
  this.pdf.setFontSize(10);
  this.pdf.text(23,277,"Grafik o osvojenim i neosvojenim tenderima");
  this.pdf.addImage(canvasImage4, 'JPEG', 108, 190 ,95, 80)
  this.pdf.text(138,277,"Grafik o ucescu apoteka");
  this.pdf.save('proba.pdf')
  this.pdf.output("dataurlnewwindow");
}

}
