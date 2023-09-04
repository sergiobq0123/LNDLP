import { Component } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { LoginService } from 'src/app/services/login.service';
import { AuthGuard } from '../../guards/auth.guard';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent {
  isMobile: boolean = false;
  showMenu: boolean = false;
  isLogin: boolean;
  nameLogin: string;

  constructor(private _breakpointObserver: BreakpointObserver, private _loginService : LoginService) {}


  ngOnInit() {
    this._breakpointObserver
      .observe([Breakpoints.HandsetPortrait])
      .subscribe((result) => {
        this.isMobile = result.matches;
        this.showMenu = false; // Oculta el menú desplegable al cargar la página
      });
      this.isLogin = this._loginService.isLoggedIn();
  }

  toggleMenu() {
    this.showMenu = !this.showMenu;
  }

  logout() {
    this._loginService.logout()
    console.log("logout");
    this.isLogin = false;
  }

}
