import { Component } from '@angular/core';
import { Form, FormControl, FormGroup, Validators } from '@angular/forms';
import { EmailService } from 'src/app/services/email.service';

@Component({
  selector: 'app-contact-web',
  templateUrl: './contact-web.component.html',
  styleUrls: ['./contact-web.component.scss']
})
export class ContactWebComponent {
  email : FormGroup;

  constructor(private emailService : EmailService) {
    this.email = new FormGroup({
      nombre : new FormControl('', Validators.required),
      email : new FormControl('', Validators.required),
      mensaje : new FormControl('', Validators.required)
    })

  }
  enviarFormulario() {
    this.emailService.create(this.email.value).subscribe(res =>{
      console.log(res);
    })
  }
}
