import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ArtistAdminComponent } from './artist-admin/artist-admin.component';
import { ConcertAdminComponent } from './concert-admin/concert-admin.component';
import { FestivalAdminComponent } from './festival-admin/festival-admin.component';
import { UserAdminComponent } from './user-admin/user-admin.component';
import { HomeAdminComponent } from './home-admin/home-admin.component';
import { IntranetComponent } from './intranet.component';
import { CompanyAdminComponent } from './company-admin/company-admin.component';
import { AlbumAdminComponent } from './album-admin/album-admin.component';
import { SongAdminComponent } from './song-admin/song-admin.component';
import { ConcertCrewComponent } from './concert-crew/concert-crew.component';
import { FestivalCrewComponent } from './festival-crew/festival-crew.component';
import { YoutubeVideoVisualComponent } from './youtube-video-visual/youtube-video-visual.component';

const routes: Routes = [
  {
    path: '',
    component: IntranetComponent,
    children: [
      {
        path: 'Home',
        component: HomeAdminComponent,
      },
      {
        path: 'Artistas',
        component: ArtistAdminComponent,
      },
      {
        path: 'Festivales',
        component: FestivalAdminComponent,
      },
      {
        path: 'Conciertos',
        component: ConcertAdminComponent,
      },
      {
        path: 'Usuarios',
        component: UserAdminComponent,
      },
      {
        path: 'Song',
        component: SongAdminComponent,
      },
      {
        path: 'Albumes',
        component: AlbumAdminComponent,
      },
      {
        path: 'Companies',
        component: CompanyAdminComponent,
      },
      {
        path: 'YoutubeVideos',
        component: YoutubeVideoVisualComponent,
      },
      {
        path: 'ConcertCrew',
        component: ConcertCrewComponent,
      },
      {
        path: 'FestivalCrew',
        component: FestivalCrewComponent,
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class IntranetRoutingModule {}
