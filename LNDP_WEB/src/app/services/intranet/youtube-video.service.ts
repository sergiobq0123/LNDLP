import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Urls } from 'src/app/common/urls';
import { ServiceBaseService } from '../service-base.service';

@Injectable({
  providedIn: 'root'
})
export class YoutubeVideoService extends ServiceBaseService {

  constructor(http: HttpClient) {
    super(http, Urls.YOUTUBEVIDEO);
  }

  getWeb(){
    return this.getToSpecificURL(this.getUrl + Urls.YOUTUBEVIDEOSWEB)
  }
}
