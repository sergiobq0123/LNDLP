import { Component } from '@angular/core';
import { CompanyService } from 'src/app/services/intranet/company.service';

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
    private _companyService : CompanyService
  ){}
  ngOnInit(){
    this.getRecords()
  }

  getRecords() {
    this._companyService.getRecords().subscribe((res) => {
      this.records = res;
    });
  }
}
