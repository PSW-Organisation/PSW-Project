import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { IPharmacy } from '../pharmacies-view/pharmacy';
import { OrderingMedicineService } from './ordering-medicine.service';

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
  notFoundMessage: string = "";
  notFound: boolean = false;

  constructor(private _orderingMedicineService: OrderingMedicineService) { }

  ngOnInit(): void {

  }

  //metoda kojom se narucuje lek prosledjenoj apoteci, sa prosledjenim imenom i kolicinom
  order(pharmacy: IPharmacy): void {
    if (window.confirm('Are you sure, you want to order medicine from this pharmacy?')){
      this._orderingMedicineService.orderMedicineHospital(this.medicineName.toLocaleLowerCase(), this.medicineAmount).subscribe();
      this._orderingMedicineService.orderMedicinePharmacy(pharmacy.pharmacyUrl, pharmacy.hospitalApiKey ,this.medicineName.toLocaleLowerCase(), this.medicineAmount).subscribe();
      alert('Medicine was successfully orderd!');
    }
  }

  //metoda koja vraca sve apoteke koje sadrze lek sa prosledjenim imenom i kolicinom
  searchMedicine() {
    if (this.medicineName === "" && this.medicineAmount === null){ //da se refresuje nakon sto je izvrseno narucivanje
      this.pharmacies = [];
      this.notFound = false;
    } else {
      this._orderingMedicineService.searchMedicine(this.medicineName.toLocaleLowerCase(),this.medicineAmount).subscribe(
      pharmacies => {
        this.pharmacies = pharmacies;
        if (this.pharmacies.length === 0) { //ako nema leka ni u jednoj apoteci
          this.notFound = true;
          this.notFoundMessage = "Medicine isn't found!";
        } else {
          this.notFound = false;
        }
      })
    };}
}
