import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './material/material/material.module';
import { NavbarComponent } from './components/navbar/navbar.component';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ServiceBaseService } from './services/service-base.service';
import { HttpInterceptorService } from './services/http-interceptor.service';
import { DossierWebComponent } from './components/dossier-web/dossier-web.component';
import { MarketingWebComponent } from './components/marketing-web/marketing-web.component';
import { AgencyWebComponent } from './components/agency-web/agency-web.component';
import { VisualWebComponent } from './components/visual-web/visual-web.component';
import { TourManagerWebComponent } from './components/tour-manager-web/tour-manager-web.component';
import { ArtistaSellosWebComponent } from './components/artista-sellos-web/artista-sellos-web.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    LoginComponent,
    NavbarComponent,
    DossierWebComponent,
    MarketingWebComponent,
    AgencyWebComponent,
    VisualWebComponent,
    TourManagerWebComponent,
    ArtistaSellosWebComponent,
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
  providers: [ServiceBaseService, {provide : HTTP_INTERCEPTORS, useClass : HttpInterceptorService, multi: true}],
  bootstrap: [AppComponent]
})
export class AppModule { }
