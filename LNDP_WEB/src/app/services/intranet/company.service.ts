import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Urls } from 'src/app/common/urls';
import { ServiceBaseService } from '../service-base.service';

@Injectable({
  providedIn: 'root',
})
export class CompanyService extends ServiceBaseService {
  constructor(http: HttpClient) {
    super(http, Urls.COMPANY);
  }

  getBrands() {
    return this.getToSpecificURL(this.getUrl + '/type/Marca');
  }
  getPartner() {
    return this.getToSpecificURL(this.getUrl + '/type/Partner');
  }
  getRecords() {
    return this.getToSpecificURL(this.getUrl + '/type/Sello');
  }
  getProjects() {
    return this.getToSpecificURL(this.getUrl + '/type/Proyecto');
  }
}
