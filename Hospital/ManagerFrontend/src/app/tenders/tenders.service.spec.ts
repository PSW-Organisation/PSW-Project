import { TestBed } from '@angular/core/testing';

import { TendersService } from './tenders.service';

describe('TendersService', () => {
  let service: TendersService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TendersService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
