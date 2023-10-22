import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AuthService } from './auth.service';
import { Observable } from 'rxjs';

@Injectable()
export class HttpInterceptorService implements HttpInterceptor {

  constructor(private authService : AuthService) { }


  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    let userToken = this.authService.getToken();
    if(userToken != null){
      let clonedReq = req.clone({
        headers : req.headers.set('Authorization', `Bearer ${userToken}`)
      })
      return next.handle(clonedReq);
    }
    return next.handle(req)
  }
}
