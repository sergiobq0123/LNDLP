import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Urls } from 'src/app/common/urls';
import { ServiceBaseService } from '../service-base.service';

@Injectable({
  providedIn: 'root'
})
export class CompanyService extends ServiceBaseService{

  constructor(http: HttpClient) {
    super(http, Urls.COMPANY);
   }

   postImage(company: any, photo: any) {
    console.log(company);

    const collabData = {
      name: company.name,
      description: company.description,
      webUrl : company.webUrl,
      companyTypeId : company.companyType,
    };
    const collabDataJSON = JSON.stringify(collabData);

    const formData = new FormData();
    formData.append('image', photo);
    formData.append('companyIntranetDto', collabDataJSON);
    console.log(formData);

    return this.post(this.getUrl, formData);
  }

  getBrands(){
    return this.getToSpecificURL(this.getUrl + '/type/Brand')
  }
  getPartner(){
    return this.getToSpecificURL(this.getUrl + '/type/Partner')
  }
  getRecords(){
    return this.getToSpecificURL(this.getUrl + '/type/Record')
  }
  getProjects(){
    return this.getToSpecificURL(this.getUrl + '/type/Project')
  }
}
