import { Component } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { EmailService } from 'src/app/services/email.service';
import { NotificationService } from 'src/app/services/notification.service';

@Component({
  selector: 'app-home-section-contact',
  templateUrl: './home-section-contact.component.html',
  styleUrls: ['./home-section-contact.component.scss'],
})
export class HomeSectionContactComponent {
  showCopyEmailError = false;
  constructor(
    private emailService: EmailService,
    private _formBuilder: FormBuilder,
    private _notificationService: NotificationService
  ) {}

  VOForm: FormGroup = this._formBuilder.group({
    copyEmail: new FormControl('', [Validators.required, Validators.email]),
    subject: new FormControl('', Validators.required),
    mailMessage: new FormControl('', Validators.required),
  });

  enviarFormulario() {
    let copyEmail = this.VOForm.get('copyEmail').value;
    let subject = this.VOForm.get('subject').value;
    let mailMessage = this.VOForm.get('mailMessage').value;

    if (this.VOForm.valid) {
      this.emailService
        .createPromo(copyEmail, subject, mailMessage)
        .subscribe((res) => {
          this._notificationService.showOkMessage(
            'Correo enviado correctamente'
          );
          this.showCopyEmailError = false;

          this.VOForm.reset();
        });
    } else {
      this.showCopyEmailError = true;
    }
  }
}
