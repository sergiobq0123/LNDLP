import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Urls } from 'src/app/common/urls';
import { ServiceBaseService } from '../service-base.service';
import { Filter } from 'src/app/components/intranet/general/generic-filter/filter';

@Injectable({
  providedIn: 'root',
})
export class FestivalArtistAsocService extends ServiceBaseService {
  constructor(http: HttpClient) {
    super(http, Urls.FESTIVALARTISTASOC);
  }

  getFestivalForArtist(
    id: number,
    page?: number,
    size?: number,
    sortBy?: string,
    sortOrder?: string,
    filters?: Filter[]
  ) {
    return this.getToSpecificURL(
      this.getUrl + '/festival-user-id/' + id,
      page,
      size,
      sortBy,
      sortOrder,
      filters
    );
  }
}
