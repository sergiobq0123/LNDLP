import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from 'src/app/material/material/material.module';
import { IntranetRoutingModule } from './intranet-routing.module';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { FestivalArtistDialogComponent } from './Asoc/festival-artist-dialog/festival-artist-dialog.component';
import { AlbumAdminComponent } from './album-admin/album-admin.component';
import { ArtistAdminComponent } from './artist-admin/artist-admin.component';
import { CompanyAdminComponent } from './company-admin/company-admin.component';
import { ConcertAdminComponent } from './concert-admin/concert-admin.component';
import { ConcertCrewComponent } from './concert-crew/concert-crew.component';
import { FestivalAdminComponent } from './festival-admin/festival-admin.component';
import { GeneralModule } from './general/general.module';
import { HomeAdminComponent } from './home-admin/home-admin.component';
import { IntranetComponent } from './intranet.component';
import { SongAdminComponent } from './song-admin/song-admin.component';
import { UserAdminComponent } from './user-admin/user-admin.component';
import { YoutubeVideoVisualComponent } from './youtube-video-visual/youtube-video-visual.component';
import { FestivalCrewComponent } from './festival-crew/festival-crew.component';


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
    ConcertCrewComponent,
    FestivalArtistDialogComponent,
    FestivalCrewComponent
  ],
  imports: [
    IntranetRoutingModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,
    GeneralModule,
    FontAwesomeModule
  ],
})
export class IntranetModule { }
