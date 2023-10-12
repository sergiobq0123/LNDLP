import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HomeSectionSpotifyComponent } from './home-section-spotify.component';

describe('HomeSectionSpotifyComponent', () => {
  let component: HomeSectionSpotifyComponent;
  let fixture: ComponentFixture<HomeSectionSpotifyComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [HomeSectionSpotifyComponent]
    });
    fixture = TestBed.createComponent(HomeSectionSpotifyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
