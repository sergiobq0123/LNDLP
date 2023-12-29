import { Component } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { User } from 'src/app/models/user.model';
import { UsersService } from 'src/app/services/intranet/users.service';
import { AuthService } from 'src/app/services/auth.service';
import {
  faAngleDown,
  faAngleUp,
  faBars,
  faCheck,
  faColumns,
  faCopy,
  faEye,
  faEyeSlash,
  faFilter,
  faInfo,
  faPen,
  faPlus,
  faSyncAlt,
  faTimes,
  faTrash,
  faUser,
} from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss'],
})
export class NavbarComponent {
  isMobile: boolean = false;
  showMenu: boolean = false;
  isLogin: boolean;
  nameLogin: string;
  user: User;
  faUser = faUser;

  constructor(
    private _breakpointObserver: BreakpointObserver,
    private _authService: AuthService
  ) {}

  ngOnInit() {
    this._breakpointObserver
      .observe([Breakpoints.HandsetPortrait])
      .subscribe((result) => {
        this.isMobile = result.matches;
        this.showMenu = false;
      });
    this.isLogin = this._authService.isLoggedIn();
  }

  toggleMenu() {
    this.showMenu = !this.showMenu;
  }
  toggleMenuNot() {
    this.showMenu = this.showMenu;
  }

  logout() {
    this._authService.logout();
    this.isLogin = false;
  }
}
