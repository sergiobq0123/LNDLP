import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FooterComponent } from './footer/footer.component';
import { NavbarComponent } from './navbar/navbar.component';
import { RouterLink } from '@angular/router';
import { MaterialModule } from 'src/app/material/material/material.module';



@NgModule({
  declarations: [
    FooterComponent,
    NavbarComponent
  ],
  imports: [
    CommonModule,
    RouterLink,
    MaterialModule
  ],
  exports: [
    FooterComponent,
    NavbarComponent
  ]
})
export class CommonSectionModule { }
