import { Injectable } from '@angular/core';
import { ServiceBaseService } from '../service-base.service';
import { HttpClient } from '@angular/common/http';
import { Urls } from 'src/app/common/urls';

@Injectable({
  providedIn: 'root'
})
export class RecordService extends ServiceBaseService {

  constructor(http: HttpClient) {
    super(http, Urls.RECORD);
   }

   postImage(record: any, photo: any) {
    const recordData = {
      name: record.name,
      description: record.description,
      url : record.url
    };
    const recordDataJSON = JSON.stringify(recordData);

    const formData = new FormData();
    formData.append('image', photo);
    formData.append('record', recordDataJSON);

    return this.post(this.getUrl, formData);
  }
}
