import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VisualCarrouselWebComponent } from './visual-carrousel-web.component';

describe('VisualCarrouselWebComponent', () => {
  let component: VisualCarrouselWebComponent;
  let fixture: ComponentFixture<VisualCarrouselWebComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [VisualCarrouselWebComponent]
    });
    fixture = TestBed.createComponent(VisualCarrouselWebComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
