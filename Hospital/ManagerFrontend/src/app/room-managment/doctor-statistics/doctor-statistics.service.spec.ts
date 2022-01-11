import { TestBed } from '@angular/core/testing';

import { DoctorStatisticsService } from './doctor-statistics.service';

describe('DoctorStatisticsService', () => {
  let service: DoctorStatisticsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DoctorStatisticsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
