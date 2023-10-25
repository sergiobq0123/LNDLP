import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Urls } from '../../common/urls';
import { ServiceBaseService } from '../service-base.service';
import { Filter } from 'src/app/components/intranet/general/generic-filter/filter';

@Injectable({
  providedIn: 'root',
})
export class ConcertService extends ServiceBaseService {
  constructor(http: HttpClient) {
    super(http, Urls.CONCIERTO);
  }

  getOrder() {
    return this.getToSpecificURL(this.getUrl + '/Order');
  }

  getProximosConciertos() {
    return this.getToSpecificURL(this.getUrl + '/proximos-conciertos');
  }

  getConcertForArtist(
    id: number,
    page?: number,
    size?: number,
    sortBy?: string,
    sortOrder?: string,
    filters?: Filter[]
  ) {
    return this.getToSpecificURL(
      this.getUrl + '/concert-user-id/' + id,
      page,
      size,
      sortBy,
      sortOrder,
      filters
    );
  }
}
