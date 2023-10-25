import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot } from '@angular/router';
import { AuthService } from "../services/auth.service";

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private router: Router, private _authService: AuthService) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {

    const isLoggedIn = this._authService.isLoggedIn();
    let pass = false;
    if (isLoggedIn) {
      pass = true;
    } else {
      pass = false;
      this.router.navigate(['/Login']);
    }
    return pass;
  }
}
