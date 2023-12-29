import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { LocalStorageService } from './local-storage.service';
import { UserRole } from '../models/userRole.model';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  loginChangedEvent = new Subject();

  constructor(private _localStorageService: LocalStorageService) {}

  logout() {
    this._localStorageService.clearStorage();
    this.loginChangedEvent.next(this.isLoggedIn());
  }

  isLoggedIn() {
    const token = this.getToken();
    if (token != null) {
      const payload = atob(token.split('.')[1]);
      const parsedPayload = JSON.parse(payload);
      return parsedPayload.exp > Date.now() / 1000;
    }
    return false;
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

  getRole(): UserRole {
    return JSON.parse(atob(this.getToken().split('.')[1])).role as UserRole;
  }
}
