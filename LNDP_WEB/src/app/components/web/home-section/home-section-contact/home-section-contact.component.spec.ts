import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HomeSectionContactComponent } from './home-section-contact.component';

describe('HomeSectionContactComponent', () => {
  let component: HomeSectionContactComponent;
  let fixture: ComponentFixture<HomeSectionContactComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [HomeSectionContactComponent]
    });
    fixture = TestBed.createComponent(HomeSectionContactComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
