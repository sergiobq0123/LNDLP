import { Component, ElementRef, ViewChild } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-intranet',
  templateUrl: './intranet.component.html',
  styleUrls: ['./intranet.component.scss']
})
export class IntranetComponent {
  @ViewChild(MatSidenav) sidenav!: MatSidenav;
  @ViewChild('toolbar_button', { read: ElementRef })
  toolbar_button!: ElementRef;
  //@ViewChild("toolbar_button") toolbar_button: ElementRef;
  events: string[] = [];
  opened: boolean = false;
  visible: boolean = true;
  isAdmin: boolean = false;

  loginSubscription: Subscription;

  constructor(
    private router: Router,
    private authService: AuthService,
  ) {}

  ngAfterViewInit() {
    this.loginSubscription = this.authService.getLoginEvent().subscribe(loggedIn => {
      if (!loggedIn) {
        this.opened = false;
      }
      this.visible = !!loggedIn || this.opened;
      this.toolbar_button.nativeElement.style.display = !!loggedIn ? '' : 'none';
    });
    this.authService.loginChangedEvent.next(this.authService.isLoggedIn());
  }

  ngOnDestroy() {
    this.loginSubscription.unsubscribe();
  }

  logout() {
    this.authService.logout()
    console.log("logout");
  }
}
