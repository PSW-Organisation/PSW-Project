import { TestBed } from '@angular/core/testing';

import { TermOfRenovationService } from './term-of-renovation.service';

describe('TermOfRenovationService', () => {
  let service: TermOfRenovationService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TermOfRenovationService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
