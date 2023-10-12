import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-artist-detail-table',
  templateUrl: './artist-detail-table.component.html',
  styleUrls: ['./artist-detail-table.component.scss']
})
export class ArtistDetailTableComponent {
  @Input() array: Array<any>;
}
