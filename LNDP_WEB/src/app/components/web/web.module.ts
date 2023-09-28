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
import { VisualCarrouselWebComponent } from './visual-carrousel-web/visual-carrousel-web.component';
import { ArtistDetailAlbumWebComponent } from './artist-detail-album-web/artist-detail-album-web.component';
import { ArtistVideosWebComponent } from './artist-videos-web/artist-videos-web.component';
import { ArtistDetailTableWebComponent } from './artist-detail-table-web/artist-detail-table-web.component';


@NgModule({
  declarations: [
    PrincipalWebComponent,
    MarketingWebComponent,
    AgencyWebComponent,
    TourManagerWebComponent,
    VisualWebComponent,
    ArtistaSellosWebComponent,
    ArtistDetailWebComponent,
    DossierWebComponent,
    VisualCarrouselWebComponent,
    ArtistDetailAlbumWebComponent,
    ArtistVideosWebComponent,
    ArtistDetailTableWebComponent,
  ],
  imports: [
    WebRoutingModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class WebModule { }
