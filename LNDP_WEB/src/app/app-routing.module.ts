import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { AuthGuard } from './guards/auth.guard';
import { LoginComponent } from './components/login/login.component';
import { LoginGuard } from './guards/login.guard';
import { GenericSidenavComponent } from './components/generic-sidenav/generic-sidenav.component';
import { ArtistAdminComponent } from './components/artist-admin/artist-admin.component';

const routes: Routes = [
  {
    path: '',
    component : HomeComponent,
  },
  {
    path : 'Login',
    component : LoginComponent,
  },
  {
    path : 'Intranet',
    component : GenericSidenavComponent,
    children :[
      {
        path : 'Artist',
        component : ArtistAdminComponent,
      },
    ]
  },
  {
    path : '**',
    redirectTo: '',
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
