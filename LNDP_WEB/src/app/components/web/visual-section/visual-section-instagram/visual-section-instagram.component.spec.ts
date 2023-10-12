import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VisualSectionInstagramComponent } from './visual-section-instagram.component';

describe('VisualSectionInstagramComponent', () => {
  let component: VisualSectionInstagramComponent;
  let fixture: ComponentFixture<VisualSectionInstagramComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [VisualSectionInstagramComponent]
    });
    fixture = TestBed.createComponent(VisualSectionInstagramComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
