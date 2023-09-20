import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ArtistAdminComponent } from './artist-admin/artist-admin.component';
import { GenericSidenavComponent } from './generic-sidenav/generic-sidenav.component';
import { ConcertAdminComponent } from './concert-admin/concert-admin.component';
import { FestivalAdminComponent } from './festival-admin/festival-admin.component';
import { SocialNetwokAdminComponent } from './social-netwok-admin/social-netwok-admin.component';
import { UserAdminComponent } from './user-admin/user-admin.component';
import { HomeAdminComponent } from './home-admin/home-admin.component';
import { EventAdminComponent } from './event-admin/event-admin.component';
import { CrewAdminComponent } from './crew-admin/crew-admin.component';
import { ArtistImageComponent } from './artist-image/artist-image.component';

const routes: Routes = [
  {path : '',
    component : GenericSidenavComponent,
    children :[
      {
        path : 'Home',
        component : HomeAdminComponent,
      },
      {
        path : 'Artistas',
        component : ArtistAdminComponent,
      },
      {
        path : 'Festivales',
        component : FestivalAdminComponent,
      },
      {
        path : 'Conciertos',
        component : ConcertAdminComponent,
      },
      {
        path : 'RedesSociales',
        component : SocialNetwokAdminComponent,
      },
      {
        path : 'Usuarios',
        component : UserAdminComponent,
      },
      {
        path : 'Eventos',
        component : EventAdminComponent,
      },
      {
        path : 'Equipos',
        component : CrewAdminComponent,
      },
      {
        path : 'ImagenesArtistas',
        component : ArtistImageComponent,
      },
    ]}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class IntranetRoutingModule { }
