import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { LocalStorageService } from './local-storage.service';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  loginChangedEvent = new Subject();

  constructor(
    private _localStorageService: LocalStorageService
  ) {}

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

  getUserId(): number {
    return JSON.parse(atob(this.getToken().split('.')[1])).userId;
  }

  getRole(): string {
    return JSON.parse(atob(this.getToken().split('.')[1])).role;
  }
}
