import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-generic-title',
  templateUrl: './generic-title.component.html',
  styleUrls: ['./generic-title.component.scss']
})
export class GenericTitleComponent {
  @Input() title : string
  @Input() description: string
}
