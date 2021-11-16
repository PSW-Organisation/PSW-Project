import { Component, OnInit } from '@angular/core';
import { IPharmacy } from '../pharmacies-view/pharmacy';

@Component({
  selector: 'app-ordering-medicine',
  templateUrl: './ordering-medicine.component.html',
  styleUrls: ['./ordering-medicine.component.css']
})
export class OrderingMedicineComponent implements OnInit {
  pharmacies: IPharmacy[] = [];
  medicineName: string = "";
  medicineAmount: number = 0;
  searchParameter: string = "";

  constructor() { }

  ngOnInit(): void {
    this.pharmacies = [{pharmacyId: 0, pharmacyName:"Jankovic", pharmacyAddress:"Pavla Papa", pharmacyUrl:"www.jankovic.com", hospitalApiKey:"dasa-dsadasd-aasdasd"},
    {pharmacyId: 1, pharmacyName:"Flos", pharmacyAddress:"Masarikova", pharmacyUrl:"www.flos.com", hospitalApiKey:"dasa-dsadasd-aasdasd"}]
  }

  //metoda kojom se narucuje lek prosledjenoj apoteci, sa prosledjenim imenom i kolicinom
  order(): void {

  }

  //metoda koja vraca sve apoteke koje sadrze lek sa prosledjenim imenom i kolicinom
  searchMedicine(): void {

  }
}
