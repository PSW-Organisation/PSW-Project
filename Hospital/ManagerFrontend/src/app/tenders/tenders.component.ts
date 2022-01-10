import { Component, OnInit } from '@angular/core';
import { ITender } from './tender';
import { ITenderItem } from './tenderItem';
import { TendersService } from './tenders.service';
import {Chart, registerables, Tooltip} from 'chart.js'
import { jsPDF } from "jspdf";
import { ITenderStatisticBarChart } from './TenderStatisticBarChart';
import { ITenderStatisticTwoBarChart } from './TenderStatisticTwoBarChart';

@Component({
  selector: 'app-tenders',
  templateUrl: './tenders.component.html',
  styleUrls: ['./tenders.component.css']
})
export class TendersComponent implements OnInit {
  newTender: any={ id: 0, tenderItems: [ ] ,
  tenderOpenDate: new Date, tenderCloseDate: null, open: true,
  tenderResponses: [ ] }

  tenderResponse: any={}
  tenders: ITender[]=[]
  closedTenders: ITender[] = []
  tenderItem : ITenderItem= {tenderItemName: "", tenderItemQuantity: 0, tenderItemPrice: 0}

  //-----------------------------------------------------STATISTIKA----------------------------------------
  chartOfferInACtiveTender: any;
  chartWinnings: any;
  canvas: any;
  canvas2: any;
  canvas3: any;
  canvas4: any;
  chartsParticipation: any;
  chartsWinn: any;
  pdf: any;
  start: Date = new Date();
  end: Date = new Date();
  chartsDataWinnOffres : ITenderStatisticBarChart = { x: [], y: []};
  chartsDataPharmacyProfits: ITenderStatisticBarChart = { x: [], y: []};
  chartsDataTenderWinningDefeat: ITenderStatisticTwoBarChart = { x: [], y: [], z: []};
  chartsDataTenderParticipate: ITenderStatisticTwoBarChart = { x: [], y: [], z: []};

  constructor(private tenderService: TendersService) { }

  ngOnInit(): void {
    this.getTenders();

  //-----------------------------------------------------STATISTIKA----------------------------------------
    

  }
  addTenderItem(tenderItem: any){
    this.newTender.tenderItems.push(Object.assign({}, tenderItem));
    this.tenderItem = {tenderItemName: "", tenderItemQuantity: 0, tenderItemPrice: 0}
  }
  compareDates(date: Date){
    var date2 = new Date(2199, 12,12)
    var date1 = new Date(date)
    var year1 = date1.getFullYear()
    var year2 = date2.getFullYear()

    return year1 < year2

  }
  getTenders(): void {
    this.tenderService.getTenders().subscribe(
      tenders => {
        this.tenders = []
        this.closedTenders = []
        tenders.forEach(tender => {
          if(tender.open) {
            this.tenders.push(tender)
          }
          else {
            this.closedTenders.push(tender);
          }
        })
      }
    )
  }

  saveTender(): void {
    this.tenderService.saveTender(this.newTender).subscribe(
      data => {
        this.newTender = { id: 0, tenderItems: [ ] , tenderOpenDate: new Date, tenderCloseDate: null, open: true, tenderResponses: [ ] };
        this.tenderItem = {tenderItemName: "", tenderItemQuantity: 0, tenderItemPrice: 0}
        this.getTenders();
      },
      err => console.log(err)
    );
  }

  closeTender(id: number):void {
    this.tenderService.closeTender(id).subscribe(
      data => {
        this.newTender = { id: 0, tenderItems: [ ] , tenderOpenDate: new Date, tenderCloseDate: null, open: true, tenderResponses: [ ] };
        this.tenderItem = {tenderItemName: "", tenderItemQuantity: 0, tenderItemPrice: 0}
        this.getTenders();
      },
      err => console.log(err)
    );
  }


