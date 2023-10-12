import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ArtistDetailConciertosComponent } from './artist-detail-conciertos.component';

describe('ArtistDetailConciertosComponent', () => {
  let component: ArtistDetailConciertosComponent;
  let fixture: ComponentFixture<ArtistDetailConciertosComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ArtistDetailConciertosComponent]
    });
    fixture = TestBed.createComponent(ArtistDetailConciertosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
