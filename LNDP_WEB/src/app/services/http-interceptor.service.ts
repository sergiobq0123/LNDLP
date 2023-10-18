import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AuthService } from './auth.service';
import { Observable } from 'rxjs';

@Injectable()
export class HttpInterceptorService implements HttpInterceptor {

  constructor(private _authService : AuthService) { }


  ngOnInit(){
    console.log("hola");
  }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    let userToken = this._authService.getToken();
    console.log(this._authService.getToken());
    console.log("hola");

    if(userToken != null){
      let clonedReq = req.clone({
        headers : req.headers.set('Authorization', `Bearer ${userToken}`)
      })
      return next.handle(clonedReq);
    }
    return next.handle(req)
  }
}
