import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VisualSectionWebComponent } from './visual-section-web.component';

describe('VisualSectionWebComponent', () => {
  let component: VisualSectionWebComponent;
  let fixture: ComponentFixture<VisualSectionWebComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [VisualSectionWebComponent]
    });
    fixture = TestBed.createComponent(VisualSectionWebComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
