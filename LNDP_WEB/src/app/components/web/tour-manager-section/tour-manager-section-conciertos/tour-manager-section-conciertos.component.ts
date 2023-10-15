import { Component } from '@angular/core';
import { ConcertService } from 'src/app/services/intranet/concert.service';

@Component({
  selector: 'app-tour-manager-section-conciertos',
  templateUrl: './tour-manager-section-conciertos.component.html',
  styleUrls: ['./tour-manager-section-conciertos.component.scss']
})
export class TourManagerSectionConciertosComponent {
  concerts: Array<any> = new Array<any>();
  genericCard: Array<any> = new Array<any>();
  buttonTitle: string = "Entradas"

  constructor(
    private _concertService :  ConcertService,
  ){}

  ngOnInit(){
    this._concertService.getProximosConciertos().subscribe(res => {
      this.concerts = res;
      this.setGenericCard()
    })
  }
  setGenericCard(){
    this.genericCard = this.concerts.map(concert => ({
        imagen: concert.photoUrl,
        titulo : concert.name,
        descripcion : `${concert.city}, ${concert.date}`,
        url : concert.tickets
    }));
  }
}
