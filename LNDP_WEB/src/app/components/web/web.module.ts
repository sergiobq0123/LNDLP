import { NgModule } from '@angular/core';
import { WebRoutingModule } from './web-routing.module'
import { MarketingWebComponent } from './marketing-web/marketing-web.component';
import { AgencyWebComponent } from './agency-web/agency-web.component';
import { TourManagerWebComponent } from './tour-manager-web/tour-manager-web.component';
import { VisualWebComponent } from './visual-web/visual-web.component';
import { ArtistaSellosWebComponent } from './artista-sellos-web/artista-sellos-web.component';
import { ArtistDetailWebComponent } from './artist-detail-web/artist-detail-web.component';
import { MaterialModule } from 'src/app/material/material/material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { VisualCarrouselWebComponent } from './visual-carrousel-web/visual-carrousel-web.component';
import { ArtistDetailTableWebComponent } from './artist-detail-table-web/artist-detail-table-web.component';
import { GenericYoutubeComponent } from './generic/generic-youtube/generic-youtube.component';
import { GenericCardComponent } from './generic/generic-card/generic-card.component';
import { GenericTitleComponent } from './generic/generic-title/generic-title.component';
import { ContactWebComponent } from './contact-web/contact-web.component';
import { HomePageWebComponent } from './home-page-web/home-page-web.component';


@NgModule({
  declarations: [
    MarketingWebComponent,
    AgencyWebComponent,
    TourManagerWebComponent,
    VisualWebComponent,
    ArtistaSellosWebComponent,
    ArtistDetailWebComponent,
    VisualCarrouselWebComponent,
    ArtistDetailTableWebComponent,
    GenericCardComponent,
    GenericYoutubeComponent,
    GenericTitleComponent,
    ContactWebComponent,
    HomePageWebComponent
  ],
  imports: [
    WebRoutingModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class WebModule { }
