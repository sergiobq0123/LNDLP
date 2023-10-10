import { Component } from '@angular/core';
import { RecordService } from 'src/app/services/intranet/record.service';

@Component({
  selector: 'app-marketing-web',
  templateUrl: './marketing-web.component.html',
  styleUrls: ['./marketing-web.component.scss']
})
export class MarketingWebComponent {
  title = "PR&MKTNG"
  description = "Planificación y estrategia de planes de comunicación personalizados. Realizamos notas de prensa, entrevistas, reacciones, podcast... Contamos con estrategias de marketing adaptadas al mundo urbano para conectar con tu público. Tenemos asesoría y endorsement. "
  records: Array<any> = new Array<any>();
  buttonTitle : string = "Ver web"

  constructor(
    private _recordService : RecordService
  ){}
  ngOnInit(){
    this.getRecords()
  }

  getRecords() {
    this._recordService.getCards().subscribe((res) => {
      let records = new Array();
      res.forEach((val) => {
        records.push(val);
      });
      this.records = [...records];
    });
  }
}
