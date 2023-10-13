import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeSectionContactComponent } from './home-section-contact/home-section-contact.component';
import { GenericModule } from '../generic/generic.module';
import { MaterialModule } from 'src/app/material/material/material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HomeSectionServiciosComponent } from './home-section-servicios/home-section-servicios.component';
import { HomeSectionSpotifyComponent } from './home-section-spotify/home-section-spotify.component';
import { HomeSectionComponent } from './home-section.component';
import { HomeSectionPresentacionComponent } from './home-section-presentacion/home-section-presentacion.component';
import { RouterLink } from '@angular/router';



@NgModule({
  declarations: [
    HomeSectionContactComponent,
    HomeSectionServiciosComponent,
    HomeSectionSpotifyComponent,
    HomeSectionComponent,
    HomeSectionPresentacionComponent
  ],
  imports: [
    CommonModule,
    GenericModule,
    MaterialModule,
    ReactiveFormsModule,
    RouterLink
  ]
})
export class HomeSectionModule { }
