import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HomeSectionServiciosComponent } from './home-section-servicios.component';

describe('HomeSectionServiciosComponent', () => {
  let component: HomeSectionServiciosComponent;
  let fixture: ComponentFixture<HomeSectionServiciosComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [HomeSectionServiciosComponent]
    });
    fixture = TestBed.createComponent(HomeSectionServiciosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
