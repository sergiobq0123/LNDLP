import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from 'src/app/material/material/material.module';
import { IntranetRoutingModule } from './intranet-routing.module';
import { ArtistAdminComponent } from './artist-admin/artist-admin.component';
import { FestivalAdminComponent } from './festival-admin/festival-admin.component';
import { ConcertAdminComponent } from './concert-admin/concert-admin.component';
import { UserAdminComponent } from './user-admin/user-admin.component';
import { HomeAdminComponent } from './home-admin/home-admin.component';
import { IntranetComponent } from './intranet.component';
import { CompanyAdminComponent } from './company-admin/company-admin.component';
import { GeneralModule } from './general/general.module';
import { AlbumAdminComponent } from './album-admin/album-admin.component';
import { SongAdminComponent } from './song-admin/song-admin.component';
import { YoutubeVideoVisualComponent } from './youtube-video-visual/youtube-video-visual.component';
import { ConcertCrewComponent } from './concert-crew/concert-crew.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';


@NgModule({
  declarations: [
    ArtistAdminComponent,
    FestivalAdminComponent,
    ConcertAdminComponent,
    UserAdminComponent,
    HomeAdminComponent,
    IntranetComponent,
    CompanyAdminComponent,
    AlbumAdminComponent,
    SongAdminComponent,
    YoutubeVideoVisualComponent,
    ConcertCrewComponent
  ],
  imports: [
    IntranetRoutingModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,
    GeneralModule,
    FontAwesomeModule
  ]
})
export class IntranetModule { }
