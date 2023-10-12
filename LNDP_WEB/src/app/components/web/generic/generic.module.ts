import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GenericCardComponent } from './generic-card/generic-card.component';
import { GenericTitleComponent } from './generic-title/generic-title.component';
import { GenericYoutubeComponent } from './generic-youtube/generic-youtube.component';
import { MaterialModule } from 'src/app/material/material/material.module';
import { RouterLink } from '@angular/router';
import { GenericSectionComponent } from './generic-section/generic-section.component';



@NgModule({
  declarations: [
    GenericCardComponent,
    GenericTitleComponent,
    GenericYoutubeComponent,
    GenericSectionComponent
  ],
  imports: [
    CommonModule,
    MaterialModule,
  ],
  exports: [
    GenericCardComponent,
    GenericTitleComponent,
    GenericYoutubeComponent,
    GenericSectionComponent
  ]
})
export class GenericModule { }
