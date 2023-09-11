import { Component } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { LoginService } from 'src/app/services/login.service';
import { UsersService } from 'src/app/services/users.service';
import { User } from 'src/app/models/user.model';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent {
  isMobile: boolean = false;
  showMenu: boolean = false;
  isLogin: boolean;
  nameLogin: string;
  user: User;

  constructor(private _breakpointObserver: BreakpointObserver, private _loginService : LoginService, private _usersService : UsersService) {}


  ngOnInit() {
    this._breakpointObserver
      .observe([Breakpoints.HandsetPortrait])
      .subscribe((result) => {
        this.isMobile = result.matches;
        this.showMenu = false; // Oculta el menú desplegable al cargar la página
      });
      this.isLogin = this._loginService.isLoggedIn();
      this.getUser();
  }

  getUser():void {
    var userLoggin = this._loginService.whoIsLoggedIn();
    this._usersService.get(+userLoggin.userID).subscribe((res) => {
      this.user = res;
    })
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
