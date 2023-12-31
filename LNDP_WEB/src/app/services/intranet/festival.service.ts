import { Injectable } from '@angular/core';
import { ServiceBaseService } from './../service-base.service';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Urls } from '../../common/urls';

@Injectable({
  providedIn: 'root'
})
export class FestivalService extends ServiceBaseService {

  constructor(http: HttpClient) {
    super(http, Urls.FESTIVAL);
   }

   getProximosFestivales(){
    return this.getToSpecificURL(this.getUrl + '/proximos-festivales')
  }
}
