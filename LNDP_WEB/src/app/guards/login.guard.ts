import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot } from '@angular/router';
import { LoginService } from '../services/login.service';

@Injectable({
  providedIn: 'root'
})
export class LoginGuard implements CanActivate{
  /**
   *
   */
  constructor(private route : Router, private loginService : LoginService) { }

  canActivate(route : ActivatedRouteSnapshot, state : RouterStateSnapshot) : boolean {
    if(this.loginService.isLoggedIn()){
      this.route.navigate([''])
    }
    return true;
  }
}
