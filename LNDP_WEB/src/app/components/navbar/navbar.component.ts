import { Component } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { User } from 'src/app/models/user.model';
import { UsersService } from 'src/app/services/intranet/users.service';
import { AuthService } from 'src/app/services/auth.service';

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

  constructor(private _breakpointObserver: BreakpointObserver, private _authService : AuthService, private _usersService : UsersService) {}


  ngOnInit() {
    this._breakpointObserver
      .observe([Breakpoints.HandsetPortrait])
      .subscribe((result) => {
        this.isMobile = result.matches;
        this.showMenu = false; // Oculta el menú desplegable al cargar la página
      });
      this.isLogin = this._authService.isLoggedIn();
      this.getUser();
  }

  getUser():void {
    var userLoggin = this._authService.whoIsLoggedIn();
    this._usersService.get(+userLoggin.userID).subscribe((res) => {
      this.user = res;
    })
  }

  toggleMenu() {
    this.showMenu = !this.showMenu;
  }

  logout() {
    this._authService.logout()
    console.log("logout");
    this.isLogin = false;
  }

}
