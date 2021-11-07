import { TestBed } from '@angular/core/testing';

import { ComplaintDetailService } from './complaint-detail.service';

describe('ComplaintDetailService', () => {
  let service: ComplaintDetailService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ComplaintDetailService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
