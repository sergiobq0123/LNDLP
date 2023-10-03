import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HomePageWebComponent } from './home-page-web.component';

describe('HomePageWebComponent', () => {
  let component: HomePageWebComponent;
  let fixture: ComponentFixture<HomePageWebComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [HomePageWebComponent]
    });
    fixture = TestBed.createComponent(HomePageWebComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
