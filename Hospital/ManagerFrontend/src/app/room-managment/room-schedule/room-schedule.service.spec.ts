import { TestBed } from '@angular/core/testing';

import { RoomScheduleService } from './room-schedule.service';

describe('RoomScheduleService', () => {
  let service: RoomScheduleService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RoomScheduleService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
