import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RoomScheduleComponent } from './room-schedule.component';

describe('RoomScheduleComponent', () => {
  let component: RoomScheduleComponent;
  let fixture: ComponentFixture<RoomScheduleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RoomScheduleComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RoomScheduleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
