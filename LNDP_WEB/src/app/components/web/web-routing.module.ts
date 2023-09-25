import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MarketingWebComponent } from './marketing-web/marketing-web.component';
import { AgencyWebComponent } from './agency-web/agency-web.component';
import { VisualWebComponent } from './visual-web/visual-web.component';
import { TourManagerWebComponent } from './tour-manager-web/tour-manager-web.component';
import { ArtistaSellosWebComponent } from './artista-sellos-web/artista-sellos-web.component';
import { ArtistDetailWebComponent } from './artist-detail-web/artist-detail-web.component';
import { PrincipalWebComponent } from './principalWeb/principalWeb.component';


const routes: Routes = [
  {path : '',
    children :[
      {
        path : '',
        component : PrincipalWebComponent,
      },
      {
        path : 'Marketing',
        component : MarketingWebComponent,
      },
      {
        path : 'Agency',
        component : AgencyWebComponent,
      },
      {
        path : 'Visual',
        component : VisualWebComponent,
      },
      {
        path : 'Tourmanager',
        component : TourManagerWebComponent,
      },
      {
        path : 'ArtistasSellos',
        component : ArtistaSellosWebComponent,
      },
      {
        path : 'Artist/:id',
        component : ArtistDetailWebComponent,
      },
    ]}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class WebRoutingModule { }
