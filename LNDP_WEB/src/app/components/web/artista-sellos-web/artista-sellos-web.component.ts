import { Component, EventEmitter, Output } from '@angular/core';
import { ArtistService } from '../../../services/intranet/artist.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-artista-sellos-web',
  templateUrl: './artista-sellos-web.component.html',
  styleUrls: ['./artista-sellos-web.component.scss']
})
export class ArtistaSellosWebComponent {
  title = "Artistas"
  artists: Array<any> = new Array<any>();

  constructor(private artistService : ArtistService, private router : Router) {}

  ngOnInit(){
    this.getArtist();
  }

  getArtist() {
    this.artistService.get().subscribe((res) => {
      let artists = new Array();
      res.forEach((val) => {
        artists.push(val);
      });
      this.artists = [...artists];
    });
  }

  openArtistDetail(artist: any) {
    this.router.navigate(['/Artist', artist.id]);
  }
}
