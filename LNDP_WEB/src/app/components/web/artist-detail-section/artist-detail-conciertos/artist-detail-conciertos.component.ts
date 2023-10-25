import { Component, Input } from '@angular/core';
import { DateFormat } from 'src/app/Utils/DateFormat';

@Component({
  selector: 'app-artist-detail-conciertos',
  templateUrl: './artist-detail-conciertos.component.html',
  styleUrls: ['./artist-detail-conciertos.component.scss'],
})
export class ArtistDetailConciertosComponent {
  @Input() conciertos: Array<any>;
  @Input() conciertosShow: Array<any>;

  ngOnInit() {
    this.setConcert();
  }

  setConcert() {
    this.conciertosShow = this.conciertos.map((concierto) => ({
      name: concierto.name,
      date: DateFormat.format(concierto.date),
      city: concierto.city,
    }));
  }
}
