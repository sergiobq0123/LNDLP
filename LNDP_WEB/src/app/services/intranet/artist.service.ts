import { Injectable } from '@angular/core';
import { ServiceBaseService } from './../service-base.service';
import { HttpClient } from '@angular/common/http';
import { Urls } from '../../common/urls';

@Injectable({
  providedIn: 'root'
})
export class ArtistService extends ServiceBaseService {

  constructor(http: HttpClient) {
    super(http, Urls.ARTIST);
   }

   getArtistWithoutSN(){
    return this.getToSpecificURL(this.getUrl + "/withoutSocialNetWork")
   }
   getArtistWithoutC(){
    return this.getToSpecificURL(this.getUrl + "/withoutCrew")
   }
}
