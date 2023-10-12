import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ArtistAdminComponent } from './artist-admin/artist-admin.component';
import { ConcertAdminComponent } from './concert-admin/concert-admin.component';
import { FestivalAdminComponent } from './festival-admin/festival-admin.component';
import { UserAdminComponent } from './user-admin/user-admin.component';
import { HomeAdminComponent } from './home-admin/home-admin.component';
import { EventAdminComponent } from './event-admin/event-admin.component';
import { ArtistImageComponent } from './artist-image/artist-image.component';
import { ArtistSongComponent } from './artist-song/artist-song.component';
import { ArtistAlbumComponent } from './artist-album/artist-album.component';
import { IntranetComponent } from './intranet.component';
import { CompanyAdminComponent } from './company-admin/company-admin.component';


const routes: Routes = [
  {path : '',
    component : IntranetComponent,
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
        path : 'Usuarios',
        component : UserAdminComponent,
      },
      {
        path : 'Eventos',
        component : EventAdminComponent,
      },
      {
        path : 'ImagenesArtistas',
        component : ArtistImageComponent,
      },
      {
        path : 'Song',
        component : ArtistSongComponent,
      },
      {
        path : 'Albumes',
        component : ArtistAlbumComponent,
      },
      {
        path : 'Companies',
        component : CompanyAdminComponent,
      },
    ]}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class IntranetRoutingModule { }
