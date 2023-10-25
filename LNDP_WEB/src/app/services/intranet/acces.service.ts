import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Urls } from 'src/app/common/urls';
import { ServiceBaseService } from '../service-base.service';
import { Observable, Subject, tap } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AccesService extends ServiceBaseService {
  logginChangedEvent = new Subject<boolean>();
  private logginAttemps: number = 0;
  private maxLogginAttemps: number = 3;
  private rateLimitTimeout: number = 30000;
  private rateLimitExceededMsg =
    'To many failed login attemps. Please try again in ' +
    this.rateLimitTimeout / 1000 +
    'seconds';

  constructor(http: HttpClient) {
    super(http, Urls.ACCES);
  }

  Login(username: string, password: string) {
    let body = { username: username, password: password };
    return this.postSpecificUrl(this.getUrl + Urls.LOGIN, body).pipe(
      tap({
        next: (res) => this.resetRateLimit(),
        error: (error) => this.incrementLoginAttemps(),
      })
    );
  }

  ChangePassword(id: number, password: string) {
    let body = { username: null, password: password };
    return this.update(id, body);
  }

  incrementLoginAttemps() {
    this.logginAttemps++;
    setTimeout(() => this.resetRateLimit(), this.rateLimitTimeout);
  }

  resetRateLimit() {
    this.logginAttemps = 0;
  }

  isRateLimitExceeded() {
    return this.logginAttemps >= this.maxLogginAttemps;
  }
}
