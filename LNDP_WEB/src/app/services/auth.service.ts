import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { LocalStorageService } from './local-storage.service';
import { HttpClient, HttpParams } from '@angular/common/http';
import { ServiceBaseService } from './service-base.service';
import { Urls } from '../common/urls';

@Injectable({
  providedIn: 'root'
})
export class AuthService extends ServiceBaseService{
  loginChangedEvent = new Subject()

  constructor(private LocalStorageService: LocalStorageService, http: HttpClient) {
    super(http, Urls.AUTH)
  }

  login(email: string, password: string): Observable<any>{
    const data = {
      email: email,
      password: password
    };
    return this.post(this.getUrl + Urls.LOGIN, data);
  }

  registrer(event : any){
    const data = {
      email: event.email,
      password: event.password,
      username : event.username,
      userRoleId: event.userRoleId,
      artistId : event.artistId
    };
    return this.post(this.getUrl + Urls.REGISTER, data);
  }

  logout(){
    this.LocalStorageService.clearStorage();
    this.loginChangedEvent.next(this.isLoggedIn());
  }

  isLoggedIn(){
    return this.getToken() != null;
  }
  whoIsLoggedIn(){
    return JSON.parse(atob(this.getToken().split('.')[1]))
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
