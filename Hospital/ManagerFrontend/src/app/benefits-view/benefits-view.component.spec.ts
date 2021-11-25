import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BenefitsViewComponent } from './benefits-view.component';

describe('BenefitsViewComponent', () => {
  let component: BenefitsViewComponent;
  let fixture: ComponentFixture<BenefitsViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BenefitsViewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BenefitsViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
