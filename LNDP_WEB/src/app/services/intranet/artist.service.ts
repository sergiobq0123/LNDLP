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

   postImageArtist(inputFile: any, id : number){
    const formData = new FormData();
    formData.append('image', inputFile)
    return this.postImage(this.getUrl + Urls.IMAGE + `/${id}`, inputFile)
   }
}
