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
import { AuthGuard } from 'src/app/guards/auth.guard';
import { Role } from 'src/app/common/Role';

const routes: Routes = [
  {
    path: '',
    component: IntranetComponent,
    children: [
      {
        path: 'Home',
        component: HomeAdminComponent,
        canActivate: [AuthGuard],
        data: {
          allowedRoles: [Role.Admin, Role.Crew, Role.Visual],
        },
      },
      {
        path: 'Artistas',
        component: ArtistAdminComponent,
        canActivate: [AuthGuard],
        data: {
          allowedRoles: [Role.Admin],
        },
      },
      {
        path: 'Festivales',
        component: FestivalAdminComponent,
        canActivate: [AuthGuard],
        data: {
          allowedRoles: [Role.Admin],
        },
      },
      {
        path: 'Conciertos',
        component: ConcertAdminComponent,
        canActivate: [AuthGuard],
        data: {
          allowedRoles: [Role.Admin],
        },
      },
      {
        path: 'Usuarios',
        component: UserAdminComponent,
        canActivate: [AuthGuard],
        data: {
          allowedRoles: [Role.Admin],
        },
      },
      {
        path: 'Song',
        component: SongAdminComponent,
        canActivate: [AuthGuard],
        data: {
          allowedRoles: [Role.Admin],
        },
      },
      {
        path: 'Albumes',
        component: AlbumAdminComponent,
        canActivate: [AuthGuard],
        data: {
          allowedRoles: [Role.Admin],
        },
      },
      {
        path: 'Companies',
        component: CompanyAdminComponent,
        canActivate: [AuthGuard],
        data: {
          allowedRoles: [Role.Admin],
        },
      },
      {
        path: 'YoutubeVideos',
        component: YoutubeVideoVisualComponent,
        canActivate: [AuthGuard],
        data: {
          allowedRoles: [Role.Visual],
        },
      },
      {
        path: 'ConcertCrew',
        component: ConcertCrewComponent,
        canActivate: [AuthGuard],
        data: {
          allowedRoles: [Role.Crew],
        },
      },
      {
        path: 'FestivalCrew',
        component: FestivalCrewComponent,
        canActivate: [AuthGuard],
        data: {
          allowedRoles: [Role.Crew],
        },
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class IntranetRoutingModule {}
