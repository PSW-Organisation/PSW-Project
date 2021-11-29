import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MaliciousPatientsComponent } from './malicious-patients.component';

describe('MaliciousPatientsComponent', () => {
  let component: MaliciousPatientsComponent;
  let fixture: ComponentFixture<MaliciousPatientsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MaliciousPatientsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MaliciousPatientsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
