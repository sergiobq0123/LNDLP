import { Component, ElementRef, ViewChild } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { AuthService } from 'src/app/services/auth.service';
import {
  faMusic,
  faCompactDisc,
  faCircleUser,
  faGear,
  faBriefcase,
  faPlay,
  faPodcast,
  faMicrophoneLines,
  faHouse,
  faGlobe
} from '@fortawesome/free-solid-svg-icons';
import { faYoutube } from '@fortawesome/free-brands-svg-icons';

@Component({
  selector: 'app-intranet',
  templateUrl: './intranet.component.html',
  styleUrls: ['./intranet.component.scss'],
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
  role : string;

  loginSubscription: Subscription;

  faYoutube = faYoutube;
  faMusic = faMusic;
  faCompactDisc = faCompactDisc;
  faCircleUser = faCircleUser;
  faGear = faGear;
  faBriefcase = faBriefcase;
  faPlay = faPlay;
  faPodcast = faPodcast;
  faMicrophoneLines = faMicrophoneLines;
  faHouse = faHouse
  faGlobe = faGlobe

  constructor(private router: Router, private _authService: AuthService) {}

  ngAfterViewInit() {
    this.loginSubscription = this._authService
      .getLoginEvent()
      .subscribe((loggedIn) => {
        if (!loggedIn) {
          this.opened = false;
        }
        this.visible = !!loggedIn || this.opened;
        this.toolbar_button.nativeElement.style.display = !!loggedIn
          ? ''
          : 'none';
      });
    this._authService.loginChangedEvent.next(this._authService.isLoggedIn());
    this.role = this._authService.getRole();
  }

  ngOnDestroy() {
    this.loginSubscription.unsubscribe();
  }

  logout() {
    this._authService.logout();
  }
}
