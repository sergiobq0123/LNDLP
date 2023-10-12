import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-artist-detail-conciertos',
  templateUrl: './artist-detail-conciertos.component.html',
  styleUrls: ['./artist-detail-conciertos.component.scss']
})
export class ArtistDetailConciertosComponent {
  @Input() conciertos : Array<any>
}
