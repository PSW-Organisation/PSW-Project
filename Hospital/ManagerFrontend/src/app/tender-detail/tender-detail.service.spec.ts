import { TestBed } from '@angular/core/testing';

import { TenderDetailService } from './tender-detail.service';

describe('TenderDetailService', () => {
  let service: TenderDetailService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TenderDetailService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
