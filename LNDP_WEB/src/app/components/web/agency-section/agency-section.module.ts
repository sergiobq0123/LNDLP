import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GenericModule } from '../generic/generic.module';
import { AgencySectionComponent } from './agency-section.component';
import { AgencySectionMarcasComponent } from './agency-section-marcas/agency-section-marcas.component';
import { AgencySectionPartnersComponent } from './agency-section-partners/agency-section-partners.component';



@NgModule({
  declarations: [
    AgencySectionComponent,
    AgencySectionMarcasComponent,
    AgencySectionPartnersComponent
  ],
  imports: [
    CommonModule,
    GenericModule
  ]
})
export class AgencySectionModule { }
