import { Component, Input, TemplateRef } from '@angular/core';

@Component({
  selector: 'app-generic-section',
  templateUrl: './generic-section.component.html',
  styleUrls: ['./generic-section.component.scss']
})
export class GenericSectionComponent {
  @Input() sectionTitle: string;
  @Input() contentTemplate : TemplateRef<any>

  ngOnInit(){
  }
}
