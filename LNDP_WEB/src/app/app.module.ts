import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './material/material/material.module';
import { NavbarComponent } from './components/navbar/navbar.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { GenericSidenavComponent } from './components/generic-sidenav/generic-sidenav.component';
import { GenericWindowComponent } from './components/generic-window/generic-window.component';
import { ArtistAdminComponent } from './components/Intranet/artist-admin/artist-admin.component';
import { GenericTableComponent } from './components/generic-table/generic-table.component';
import { GenericFormDialogComponent } from './components/generic-form-dialog/generic-form-dialog.component';
import { DeleteWindowComponent } from './components/delete-window/delete-window.component';
import { FestivalAdminComponent } from './components/Intranet/festival-admin/festival-admin.component';
import { ConcertAdminComponent } from './components/Intranet/concert-admin/concert-admin.component';
import { SocialNetwokAdminComponent } from './components/Intranet/social-netwok-admin/social-netwok-admin.component';
import { UserAdminComponent } from './components/Intranet/user-admin/user-admin.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    LoginComponent,
    NavbarComponent,
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
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
