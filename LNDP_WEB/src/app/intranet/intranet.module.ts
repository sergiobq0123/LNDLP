import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { IntranetRoutingModule } from './intranet-routing.module';
import { ArtistAdminComponent } from './artist-admin/artist-admin.component';
import { ConcertAdminComponent } from './concert-admin/concert-admin.component';
import { DeleteWindowComponent } from './delete-window/delete-window.component';
import { FestivalAdminComponent } from './festival-admin/festival-admin.component';
import { GenericFormDialogComponent } from './generic-form-dialog/generic-form-dialog.component';
import { GenericSidenavComponent } from './generic-sidenav/generic-sidenav.component';
import { GenericTableComponent } from './generic-table/generic-table.component';
import { GenericWindowComponent } from './generic-window/generic-window.component';
import { SocialNetwokAdminComponent } from './social-netwok-admin/social-netwok-admin.component';
import { UserAdminComponent } from './user-admin/user-admin.component';
import { MaterialModule } from '../material/material/material.module';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from '../app-routing.module';
import { HomeAdminComponent } from './home-admin/home-admin.component';
import { EventAdminComponent } from './event-admin/event-admin.component';
import { CrewAdminComponent } from './crew-admin/crew-admin.component';
import { DialogImagenAdminComponent } from './dialog-imagen-admin/dialog-imagen-admin.component';
import { ArtistCrewComponent } from './artist-crew/artist-crew.component';


@NgModule({
  declarations: [
    GenericSidenavComponent,
    GenericWindowComponent,
    ArtistAdminComponent,
    GenericTableComponent,
    GenericFormDialogComponent,
    DeleteWindowComponent,
    FestivalAdminComponent,
    ConcertAdminComponent,
    SocialNetwokAdminComponent,
    UserAdminComponent,
    HomeAdminComponent,
    EventAdminComponent,
    CrewAdminComponent,
    DialogImagenAdminComponent,
    ArtistCrewComponent,
  ],
  imports: [
    IntranetRoutingModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,
  ]
})
export class IntranetModule { }
