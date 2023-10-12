import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VisualSectionCarrouselComunComponent } from './visual-section-carrousel-comun.component';

describe('VisualSectionCarrouselComunComponent', () => {
  let component: VisualSectionCarrouselComunComponent;
  let fixture: ComponentFixture<VisualSectionCarrouselComunComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [VisualSectionCarrouselComunComponent]
    });
    fixture = TestBed.createComponent(VisualSectionCarrouselComunComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
