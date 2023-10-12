import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TourManagerSectionConciertosComponent } from './tour-manager-section-conciertos.component';

describe('TourManagerSectionConciertosComponent', () => {
  let component: TourManagerSectionConciertosComponent;
  let fixture: ComponentFixture<TourManagerSectionConciertosComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TourManagerSectionConciertosComponent]
    });
    fixture = TestBed.createComponent(TourManagerSectionConciertosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
