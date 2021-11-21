import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MedicineConsumptionComponent } from './medicine-consumption.component';

describe('MedicineConsumptionComponent', () => {
  let component: MedicineConsumptionComponent;
  let fixture: ComponentFixture<MedicineConsumptionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MedicineConsumptionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MedicineConsumptionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
