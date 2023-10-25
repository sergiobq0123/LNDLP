import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GenericModule } from '../generic/generic.module';
import { TourManagerSectionConciertosComponent } from './tour-manager-section-conciertos/tour-manager-section-conciertos.component';
import { TourManagerSectionComponent } from './tour-manager-section.component';
import { TourManagerSectionFestivalesComponent } from './tour-manager-section-festivales/tour-manager-section-festivales.component';



@NgModule({
  declarations: [
    TourManagerSectionComponent,
    TourManagerSectionConciertosComponent,
    TourManagerSectionFestivalesComponent
  ],
  imports: [
    CommonModule,
    GenericModule
  ]
})
export class TourManagerSectionModule { }
