import { Component } from '@angular/core';
import { CompanyService } from 'src/app/services/intranet/company.service';

@Component({
  selector: 'app-marketing-sellos',
  templateUrl: './marketing-sellos.component.html',
  styleUrls: ['./marketing-sellos.component.scss']
})
export class MarketingSellosComponent {
  records: Array<any> = new Array<any>();
  buttonTitle : string = "Ver más"
  genericCard: Array<any> = new Array<any>();

  constructor(
    private _companyService : CompanyService
  ){}
  ngOnInit(){
    this.getRecords()
  }

  getRecords() {
    this._companyService.getRecords().subscribe((res) => {
      this.records = res;
      this.setGenericCard();
    });
  }

  setGenericCard(){
    this.genericCard = this.records.map(record => ({
        imagen: record.photoUrl,
        titulo : record.name,
        descripcion : record.description,
        url : record.webUrl
    }));
  }
}
