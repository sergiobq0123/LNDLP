import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { LocalStorageService } from './local-storage.service';
import { HttpClient, HttpParams } from '@angular/common/http';
import { ServiceBaseService } from './service-base.service';
import { Urls } from '../common/urls';

@Injectable({
  providedIn: 'root'
})
export class LoginService extends ServiceBaseService{
  loginChangedEvent = new Subject()

  constructor(private LocalStorageService: LocalStorageService, http: HttpClient) {
    super(http, Urls.LOGIN)
  }

  login(email: string, password: string): Observable<any>{
    return this.checkCredentials(email, password);
  }

  checkCredentials(email: string, password: string){
    let queryParams = new HttpParams();
    queryParams = queryParams.append("email", email)
    queryParams = queryParams.append("password", password)
    console.log(this.getUrl);

    const data = {
      email: email,
      password: password
    };

    return this.post(this.getUrl + Urls.CHECKACCES, data);
  }

  logout(){
    this.LocalStorageService.clearStorage();
    this.loginChangedEvent.next(this.isLoggedIn());
  }

  isLoggedIn(){
    return this.getToken() != null;
  }

  getToken(){
    return this.LocalStorageService.getItemFromLocalStorage('token')
  }

  setToken(token : string ){
    this.LocalStorageService.addItemToLocalStorage('token', token);
    this.loginChangedEvent.next(this.isLoggedIn());
  }

  getLoginEvent(){
    return this.loginChangedEvent.asObservable();
  }
}
