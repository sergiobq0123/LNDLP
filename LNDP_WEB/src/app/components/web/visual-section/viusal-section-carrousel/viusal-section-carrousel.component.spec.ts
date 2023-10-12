import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViusalSectionCarrouselComponent } from './viusal-section-carrousel.component';

describe('ViusalSectionCarrouselComponent', () => {
  let component: ViusalSectionCarrouselComponent;
  let fixture: ComponentFixture<ViusalSectionCarrouselComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ViusalSectionCarrouselComponent]
    });
    fixture = TestBed.createComponent(ViusalSectionCarrouselComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
