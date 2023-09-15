import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ArtistCrewComponent } from './artist-crew.component.ts';

describe('ArtistCrewComponent', () => {
  let component: ArtistCrewComponent;
  let fixture: ComponentFixture<ArtistCrewComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ArtistCrewComponent]
    });
    fixture = TestBed.createComponent(ArtistCrewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
