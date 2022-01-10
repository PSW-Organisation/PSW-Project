import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ManageShiftsComponent } from './manage-shifts.component';

describe('ManageShiftsComponent', () => {
  let component: ManageShiftsComponent;
  let fixture: ComponentFixture<ManageShiftsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ManageShiftsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ManageShiftsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
