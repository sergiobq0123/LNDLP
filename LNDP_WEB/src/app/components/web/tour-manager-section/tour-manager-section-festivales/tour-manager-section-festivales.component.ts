import { Component } from '@angular/core';
import { FestivalService } from 'src/app/services/intranet/festival.service';

@Component({
  selector: 'app-tour-manager-section-festivales',
  templateUrl: './tour-manager-section-festivales.component.html',
  styleUrls: ['./tour-manager-section-festivales.component.scss']
})
export class TourManagerSectionFestivalesComponent {
  festivales: Array<any> = new Array<any>();
  genericCard: Array<any> = new Array<any>();
  buttonTitle: string = "Entradas"

  constructor(
    private _festivalService :  FestivalService,
  ){}

  ngOnInit(){
    this._festivalService.getProximosFestivales().subscribe(res => {
      this.festivales = res;
      this.setGenericCard()
    })
  }
  setGenericCard(){
    this.genericCard = this.festivales.map(festival => ({
        imagen: festival.photoUrl,
        titulo : festival.name,
        descripcion : `${festival.city}, ${festival.date}`,
        url : festival.tickets
    }));
  }
}
