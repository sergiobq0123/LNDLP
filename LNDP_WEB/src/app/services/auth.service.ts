import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { LocalStorageService } from './local-storage.service';
import { HttpClient, HttpParams } from '@angular/common/http';
import { ServiceBaseService } from './service-base.service';
import { Urls } from '../common/urls';

@Injectable({
  providedIn: 'root',
})
export class AuthService extends ServiceBaseService {
  loginChangedEvent = new Subject();

  constructor(
    private _localStorageService: LocalStorageService,
    http: HttpClient
  ) {
    super(http, Urls.AUTH);
  }

  login(email: string, password: string): Observable<any> {
    const data = {
      email: email,
      password: password,
    };
    return this.post(this.getUrl + Urls.LOGIN, data);
  }

  registrer(event: any) {
    return this.post(this.getUrl + Urls.REGISTER , event);
  }

  logout() {
    this._localStorageService.clearStorage();
    this.loginChangedEvent.next(this.isLoggedIn());
  }

  isLoggedIn() {
    return this.getToken() != null;
  }

  whoIsLoggedIn() {
    return JSON.parse(atob(this.getToken().split('.')[1]));
  }

  getToken() {
    return this._localStorageService.getItemFromLocalStorage('token');
  }

  setToken(token: string) {
    this._localStorageService.addItemToLocalStorage('token', token);
    this.loginChangedEvent.next(this.isLoggedIn());
  }

  getLoginEvent() {
    return this.loginChangedEvent.asObservable();
  }
}
