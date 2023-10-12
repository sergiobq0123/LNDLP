import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TourManagerSectionComponent } from './tour-manager-section.component';

describe('TourManagerSectionComponent', () => {
  let component: TourManagerSectionComponent;
  let fixture: ComponentFixture<TourManagerSectionComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TourManagerSectionComponent]
    });
    fixture = TestBed.createComponent(TourManagerSectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
