import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GenericModule } from '../generic/generic.module';
import { MarketingArtistWebComponent } from './marketing-artist-web/marketing-artist-web.component';
import { MarketingSellosComponent } from './marketing-sellos/marketing-sellos.component';
import { MarketingSectionComponent } from './marketing-section.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';



@NgModule({
  declarations: [
    MarketingSectionComponent,
    MarketingArtistWebComponent,
    MarketingSellosComponent,
  ],
  imports: [
    CommonModule,
    GenericModule,
    FontAwesomeModule
  ]
})
export class MarketingSectionModule { }
