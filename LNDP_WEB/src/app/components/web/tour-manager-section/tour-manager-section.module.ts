import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GenericModule } from '../generic/generic.module';
import { TourManagerSectionWebComponent } from './tour-manager-section-web/tour-manager-section-web.component';



@NgModule({
  declarations: [
    TourManagerSectionWebComponent
  ],
  imports: [
    CommonModule,
    GenericModule
  ]
})
export class TourManagerSectionModule { }
