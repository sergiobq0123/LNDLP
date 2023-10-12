import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-artist-detail-songs',
  templateUrl: './artist-detail-songs.component.html',
  styleUrls: ['./artist-detail-songs.component.scss']
})
export class ArtistDetailSongsComponent {
@Input() songs : Array<any>
}
