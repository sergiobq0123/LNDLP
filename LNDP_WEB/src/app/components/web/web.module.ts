import { NgModule } from '@angular/core';
import { WebRoutingModule } from './web-routing.module';
import { WebComponent } from './web.component';
import { CommonSectionModule } from './common-section/common-section.module';
import { FaIconComponent } from '@fortawesome/angular-fontawesome';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

@NgModule({
  declarations: [WebComponent],
  imports: [WebRoutingModule, CommonSectionModule, FontAwesomeModule],
})
export class WebModule {}
