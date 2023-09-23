import { Injectable } from '@angular/core';
import { ServiceBaseService } from './service-base.service';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Urls } from '../common/urls';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EmailService extends ServiceBaseService{

  constructor(http: HttpClient) {
    super(http, Urls.EMAIL);
   }
}
