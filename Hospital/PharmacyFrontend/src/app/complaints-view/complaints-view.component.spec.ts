import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ComplaintsViewComponent } from './complaints-view.component';

describe('ComplaintsViewComponent', () => {
  let component: ComplaintsViewComponent;
  let fixture: ComponentFixture<ComplaintsViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ComplaintsViewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ComplaintsViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
