import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GenericModule } from '../generic/generic.module';
import { AgencySectionWebComponent } from './agency-section-web/agency-section-web.component';



@NgModule({
  declarations: [
    AgencySectionWebComponent
  ],
  imports: [
    CommonModule,
    GenericModule
  ]
})
export class AgencySectionModule { }
