import { TestBed } from '@angular/core/testing';

import { OrderingMedicineService } from './ordering-medicine.service';

describe('OrderingMedicineService', () => {
  let service: OrderingMedicineService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(OrderingMedicineService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
