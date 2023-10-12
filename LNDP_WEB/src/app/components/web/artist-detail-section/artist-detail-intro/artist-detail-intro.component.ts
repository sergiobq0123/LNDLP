import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-artist-detail-intro',
  templateUrl: './artist-detail-intro.component.html',
  styleUrls: ['./artist-detail-intro.component.scss'],
})
export class ArtistDetailIntroComponent {
  @Input() photo: any;
  @Input() description: any;
}
