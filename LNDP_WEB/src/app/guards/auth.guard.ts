import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot } from '@angular/router';
import { LoginService } from '../services/login.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private router: Router, private loginService: LoginService) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    const isLoggedIn = this.loginService.isLoggedIn();
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
