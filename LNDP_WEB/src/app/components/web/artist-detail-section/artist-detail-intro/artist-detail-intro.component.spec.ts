import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ArtistDetailIntroComponent } from './artist-detail-intro.component';

describe('ArtistDetailIntroComponent', () => {
  let component: ArtistDetailIntroComponent;
  let fixture: ComponentFixture<ArtistDetailIntroComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ArtistDetailIntroComponent]
    });
    fixture = TestBed.createComponent(ArtistDetailIntroComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
