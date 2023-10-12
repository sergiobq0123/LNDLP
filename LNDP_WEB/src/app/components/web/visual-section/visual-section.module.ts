import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ViusalSectionCarrouselComponent } from './viusal-section-carrousel/viusal-section-carrousel.component';
import { GenericModule } from '../generic/generic.module';
import { VisualSectionVideosComponent } from './visual-section-videos/visual-section-videos.component';
import { VisualSectionComponent } from './visual-section.component';
import { VisualSectionCarrouselComunComponent } from './visual-section-carrousel-comun/visual-section-carrousel-comun.component';
import { VisualSectionInstagramComponent } from './visual-section-instagram/visual-section-instagram.component';



@NgModule({
  declarations: [
    VisualSectionComponent,
    ViusalSectionCarrouselComponent,
    VisualSectionVideosComponent,
    VisualSectionCarrouselComunComponent,
    VisualSectionInstagramComponent
  ],
  imports: [
    CommonModule,
    GenericModule
  ]
})
export class VisualSectionModule { }
