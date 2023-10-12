import { Component } from '@angular/core';
import { CompanyService } from 'src/app/services/intranet/company.service';

@Component({
  selector: 'app-agency-section-web',
  templateUrl: './agency-section-web.component.html',
  styleUrls: ['./agency-section-web.component.scss']
})


export class AgencySectionWebComponent {
  title = "AGENCY"
  description = "Conectamos con tu público objetivo y hacemos crecer tu proyecto mejorando el posicionamiento. Aportamos visibilidad, presencia y calidad a tu proyecto para hacerlo más profesional. Nos introducimos en las redes sociales para que tu proyecto maximice su visibilidad. Trabajamos con diferentes marcas que puedan encajar con tu proyecto"
  brands: Array<any> = new Array<any>();
  collabs: Array<any> = new Array<any>();
  buttonTitle : string = "Ver web"

  constructor(
    private _companyService : CompanyService,
  ){}
  ngOnInit(){
    this.getBrands()
    this.getPartner()

  }

  getBrands() {
    this._companyService.getBrands().subscribe((res) => {
      this.brands = res;
    });
  }

  getPartner() {
    this._companyService.getPartner().subscribe((res) => {
      this.collabs = res;
    });
  }
}
