import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-artist-detail-table-web',
  templateUrl: './artist-detail-table-web.component.html',
  styleUrls: ['./artist-detail-table-web.component.scss'],
})
export class ArtistDetailTableWebComponent {
  @Input() array: Array<any>;
}
