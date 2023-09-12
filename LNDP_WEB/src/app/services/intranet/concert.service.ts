import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Urls } from '../../common/urls';
import { ServiceBaseService } from '../service-base.service';

@Injectable({
  providedIn: 'root'
})
export class ConcertService extends ServiceBaseService {

  constructor(http: HttpClient) {
    super(http, Urls.CONCIERTO);
   }
}