  //-----------------------------------------------------STATISTIKA----------------------------------------
  
loadWinnChart(): void {
  const labels = this.chartsDataTenderWinningDefeat.x
  const dataWinn = this.chartsDataTenderWinningDefeat.y
  const dataLose = this.chartsDataTenderWinningDefeat.z
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
  const labels = this.chartsDataTenderParticipate.x
  const dataWinn = this.chartsDataTenderParticipate.y
  const dataLose = this.chartsDataTenderParticipate.z
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
        labels: this.chartsDataWinnOffres.x,
        datasets: [{
            label: '#pobednicke ponude',
            data: this.chartsDataWinnOffres.y,
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
  new Chart( this.chartWinnings, {
    type: 'bar',
    data: {
        labels: this.chartsDataPharmacyProfits.x,
        datasets: [{
            label: '#pobednicke ponude',
            data: this.chartsDataPharmacyProfits.y,
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
  })
  /*new Chart( this.chartWinnings,{
    type: 'pie',
    data: {
      labels: this.chartsDataPharmacyProfits.x,
      datasets: [{
        label: 'Zarada apoteka u tenderima',
        data: this.chartsDataPharmacyProfits.y,
        backgroundColor: [
          'rgba(255, 99, 132, 1)',
          'rgba(54, 162, 235, 1)',
          'rgba(255, 206, 86, 1)',
          'rgba(75, 192, 192, 1)',
          'rgba(153, 102, 255, 1)'
        ],
        hoverOffset: 4,
      }],
    },
    options: {
      plugins: {
        tooltip: {
          enabled: true,
          intersect: false
        }
      }
    }
  })*/
}

statisticTenderWinnerOffers(start: Date, end: Date){
  return this.tenderService.statisticTenderWinnerOffers(start, end).subscribe(ret => {
    this.chartsDataWinnOffres = ret;
  });
}

statisticTenderPharmacyProfits(start: Date, end: Date){
  return this.tenderService.statisticTenderPharmacyProfits(start, end).subscribe(ret => {
    this.chartsDataPharmacyProfits = ret;
  });
}

statisticTenderWinningDefeat(start: Date, end: Date){
  return this.tenderService.statisticTenderWinningDefeat(start, end).subscribe(ret => {
    this.chartsDataTenderWinningDefeat = ret;
  });
}

statisticTenderParticipate(start: Date, end: Date){
  return this.tenderService.statisticTenderParticipate(start, end).subscribe(ret => {
    this.chartsDataTenderParticipate = ret;
  });
}

getData(start : Date, end : Date){
    alert("UZIMAM PODATKE")
    this.statisticTenderWinnerOffers(start, end);
    this.statisticTenderPharmacyProfits(start, end);
    this.statisticTenderWinningDefeat(start, end);
    this.statisticTenderParticipate(start, end);
    setTimeout(() => {
      alert("CRTAM GRAFIKE")
      this.chartOfferInACtiveTender = document.getElementById('offerInACtiveTenderChart');
      this.chartWinnings = document.getElementById('winningsChart');
      this.chartsWinn = document.getElementById('chartsWinn');
      this.chartsParticipation = document.getElementById('chartsParticipation');
      Chart.register(...registerables);
      this.loadChartOffesrInACtiveTender();
      this.loadChartWinnings();
      this.loadWinnChart();
      this.loadParticipateChart();
      }, 4000);
      
      //setTimeout(() => {   
   // }, 1000)
}

generateReportPdf(start: Date, end: Date){
  //setTimeout(() => {
    this.getData(start, end);
    setTimeout(() => {
    alert("PISEM PDF")
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
    this.pdf.text(10,70,"U periodu od "+ start + " godine do " + end + " odrzano je ukupno 11 tendera.");
    this.pdf.text(10,76,"Na tenderima je ucestvovalo 4 apoteke. Na graficima koji slede su prikazane statistike o");
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
    this.pdf.save('report.pdf')
    this.pdf.output("dataurlnewwindow");
  }, 16000);
//}, 1500);
}
}
