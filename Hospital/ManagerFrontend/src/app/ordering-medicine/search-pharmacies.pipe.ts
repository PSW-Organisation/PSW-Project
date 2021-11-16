import { Pipe, PipeTransform } from '@angular/core';
import { IPharmacy } from '../pharmacies-view/pharmacy';

@Pipe({
  name: 'searchPharmacies'
})
export class SearchPharmaciesPipe implements PipeTransform {

  transform(pharmacies: IPharmacy[], searchParameter: string): IPharmacy[] {
    if( !pharmacies || !searchParameter){
      return pharmacies;
    }
    return pharmacies.filter(pharmacy => pharmacy.pharmacyAddress.toLocaleLowerCase().includes(searchParameter.toLocaleLowerCase()));
  }

}
