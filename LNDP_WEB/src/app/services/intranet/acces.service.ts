import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Urls } from 'src/app/common/urls';
import { ServiceBaseService } from '../service-base.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AccesService extends ServiceBaseService{

  constructor(http: HttpClient) {
    super(http, Urls.ACCES);
  }

  Login(username: string, password: string){
    let body = {username: username, password : password}
    return this.postSpecificUrl(this.getUrl + Urls.LOGIN, body)
  }
  Register(body : any){
    return this.postSpecificUrl(this.getUrl + Urls.REGISTER, body)
  }
}
