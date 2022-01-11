import { TestBed } from '@angular/core/testing';

import { DoctorOnCallShiftService } from './doctor-on-call-shift.service';

describe('DoctorOnCallShiftService', () => {
  let service: DoctorOnCallShiftService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DoctorOnCallShiftService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
