import { NgModule } from '@angular/core';
import { WebRoutingModule } from './web-routing.module';
import { WebComponent } from './web.component';
import { CommonSectionModule } from './common-section/common-section.module';



@NgModule({
  declarations: [
    WebComponent,
  ],
  imports: [
    WebRoutingModule,
    CommonSectionModule
  ]
})
export class WebModule { }
