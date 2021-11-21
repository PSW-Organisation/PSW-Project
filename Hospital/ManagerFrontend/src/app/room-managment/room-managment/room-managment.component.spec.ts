import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RoomManagmentComponent } from './room-managment.component';

describe('RoomManagmentComponent', () => {
  let component: RoomManagmentComponent;
  let fixture: ComponentFixture<RoomManagmentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RoomManagmentComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RoomManagmentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
