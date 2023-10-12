import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ArtistDetailSongsComponent } from './artist-detail-songs.component';

describe('ArtistDetailSongsComponent', () => {
  let component: ArtistDetailSongsComponent;
  let fixture: ComponentFixture<ArtistDetailSongsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ArtistDetailSongsComponent]
    });
    fixture = TestBed.createComponent(ArtistDetailSongsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
