import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-artist-detail-albums',
  templateUrl: './artist-detail-albums.component.html',
  styleUrls: ['./artist-detail-albums.component.scss']
})
export class ArtistDetailAlbumsComponent {
  @Input() albums : Array<any>
  genericCard: Array<any> = new Array<any>();
  buttonText: string = "Escuchar"

  ngOnInit(){
    this.setGenericCard();
  }

  setGenericCard(){
    this.genericCard = this.albums.map(concert => ({
        imagen: concert.photoUrl,
        titulo : concert.name,
        descripcion : concert.date,
        url : concert.webUrl
    }));
  }
}
