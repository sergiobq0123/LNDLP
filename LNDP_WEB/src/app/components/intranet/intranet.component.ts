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
  faGlobe,
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
  role: string;

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
  faHouse = faHouse;
  faGlobe = faGlobe;

  constructor(private _authService: AuthService) {}

  ngOnInit() {
    this.role = this._authService.getRole().toString();
  }

  logout() {
    this._authService.logout();
  }
}
