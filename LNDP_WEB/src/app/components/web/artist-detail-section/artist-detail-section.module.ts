import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GenericModule } from '../generic/generic.module';
import { ArtistDetailIntroComponent } from './artist-detail-intro/artist-detail-intro.component';
import { ArtistDetailSectionComponent } from './artist-detail-section.component';
import { ArtistDetailSongsComponent } from './artist-detail-songs/artist-detail-songs.component';
import { ArtistDetailAlbumsComponent } from './artist-detail-albums/artist-detail-albums.component';
import { ArtistDetailConciertosComponent } from './artist-detail-conciertos/artist-detail-conciertos.component';



@NgModule({
  declarations: [
    ArtistDetailSectionComponent,
    ArtistDetailIntroComponent,
    ArtistDetailSongsComponent,
    ArtistDetailAlbumsComponent,
    ArtistDetailConciertosComponent,
  ],
  imports: [
    CommonModule,
    GenericModule
  ]
})
export class ArtistDetailSectionModule { }
