import { Component } from '@angular/core';
import { EventService } from '../../../services/intranet/event.service';
import { ConcertService } from 'src/app/services/intranet/concert.service';

@Component({
  selector: 'app-tour-manager-web',
  templateUrl: './tour-manager-web.component.html',
  styleUrls: ['./tour-manager-web.component.scss']
})
export class TourManagerWebComponent {
  title = "Tour Manager"
  description = "Aliqua non nulla ad non consequat deserunt dolore Lorem consequat ipsum aliqua. Nostrud irure dolore do ut in officia veniam incididunt culpa irure commodo consectetur tempor. Nisi ex consectetur deserunt culpa magna est nostrud ut do nisi anim duis exercitation. Nulla dolor qui ullamco reprehenderit dolor minim ut ad do aute esse in laboris commodo. Tempor adipisicing laboris sunt dolore excepteur amet culpa veniam ex fugiat dolore irure. Eu eu ad adipisicing et sunt. Cupidatat nulla est veniam sunt amet duis."
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
