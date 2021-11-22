import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MoveEquipmentComponent } from './move-equipment.component';

describe('MoveEquipmentComponent', () => {
  let component: MoveEquipmentComponent;
  let fixture: ComponentFixture<MoveEquipmentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [MoveEquipmentComponent],
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MoveEquipmentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
