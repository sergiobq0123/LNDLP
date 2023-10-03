import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-generic-card',
  templateUrl: './generic-card.component.html',
  styleUrls: ['./generic-card.component.scss']
})
export class GenericCardComponent {
  @Input() buttonText : string;
  @Input() array : Array<any>;

  ngOnInit(){
    console.log(this.buttonText);

  }

}
