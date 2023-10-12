import { Component, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ArtistService } from 'src/app/services/intranet/artist.service';

@Component({
  selector: 'app-artist-detail-section-web',
  templateUrl: './artist-detail-section-web.component.html',
  styleUrls: ['./artist-detail-section-web.component.scss']
})
export class ArtistDetailSectionWebComponent {
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
