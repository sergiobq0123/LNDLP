import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ArtistService } from 'src/app/services/intranet/artist.service';

@Component({
  selector: 'app-marketing-artist-web',
  templateUrl: './marketing-artist-web.component.html',
  styleUrls: ['./marketing-artist-web.component.scss'],
})
export class MarketingArtistWebComponent {
  title = 'Artistas';
  artists: Array<any> = new Array<any>();

  constructor(private artistService: ArtistService, private router: Router) {}

  ngOnInit() {
    this.getArtist();
  }

  getArtist() {
    this.artistService.getArtists().subscribe((res) => {
      this.artists = [...res];
    });
  }

  openArtistDetail(artist: any) {
    this.router.navigate(['/Artist', artist.id]);
  }
}
