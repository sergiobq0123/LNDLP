import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FestivalArtistDialogComponent } from './festival-artist-dialog.component';

describe('FestivalArtistDialogComponent', () => {
  let component: FestivalArtistDialogComponent;
  let fixture: ComponentFixture<FestivalArtistDialogComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [FestivalArtistDialogComponent]
    });
    fixture = TestBed.createComponent(FestivalArtistDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
