import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GenericCardComponent } from './generic-card/generic-card.component';
import { GenericTitleComponent } from './generic-title/generic-title.component';
import { GenericYoutubeComponent } from './generic-youtube/generic-youtube.component';
import { FooterComponent } from './footer/footer.component';
import { NavbarComponent } from './navbar/navbar.component';
import { MaterialModule } from 'src/app/material/material/material.module';
import { Router, RouterLink } from '@angular/router';



@NgModule({
  declarations: [
    GenericCardComponent,
    GenericTitleComponent,
    GenericYoutubeComponent,
    FooterComponent,
    NavbarComponent
  ],
  imports: [
    CommonModule,
    MaterialModule,
    RouterLink
  ],
  exports: [
    GenericCardComponent,
    GenericTitleComponent,
    GenericYoutubeComponent,
    FooterComponent,
    NavbarComponent
  ]
})
export class GenericModule { }
