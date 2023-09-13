import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { LoginService } from './login.service';
import { Observable } from 'rxjs';

@Injectable()
export class HttpInterceptorService implements HttpInterceptor {

  constructor(private _loginService : LoginService) { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    let userToken = this._loginService.getToken();
    if(userToken != null){
      let clonedReq = req.clone({
        headers : req.headers.set('Authorization', `Bearer ${userToken}`)
      })
      return next.handle(clonedReq);
    }
    return next.handle(req)
  }
}
