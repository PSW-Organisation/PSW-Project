import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DoctorStatisticsComponent } from './doctor-statistics.component';

describe('DoctorStatisticsComponent', () => {
  let component: DoctorStatisticsComponent;
  let fixture: ComponentFixture<DoctorStatisticsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DoctorStatisticsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DoctorStatisticsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
