import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { AuthGuard } from './guards/auth.guard';
import { LoginComponent } from './components/login/login.component';
import { LoginGuard } from './guards/login.guard';
import { GenericSidenavComponent } from './intranet/generic-sidenav/generic-sidenav.component';
import { ArtistAdminComponent } from './intranet/artist-admin/artist-admin.component';
import { FestivalAdminComponent } from './intranet/festival-admin/festival-admin.component';
import { ConcertAdminComponent } from './intranet/concert-admin/concert-admin.component';
import { SocialNetwokAdminComponent } from './intranet/social-netwok-admin/social-netwok-admin.component';
import { UserAdminComponent } from './intranet/user-admin/user-admin.component';

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
      path: 'Intranet',
    loadChildren: () => import('./intranet/intranet.module').then(m => m.IntranetModule)
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
