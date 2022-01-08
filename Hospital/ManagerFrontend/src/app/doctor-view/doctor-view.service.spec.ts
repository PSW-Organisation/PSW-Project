import { TestBed } from '@angular/core/testing';

import { DoctorViewService } from './doctor-view.service';

describe('DoctorViewService', () => {
  let service: DoctorViewService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DoctorViewService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
