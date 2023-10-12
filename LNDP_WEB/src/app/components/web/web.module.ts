import { NgModule } from '@angular/core';
import { WebRoutingModule } from './web-routing.module';
import { WebComponent } from './web.component';
import { GenericModule } from './generic/generic.module';



@NgModule({
  declarations: [

    WebComponent
  ],
  imports: [
    WebRoutingModule,
    GenericModule
  ]
})
export class WebModule { }
