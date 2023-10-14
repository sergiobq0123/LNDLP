import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';
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
    public _authService: AuthService,
    public _router : Router,
    private _notificationService : NotificationService
    ) { }


    SubmitLogin(useremail, password) {
      this._authService.login(useremail, password).subscribe(
        {
        next: res =>{
          this._authService.setToken(res.token)
          this._router.navigateByUrl('')
        },
        error : error => {
          this._notificationService.showErrorOnSnackbar(error.error, 'Close', 3500)
          this.LoginForm.get('password').setValue('')
        }
      }
      )
    }


}
