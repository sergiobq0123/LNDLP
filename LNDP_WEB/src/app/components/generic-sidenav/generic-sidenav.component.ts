import { Component, ElementRef } from '@angular/core';
import { ViewChild } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { LocalStorageService } from 'src/app/services/local-storage.service';
import { LoginService } from 'src/app/services/login.service';

@Component({
  selector: 'app-generic-sidenav',
  templateUrl: './generic-sidenav.component.html',
  styleUrls: ['./generic-sidenav.component.css'],
})
export class GenericSidenavComponent {
  @ViewChild(MatSidenav) sidenav!: MatSidenav;
  opened: boolean = false;
  visible: boolean = true;


  constructor(private router: Router, private loginService: LoginService) {}


}
