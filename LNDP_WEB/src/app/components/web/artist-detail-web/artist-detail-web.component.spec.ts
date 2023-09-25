import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ArtistDetailWebComponent } from './artist-detail-web.component';

describe('ArtistDetailWebComponent', () => {
  let component: ArtistDetailWebComponent;
  let fixture: ComponentFixture<ArtistDetailWebComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ArtistDetailWebComponent]
    });
    fixture = TestBed.createComponent(ArtistDetailWebComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
