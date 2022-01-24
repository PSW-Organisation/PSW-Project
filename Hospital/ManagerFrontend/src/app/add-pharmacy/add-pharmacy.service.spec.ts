import { TestBed } from '@angular/core/testing';

import { AddPharmacyService } from './add-pharmacy.service';

describe('AddPharmacyService', () => {
  let service: AddPharmacyService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AddPharmacyService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
