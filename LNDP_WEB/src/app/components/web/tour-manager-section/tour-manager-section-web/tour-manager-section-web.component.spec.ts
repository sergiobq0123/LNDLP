import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TourManagerSectionWebComponent } from './tour-manager-section-web.component';

describe('TourManagerSectionWebComponent', () => {
  let component: TourManagerSectionWebComponent;
  let fixture: ComponentFixture<TourManagerSectionWebComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TourManagerSectionWebComponent]
    });
    fixture = TestBed.createComponent(TourManagerSectionWebComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
