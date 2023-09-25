import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WebRoutingModule } from './web-routing.module'
import { PrincipalWebComponent } from './principalWeb/principalWeb.component';
import { MarketingWebComponent } from './marketing-web/marketing-web.component';
import { AgencyWebComponent } from './agency-web/agency-web.component';
import { TourManagerWebComponent } from './tour-manager-web/tour-manager-web.component';
import { VisualWebComponent } from './visual-web/visual-web.component';
import { ArtistaSellosWebComponent } from './artista-sellos-web/artista-sellos-web.component';
import { ArtistDetailWebComponent } from './artist-detail-web/artist-detail-web.component';
import { MaterialModule } from 'src/app/material/material/material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DossierWebComponent } from './dossier-web/dossier-web.component';


@NgModule({
  declarations: [
    PrincipalWebComponent,
    MarketingWebComponent,
    AgencyWebComponent,
    TourManagerWebComponent,
    VisualWebComponent,
    ArtistaSellosWebComponent,
    ArtistDetailWebComponent,
    DossierWebComponent
  ],
  imports: [
    WebRoutingModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class WebModule { }
