import { Component, Input, OnInit, Output } from '@angular/core';
import { EventEmitter } from '@angular/core';
import { EditPharmacyService } from './edit-pharmacy.service';

@Component({
  selector: 'app-edit-pharmacy',
  templateUrl: './edit-pharmacy.component.html',
  styleUrls: ['./edit-pharmacy.component.css']
})
export class EditPharmacyComponent implements OnInit {
  @Input() pharmacyEdit : any;
  pharmacyName: string = "";
  pharmacyAddress: string = "";
  pharmacyUrl: string = "";
  hospitalApiKey: string = "";
  @Output() refreshPharmacy = new EventEmitter();

  constructor(private _editPharmacyService: EditPharmacyService) { }

  ngOnInit(): void {
    this.pharmacyName = this.pharmacyEdit.pharmacyName;
    this.pharmacyUrl = this.pharmacyEdit.pharmacyUrl;
    this.pharmacyAddress = this.pharmacyEdit.pharmacyAddress;
    this.hospitalApiKey = this.pharmacyEdit.hospitalApiKey;
  }

  editPharmacy(){
    var pharmacy =  { pharmacyId: this.pharmacyEdit.pharmacyId, pharmacyUrl: this.pharmacyUrl, pharmacyName:this.pharmacyName , pharmacyAddress: this.pharmacyAddress, hospitalApiKey: this.hospitalApiKey};
    this._editPharmacyService.editPharmacy(pharmacy).subscribe( res => {
      alert("Pharmacy updated successfully!");
      this.refreshPharmacy.emit();
    });
  }
}
