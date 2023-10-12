import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MarketingSectionWebComponent } from './marketing-section-web/marketing-section-web.component';
import { GenericModule } from '../generic/generic.module';
import { MarketingArtistWebComponent } from './marketing-artist-web/marketing-artist-web.component';



@NgModule({
  declarations: [
    MarketingSectionWebComponent,
    MarketingArtistWebComponent,
  ],
  imports: [
    CommonModule,
    GenericModule
  ]
})
export class MarketingSectionModule { }
