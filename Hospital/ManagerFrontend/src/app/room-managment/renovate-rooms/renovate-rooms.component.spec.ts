import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RenovateRoomsComponent } from './renovate-rooms.component';

describe('RenovateRoomsComponent', () => {
  let component: RenovateRoomsComponent;
  let fixture: ComponentFixture<RenovateRoomsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RenovateRoomsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RenovateRoomsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
