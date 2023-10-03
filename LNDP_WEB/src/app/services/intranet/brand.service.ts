import { Injectable } from '@angular/core';
import { ServiceBaseService } from '../service-base.service';
import { HttpClient } from '@angular/common/http';
import { Urls } from 'src/app/common/urls';

@Injectable({
  providedIn: 'root'
})
export class BrandService extends ServiceBaseService{

  constructor(http: HttpClient) {
    super(http, Urls.BRAND);
   }

   postImage(brand: any, photo: any) {
    const brandData = {
      name: brand.name,
      description: brand.description,
      url : brand.url
    };
    const brandDataJSON = JSON.stringify(brandData);

    const formData = new FormData();
    formData.append('image', photo);
    formData.append('brand', brandDataJSON);

    return this.post(this.getUrl, formData);
  }
}
