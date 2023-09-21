import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TourManagerWebComponent } from './tour-manager-web.component';

describe('TourManagerWebComponent', () => {
  let component: TourManagerWebComponent;
  let fixture: ComponentFixture<TourManagerWebComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TourManagerWebComponent]
    });
    fixture = TestBed.createComponent(TourManagerWebComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
