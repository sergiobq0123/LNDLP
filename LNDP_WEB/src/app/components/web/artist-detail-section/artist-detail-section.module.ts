import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ArtistDetailSectionWebComponent } from './artist-detail-section-web/artist-detail-section-web.component';
import { GenericModule } from '../generic/generic.module';
import { ArtistDetailTableComponent } from './artist-detail-table/artist-detail-table.component';



@NgModule({
  declarations: [
    ArtistDetailSectionWebComponent,
    ArtistDetailTableComponent,
  ],
  imports: [
    CommonModule,
    GenericModule
  ]
})
export class ArtistDetailSectionModule { }
