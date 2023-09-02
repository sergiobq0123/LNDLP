import { Component } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { LoginService } from 'src/app/services/login.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent {
  isMobile: boolean = false;
  showMenu: boolean = false;

  constructor(private breakpointObserver: BreakpointObserver, private loginService : LoginService) {}

  ngOnInit() {
    this.breakpointObserver
      .observe([Breakpoints.HandsetPortrait])
      .subscribe((result) => {
        this.isMobile = result.matches;
        this.showMenu = false; // Oculta el menú desplegable al cargar la página
      });
  }

  toggleMenu() {
    this.showMenu = !this.showMenu;
  }

  login(){
    this.loginService.login("string", "string").subscribe({
      next: res =>{
        console.log(res);
        this.loginService.setToken(res.token);
      }
    })
  }
}
