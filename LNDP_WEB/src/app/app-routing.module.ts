import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { AuthGuard } from './guards/auth.guard';
import { LoginComponent } from './components/login/login.component';
import { LoginGuard } from './guards/login.guard';
import { GenericSidenavComponent } from './components/generic-sidenav/generic-sidenav.component';
import { ArtistAdminComponent } from './components/Intranet/artist-admin/artist-admin.component';
import { FestivalAdminComponent } from './components/Intranet/festival-admin/festival-admin.component';
import { ConcertAdminComponent } from './components/Intranet/concert-admin/concert-admin.component';
import { SocialNetwokAdminComponent } from './components/Intranet/social-netwok-admin/social-netwok-admin.component';
import { UserAdminComponent } from './components/Intranet/user-admin/user-admin.component';

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
      {
        path : 'Festival',
        component : FestivalAdminComponent,
      },
      {
        path : 'Concert',
        component : ConcertAdminComponent,
      },
      {
        path : 'SocialNetwork',
        component : SocialNetwokAdminComponent,
      },
      {
        path : 'User',
        component : UserAdminComponent,
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
