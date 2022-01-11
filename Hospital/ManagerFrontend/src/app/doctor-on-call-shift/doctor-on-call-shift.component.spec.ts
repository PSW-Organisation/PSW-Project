import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DoctorOnCallShiftComponent } from './doctor-on-call-shift.component';

describe('DoctorOnCallShiftComponent', () => {
  let component: DoctorOnCallShiftComponent;
  let fixture: ComponentFixture<DoctorOnCallShiftComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DoctorOnCallShiftComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DoctorOnCallShiftComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
