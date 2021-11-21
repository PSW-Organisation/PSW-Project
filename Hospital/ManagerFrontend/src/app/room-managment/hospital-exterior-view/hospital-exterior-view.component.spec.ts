import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HospitalExteriorViewComponent } from './hospital-exterior-view.component';

describe('HospitalExteriorViewComponent', () => {
  let component: HospitalExteriorViewComponent;
  let fixture: ComponentFixture<HospitalExteriorViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HospitalExteriorViewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HospitalExteriorViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
