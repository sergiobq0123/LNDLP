import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ArtistDetailTableComponent } from './artist-detail-table.component';

describe('ArtistDetailTableComponent', () => {
  let component: ArtistDetailTableComponent;
  let fixture: ComponentFixture<ArtistDetailTableComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ArtistDetailTableComponent]
    });
    fixture = TestBed.createComponent(ArtistDetailTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
