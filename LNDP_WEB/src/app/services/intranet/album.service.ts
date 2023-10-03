import { Injectable } from '@angular/core';
import { ServiceBaseService } from '../service-base.service';
import { HttpClient } from '@angular/common/http';
import { Urls } from 'src/app/common/urls';

@Injectable({
  providedIn: 'root'
})
export class AlbumService extends ServiceBaseService {

  constructor(http: HttpClient) {
    super(http, Urls.ALBUM);
   }

  postImage(album: any, photo: any) {
    const albumdata = {
      name: album.name,
      artistId: album.artistId,
    };
    const albumdataJSON = JSON.stringify(albumdata);

    const formData = new FormData();
    formData.append('image', photo);
    formData.append('album', albumdataJSON);
    console.log(album);

    return this.post(this.getUrl, formData);
  }
}
