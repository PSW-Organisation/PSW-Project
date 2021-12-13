import { TestBed } from '@angular/core/testing';

import { FileCompressionViewServiceService } from './file-compression-view-service.service';

describe('FileCompressionViewServiceService', () => {
  let service: FileCompressionViewServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(FileCompressionViewServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
