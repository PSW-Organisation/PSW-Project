import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrderingMedicineComponent } from './ordering-medicine.component';

describe('OrderingMedicineComponent', () => {
  let component: OrderingMedicineComponent;
  let fixture: ComponentFixture<OrderingMedicineComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OrderingMedicineComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OrderingMedicineComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
