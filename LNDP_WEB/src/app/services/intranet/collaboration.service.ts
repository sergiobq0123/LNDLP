import { Injectable } from '@angular/core';
import { ServiceBaseService } from '../service-base.service';
import { HttpClient } from '@angular/common/http';
import { Urls } from 'src/app/common/urls';

@Injectable({
  providedIn: 'root'
})
export class CollaborationService extends ServiceBaseService{

  constructor(http: HttpClient) {
    super(http, Urls.COLLABORATION);
   }

   postImage(collab: any, photo: any) {
    const collabData = {
      name: collab.name,
      description: collab.description,
      url : collab.url
    };
    const collabDataJSON = JSON.stringify(collabData);

    const formData = new FormData();
    formData.append('image', photo);
    formData.append('collaboration', collabDataJSON);

    return this.post(this.getUrl, formData);
  }
}
