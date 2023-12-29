import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FooterComponent } from './footer/footer.component';
import { NavbarComponent } from './navbar/navbar.component';
import { RouterLink } from '@angular/router';
import { MaterialModule } from 'src/app/material/material/material.module';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

@NgModule({
  declarations: [FooterComponent, NavbarComponent],
  imports: [CommonModule, RouterLink, MaterialModule, FontAwesomeModule],
  exports: [FooterComponent, NavbarComponent],
})
export class CommonSectionModule {}
