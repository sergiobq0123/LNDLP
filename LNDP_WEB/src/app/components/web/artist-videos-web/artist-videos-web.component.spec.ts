import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ArtistVideosWebComponent } from './artist-videos-web.component';

describe('ArtistVideosWebComponent', () => {
  let component: ArtistVideosWebComponent;
  let fixture: ComponentFixture<ArtistVideosWebComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ArtistVideosWebComponent]
    });
    fixture = TestBed.createComponent(ArtistVideosWebComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
