import { TestBed } from '@angular/core/testing';

import { HospitalExteriorService } from './hospital-exterior.service';

describe('HospitalExteriorService', () => {
  let service: HospitalExteriorService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(HospitalExteriorService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
