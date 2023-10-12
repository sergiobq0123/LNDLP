import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MarketingArtistWebComponent } from './marketing-artist-web.component';

describe('MarketingArtistWebComponent', () => {
  let component: MarketingArtistWebComponent;
  let fixture: ComponentFixture<MarketingArtistWebComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MarketingArtistWebComponent]
    });
    fixture = TestBed.createComponent(MarketingArtistWebComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
