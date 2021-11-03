import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PharmaciesViewComponent } from './pharmacies-view.component';

describe('PharmaciesViewComponent', () => {
  let component: PharmaciesViewComponent;
  let fixture: ComponentFixture<PharmaciesViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PharmaciesViewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PharmaciesViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
