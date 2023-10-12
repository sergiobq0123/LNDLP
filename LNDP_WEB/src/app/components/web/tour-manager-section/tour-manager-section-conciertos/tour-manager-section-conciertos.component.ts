import { Component } from '@angular/core';
import { ConcertService } from 'src/app/services/intranet/concert.service';

@Component({
  selector: 'app-tour-manager-section-conciertos',
  templateUrl: './tour-manager-section-conciertos.component.html',
  styleUrls: ['./tour-manager-section-conciertos.component.scss']
})
export class TourManagerSectionConciertosComponent {
  concerts: Array<any> = new Array<any>();
  buttonTitle= "Entradas"

  constructor(
    private _concertService :  ConcertService,
  ){}

  ngOnInit(){
    this._concertService.get().subscribe(res => {
      this.concerts = res;
    })
  }
}
