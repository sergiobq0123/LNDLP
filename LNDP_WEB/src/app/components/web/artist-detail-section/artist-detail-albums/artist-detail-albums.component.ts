import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-artist-detail-albums',
  templateUrl: './artist-detail-albums.component.html',
  styleUrls: ['./artist-detail-albums.component.scss']
})
export class ArtistDetailAlbumsComponent {
  @Input() albums : Array<any>
}
