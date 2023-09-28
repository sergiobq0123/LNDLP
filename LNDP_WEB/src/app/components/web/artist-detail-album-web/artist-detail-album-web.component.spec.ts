import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ArtistDetailAlbumWebComponent } from './artist-detail-album-web.component';

describe('ArtistDetailAlbumWebComponent', () => {
  let component: ArtistDetailAlbumWebComponent;
  let fixture: ComponentFixture<ArtistDetailAlbumWebComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ArtistDetailAlbumWebComponent]
    });
    fixture = TestBed.createComponent(ArtistDetailAlbumWebComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
