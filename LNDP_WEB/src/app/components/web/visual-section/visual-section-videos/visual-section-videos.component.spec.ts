import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VisualSectionVideosComponent } from './visual-section-videos.component';

describe('VisualSectionVideosComponent', () => {
  let component: VisualSectionVideosComponent;
  let fixture: ComponentFixture<VisualSectionVideosComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [VisualSectionVideosComponent]
    });
    fixture = TestBed.createComponent(VisualSectionVideosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
