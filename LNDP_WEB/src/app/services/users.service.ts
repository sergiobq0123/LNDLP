import { Injectable } from '@angular/core';
import { ServiceBaseService } from './service-base.service';
import { HttpClient } from '@angular/common/http';
import { Urls } from '../common/urls';

@Injectable({
  providedIn: 'root'
})
export class UsersService extends ServiceBaseService{

  constructor(http: HttpClient) {
    super(http, Urls.USER);
   }
}
