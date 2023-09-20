import { Injectable } from '@angular/core';
import { ServiceBaseService } from '../service-base.service';
import { HttpClient } from '@angular/common/http';
import { Urls } from 'src/app/common/urls';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class DossierService extends ServiceBaseService {
  constructor(http: HttpClient) {
    super(http, Urls.DOSSIER);
  }

  postImage(section: string, photo: any) {
    const formData = new FormData();
    formData.append('image', photo);
    formData.append('section', section);
    console.log(this.getUrl);
    return this.post(this.getUrl, formData);
  }
}
