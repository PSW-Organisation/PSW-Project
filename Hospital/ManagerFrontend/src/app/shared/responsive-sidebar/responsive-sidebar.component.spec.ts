import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ResponsiveSidebarComponent } from './responsive-sidebar.component';

describe('ResponsiveSidebarComponent', () => {
  let component: ResponsiveSidebarComponent;
  let fixture: ComponentFixture<ResponsiveSidebarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ResponsiveSidebarComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ResponsiveSidebarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
