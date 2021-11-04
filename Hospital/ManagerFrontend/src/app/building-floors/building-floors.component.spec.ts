import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BuildingFloorsComponent } from './building-floors.component';

describe('BuildingFloorsComponent', () => {
  let component: BuildingFloorsComponent;
  let fixture: ComponentFixture<BuildingFloorsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BuildingFloorsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BuildingFloorsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
