import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { AuthGuard } from './guards/auth.guard';
import { LoginComponent } from './components/login/login.component';
import { LoginGuard } from './guards/login.guard';
import { GenericSidenavComponent } from './components/intranet/generic-sidenav/generic-sidenav.component';
import { ArtistAdminComponent } from './components/intranet/artist-admin/artist-admin.component';
import { FestivalAdminComponent } from './components/intranet/festival-admin/festival-admin.component';
import { ConcertAdminComponent } from './components/intranet/concert-admin/concert-admin.component';
import { UserAdminComponent } from './components/intranet/user-admin/user-admin.component';
import { MarketingWebComponent } from './components/marketing-web/marketing-web.component';
import { AgencyWebComponent } from './components/agency-web/agency-web.component';
import { VisualWebComponent } from './components/visual-web/visual-web.component';
import { TourManagerWebComponent } from './components/tour-manager-web/tour-manager-web.component';
import { ArtistaSellosWebComponent } from './components/artista-sellos-web/artista-sellos-web.component';
import { ArtistDetailWebComponent } from './components/artist-detail-web/artist-detail-web.component';

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
    loadChildren: () => import('./components/intranet/intranet.module').then(m => m.IntranetModule)
  },
  {
    path : 'Marketing',
    component : MarketingWebComponent,
  },
  {
    path : 'Agency',
    component : AgencyWebComponent,
  },
  {
    path : 'Visual',
    component : VisualWebComponent,
  },
  {
    path : 'Tourmanager',
    component : TourManagerWebComponent,
  },
  {
    path : 'ArtistasSellos',
    component : ArtistaSellosWebComponent,
  },
  {
    path : 'Login',
    component : LoginComponent,
  },
  {
    path : 'Artist/:id',
    component : ArtistDetailWebComponent,
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
