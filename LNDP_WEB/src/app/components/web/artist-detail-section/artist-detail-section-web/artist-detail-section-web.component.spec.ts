import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ArtistDetailSectionWebComponent } from './artist-detail-section-web.component';

describe('ArtistDetailSectionWebComponent', () => {
  let component: ArtistDetailSectionWebComponent;
  let fixture: ComponentFixture<ArtistDetailSectionWebComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ArtistDetailSectionWebComponent]
    });
    fixture = TestBed.createComponent(ArtistDetailSectionWebComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
