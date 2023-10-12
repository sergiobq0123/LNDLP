import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ArtistDetailAlbumsComponent } from './artist-detail-albums.component';

describe('ArtistDetailAlbumsComponent', () => {
  let component: ArtistDetailAlbumsComponent;
  let fixture: ComponentFixture<ArtistDetailAlbumsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ArtistDetailAlbumsComponent]
    });
    fixture = TestBed.createComponent(ArtistDetailAlbumsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
