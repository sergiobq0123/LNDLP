import { Injectable } from '@angular/core';
import {
  ActivatedRouteSnapshot,
  CanActivate,
  Router,
  RouterStateSnapshot,
} from '@angular/router';
import { AuthService } from '../services/auth.service';
import { NotificationService } from '../services/notification.service';
import { notifications } from '../common/notifications';
import { UserRole } from '../models/userRole.model';
import { RouterLink } from '@angular/router';

@Injectable({
  providedIn: 'root',
})
export class AuthGuard implements CanActivate {
  constructor(
    private _router: Router,
    private _authService: AuthService,
    private _notificationService: NotificationService
  ) {}

  canActivate(
    route: ActivatedRouteSnapshot,
    _state: RouterStateSnapshot
  ): boolean {
    let url: string = _state.url;
    return this.checkUserLogin(route, url);
  }

  checkUserLogin(route: ActivatedRouteSnapshot, url: string) {
    const isLoggedIn = this._authService.isLoggedIn();

    if (!isLoggedIn) {
      this._authService.logout();
      this._notificationService.showOkMessage(
        notifications.JWT_UNAUTHORIZED_RESPONSE
      );
      this._router.navigate(['']);
      return false;
    }
    const userRole = this._authService.getRole();
    const allowedRoles = route.data['allowedRoles'] as UserRole[];

    if (allowedRoles && allowedRoles.length > 0) {
      if (!allowedRoles.includes(userRole)) {
        this._router.navigate(['Home']);
        return false;
      }
    }
    return true;
  }
}
