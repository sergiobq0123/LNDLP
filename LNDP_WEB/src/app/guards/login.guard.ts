import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot } from '@angular/router';
import { AuthService } from "../services/auth.service";


@Injectable({
  providedIn: 'root'
})
export class LoginGuard implements CanActivate{
  /**
   *
   */
  constructor(private route : Router, private _authSerive : AuthService) { }

  canActivate(route : ActivatedRouteSnapshot, state : RouterStateSnapshot) : boolean {
    if(this._authSerive.isLoggedIn()){
      this.route.navigate([''])
    }
    return true;
  }
}
