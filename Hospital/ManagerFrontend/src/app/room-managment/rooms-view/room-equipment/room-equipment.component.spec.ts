import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RoomEquipmentComponent } from './room-equipment.component';

describe('RoomEquipmentComponent', () => {
  let component: RoomEquipmentComponent;
  let fixture: ComponentFixture<RoomEquipmentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RoomEquipmentComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RoomEquipmentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
