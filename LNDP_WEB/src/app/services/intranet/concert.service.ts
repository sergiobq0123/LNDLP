import { HttpClient, HttpParams } from '@angular/common/http';
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

  getOrder(){
    return this.getToSpecificURL(this.getUrl + '/Order')
  }

  getProximosConciertos(){
    return this.getToSpecificURL(this.getUrl + '/proximos-conciertos')
  }

  getConcertForArtist(userId: number){
    const params = new HttpParams().append('userId', userId)
    return this.getWithParams(this.getUrl + '/artist-id', params)
  }
}
