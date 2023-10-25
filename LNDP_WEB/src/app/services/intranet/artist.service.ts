import { Injectable } from '@angular/core';
import { ServiceBaseService } from './../service-base.service';
import { HttpClient } from '@angular/common/http';
import { Urls } from '../../common/urls';

@Injectable({
  providedIn: 'root',
})
export class ArtistService extends ServiceBaseService {
  constructor(http: HttpClient) {
    super(http, Urls.ARTIST);
  }

  CreateArtist(data: any) {
    return this.postSpecificUrl(this.getUrl + Urls.CREATEREGISTER, data);
  }

  getArtists() {
    return this.getToSpecificURL(this.getUrl + '/artist-web');
  }

  getArtistWebDetail(id: number) {
    return this.getToSpecificURL(this.getUrl + `/artist-web-detail/${id}`);
  }
}
