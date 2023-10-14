import { Component, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ArtistService } from 'src/app/services/intranet/artist.service';

@Component({
  selector: 'app-artist-detail-section',
  templateUrl: './artist-detail-section.component.html',
  styleUrls: ['./artist-detail-section.component.scss']
})
export class ArtistDetailSectionComponent {
  @Input() artistDetail : any ;
  artist: any;

  constructor(private route: ActivatedRoute, private artistService : ArtistService) {}

  ngOnInit() {
    this.route.params.subscribe(params => {
      const artistId = params['id'];
      this.artistService.get(artistId).subscribe(res => {
        this.artist = res
      })
    });
  }
}
