import { TestBed } from '@angular/core/testing';

import { SearchEquipmentService } from './search-equipment.service';

describe('SearchEquipmentService', () => {
  let service: SearchEquipmentService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SearchEquipmentService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
