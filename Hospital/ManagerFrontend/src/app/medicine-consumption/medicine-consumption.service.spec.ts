import { TestBed } from '@angular/core/testing';

import { MedicineConsumptionService } from './medicine-consumption.service';

describe('MedicineConsumptionService', () => {
  let service: MedicineConsumptionService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MedicineConsumptionService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
