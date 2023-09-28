import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-artist-detail-album-web',
  templateUrl: './artist-detail-album-web.component.html',
  styleUrls: ['./artist-detail-album-web.component.scss']
})
export class ArtistDetailAlbumWebComponent {
  @Input() array : Array<any>;
}
