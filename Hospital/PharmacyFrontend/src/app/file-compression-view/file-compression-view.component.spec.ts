import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FileCompressionViewComponent } from './file-compression-view.component';

describe('FileCompressionViewComponent', () => {
  let component: FileCompressionViewComponent;
  let fixture: ComponentFixture<FileCompressionViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FileCompressionViewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FileCompressionViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
