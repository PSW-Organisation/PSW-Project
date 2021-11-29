import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RecommendedAppointmentSchedulingComponent } from './recommended-appointment-scheduling.component';

describe('RecommendedAppointmentSchedulingComponent', () => {
  let component: RecommendedAppointmentSchedulingComponent;
  let fixture: ComponentFixture<RecommendedAppointmentSchedulingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RecommendedAppointmentSchedulingComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RecommendedAppointmentSchedulingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
