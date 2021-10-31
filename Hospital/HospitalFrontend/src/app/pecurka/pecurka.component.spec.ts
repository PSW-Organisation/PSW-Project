import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PecurkaComponent } from './pecurka.component';

describe('PecurkaComponent', () => {
  let component: PecurkaComponent;
  let fixture: ComponentFixture<PecurkaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PecurkaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PecurkaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
