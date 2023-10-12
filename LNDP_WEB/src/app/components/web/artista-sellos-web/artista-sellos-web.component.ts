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
      this.artists = [...res];
    });
  }

  openArtistDetail(artist: any) {
    console.log("si");

    this.router.navigate(['/Artist', artist.id]);
  }
}
