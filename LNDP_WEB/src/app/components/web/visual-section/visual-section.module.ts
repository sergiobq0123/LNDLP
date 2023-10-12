import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { VisualSectionWebComponent } from './visual-section-web/visual-section-web.component';
import { ViusalSectionCarrouselComponent } from './viusal-section-carrousel/viusal-section-carrousel.component';
import { GenericModule } from '../generic/generic.module';



@NgModule({
  declarations: [
    VisualSectionWebComponent,
    ViusalSectionCarrouselComponent
  ],
  imports: [
    CommonModule,
    GenericModule
  ]
})
export class VisualSectionModule { }
