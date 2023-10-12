import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from 'src/app/material/material/material.module';
import { IntranetRoutingModule } from './intranet-routing.module';
import { GenericWindowComponent } from './general/generic-window/generic-window.component';
import { ArtistAdminComponent } from './artist-admin/artist-admin.component';
import { GenericTableComponent } from './general/generic-table/generic-table.component';
import { GenericFormDialogComponent } from './general/generic-form-dialog/generic-form-dialog.component';
import { DeleteWindowComponent } from './delete-window/delete-window.component';
import { FestivalAdminComponent } from './festival-admin/festival-admin.component';
import { ConcertAdminComponent } from './concert-admin/concert-admin.component';
import { UserAdminComponent } from './user-admin/user-admin.component';
import { HomeAdminComponent } from './home-admin/home-admin.component';
import { EventAdminComponent } from './event-admin/event-admin.component';
import { ArtistImageComponent } from './artist-image/artist-image.component';
import { ArtistSongComponent } from './artist-song/artist-song.component';
import { ArtistAlbumComponent } from './artist-album/artist-album.component';
import { SpinnerComponent } from './spinner/spinner.component';
import { GenericFilterComponent } from './general/generic-filter/generic-filter.component';
import { IntranetComponent } from './intranet.component';
import { CompanyAdminComponent } from './company-admin/company-admin.component';



@NgModule({
  declarations: [
    GenericWindowComponent,
    ArtistAdminComponent,
    GenericTableComponent,
    GenericFormDialogComponent,
    DeleteWindowComponent,
    FestivalAdminComponent,
    ConcertAdminComponent,
    UserAdminComponent,
    HomeAdminComponent,
    EventAdminComponent,
    ArtistImageComponent,
    ArtistSongComponent,
    ArtistAlbumComponent,
    SpinnerComponent,
    GenericFilterComponent,
    IntranetComponent,
    CompanyAdminComponent
  ],
  imports: [
    IntranetRoutingModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,
  ]
})
export class IntranetModule { }
