import { TestBed } from '@angular/core/testing';

import { FestivalArtistAsocService } from './festival-artist-asoc.service';

describe('FestivalArtistAsocService', () => {
  let service: FestivalArtistAsocService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(FestivalArtistAsocService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
