import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ArtistDetailSectionComponent } from './artist-detail-section.component';

describe('ArtistDetailSectionComponent', () => {
  let component: ArtistDetailSectionComponent;
  let fixture: ComponentFixture<ArtistDetailSectionComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ArtistDetailSectionComponent]
    });
    fixture = TestBed.createComponent(ArtistDetailSectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
