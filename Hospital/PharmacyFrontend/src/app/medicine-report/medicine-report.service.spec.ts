import { TestBed } from '@angular/core/testing';

import { MedicineReportService } from './medicine-report.service';

describe('MedicineReportService', () => {
  let service: MedicineReportService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MedicineReportService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
