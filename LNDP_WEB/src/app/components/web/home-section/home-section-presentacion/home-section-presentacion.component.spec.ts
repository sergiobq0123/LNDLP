import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HomeSectionPresentacionComponent } from './home-section-presentacion.component';

describe('HomeSectionPresentacionComponent', () => {
  let component: HomeSectionPresentacionComponent;
  let fixture: ComponentFixture<HomeSectionPresentacionComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [HomeSectionPresentacionComponent]
    });
    fixture = TestBed.createComponent(HomeSectionPresentacionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
