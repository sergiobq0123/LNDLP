import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeSectionWebComponent } from './home-section-web/home-section-web.component';
import { HomeSectionContactComponent } from './home-section-contact/home-section-contact.component';
import { GenericModule } from '../generic/generic.module';
import { MaterialModule } from 'src/app/material/material/material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    HomeSectionWebComponent,
    HomeSectionContactComponent
  ],
  imports: [
    CommonModule,
    GenericModule,
    MaterialModule,
    ReactiveFormsModule
  ]
})
export class HomeSectionModule { }
