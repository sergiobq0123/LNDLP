import { Component, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ArtistService } from '../../services/intranet/artist.service';

@Component({
  selector: 'app-artist-detail-web',
  templateUrl: './artist-detail-web.component.html',
  styleUrls: ['./artist-detail-web.component.scss']
})
export class ArtistDetailWebComponent {

  artist: any;

  constructor(private route: ActivatedRoute, private router: Router, private artistService : ArtistService) {}

  ngOnInit() {
    this.route.params.subscribe(params => {
      const artistId = params['id'];
      this.artistService.get(artistId).subscribe(res => {
        this.artist = res
      })
    });
  }
}
