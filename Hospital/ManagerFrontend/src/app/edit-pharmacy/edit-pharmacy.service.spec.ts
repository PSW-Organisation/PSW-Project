import { TestBed } from '@angular/core/testing';

import { EditPharmacyService } from './edit-pharmacy.service';

describe('EditPharmacyService', () => {
  let service: EditPharmacyService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EditPharmacyService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
