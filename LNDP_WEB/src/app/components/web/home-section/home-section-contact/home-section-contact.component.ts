import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { EmailService } from 'src/app/services/email.service';

@Component({
  selector: 'app-home-section-contact',
  templateUrl: './home-section-contact.component.html',
  styleUrls: ['./home-section-contact.component.scss']
})
export class HomeSectionContactComponent {
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
