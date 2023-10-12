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



   getArtistWithoutU(){
    return this.getToSpecificURL(this.getUrl + "/withoutUser")
   }

   postImageArtist(inputFile: any, id : number){
    const formData = new FormData();
    console.log(inputFile);

    if(inputFile === null){
      formData.append('image', null)
    }else{
      formData.append('image', inputFile);
    }
    return this.postSpecificUrl(this.getUrl + Urls.IMAGE + `/${id}`, formData)
   }
}
