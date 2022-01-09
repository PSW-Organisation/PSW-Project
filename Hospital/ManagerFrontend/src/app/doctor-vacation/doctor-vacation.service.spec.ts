import { TestBed } from '@angular/core/testing';

import { DoctorVacationService } from './doctor-vacation.service';

describe('DoctorVacationService', () => {
  let service: DoctorVacationService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DoctorVacationService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
