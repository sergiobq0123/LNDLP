import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HomeSectionWebComponent } from './home-section-web.component';

describe('HomeSectionWebComponent', () => {
  let component: HomeSectionWebComponent;
  let fixture: ComponentFixture<HomeSectionWebComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [HomeSectionWebComponent]
    });
    fixture = TestBed.createComponent(HomeSectionWebComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
