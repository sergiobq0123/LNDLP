import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { LoginService } from '../../services/login.service';
import { Router } from '@angular/router';
import { NotificationService } from 'src/app/services/notification.service';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {

  LoginForm : FormGroup = this._formBuilder.group({
    useremail: new FormControl('', Validators.required),
    password: new FormControl('', Validators.required)
  })

  constructor(
    private _formBuilder: FormBuilder,
    public _loginService: LoginService,
    public _router : Router,
    private _notificationService : NotificationService
    ) { }


    SubmitLogin(useremail, password) {
      this._loginService.login(useremail, password).subscribe({
        error : error => {
          console.log(error.error);

          this._notificationService.showError(error.error, 'Close', 3500)
          this.LoginForm.get('password').setValue('')
        },
        next: res =>{
          this._loginService.setToken(res.token)
          this._router.navigateByUrl('')
        }
      })
    }


}
