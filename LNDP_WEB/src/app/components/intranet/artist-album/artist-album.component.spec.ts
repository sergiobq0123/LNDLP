import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ArtistAlbumComponent } from './artist-album.component';

describe('ArtistAlbumComponent', () => {
  let component: ArtistAlbumComponent;
  let fixture: ComponentFixture<ArtistAlbumComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ArtistAlbumComponent]
    });
    fixture = TestBed.createComponent(ArtistAlbumComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
