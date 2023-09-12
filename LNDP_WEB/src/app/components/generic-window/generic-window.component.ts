import { Component, Input, TemplateRef } from '@angular/core';

@Component({
  selector: 'app-generic-window',
  templateUrl: './generic-window.component.html',
  styleUrls: ['./generic-window.component.scss']
})
export class GenericWindowComponent {
@Input() windowTitle: string;
@Input() contentTemplate : TemplateRef<any>
}
