import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ArtistDetailTableWebComponent } from './artist-detail-table-web.component';

describe('ArtistDetailTableWebComponent', () => {
  let component: ArtistDetailTableWebComponent;
  let fixture: ComponentFixture<ArtistDetailTableWebComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ArtistDetailTableWebComponent]
    });
    fixture = TestBed.createComponent(ArtistDetailTableWebComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
