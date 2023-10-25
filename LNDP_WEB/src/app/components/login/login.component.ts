import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';
import { AccesService } from 'src/app/services/intranet/acces.service';
import { NotificationService } from 'src/app/services/notification.service';



@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {

  LoginForm : FormGroup = this._formBuilder.group({
    username: new FormControl('', Validators.required),
    password: new FormControl('', Validators.required)
  })

  constructor(
    private _formBuilder: FormBuilder,
    public _authService: AuthService,
    public _accesService: AccesService,
    public _router : Router,
    private _notificationService : NotificationService
    ) { }


  SubmitLogin(username: string, password: string) {
    this._accesService.Login(username, password).subscribe({
      next: res =>{
        this._authService.setToken(res.token)
        this._router.navigateByUrl('')
      },
      error : error => {
        this._notificationService.showErrorMessage(error.error.message)
        this.LoginForm.get('password').setValue('')
      }
    })
  }
}
