import { TestBed } from '@angular/core/testing';

import { PharmacyProfileService } from './pharmacy-profile.service';

describe('PharmacyProfileService', () => {
  let service: PharmacyProfileService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PharmacyProfileService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
