import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TourManagerSectionFestivalesComponent } from './tour-manager-section-festivales.component';

describe('TourManagerSectionFestivalesComponent', () => {
  let component: TourManagerSectionFestivalesComponent;
  let fixture: ComponentFixture<TourManagerSectionFestivalesComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TourManagerSectionFestivalesComponent]
    });
    fixture = TestBed.createComponent(TourManagerSectionFestivalesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
