import { Component } from '@angular/core';
import { CompanyService } from 'src/app/services/intranet/company.service';

@Component({
  selector: 'app-agency-section-partners',
  templateUrl: './agency-section-partners.component.html',
  styleUrls: ['./agency-section-partners.component.scss']
})
export class AgencySectionPartnersComponent {
  partners: Array<any> = new Array<any>();
  buttonTitle : string = "Ver más"
  genericCard: Array<any> = new Array<any>();

  constructor(
    private _companyService : CompanyService,
  ){}
  ngOnInit(){
    this.getPartner()

  }

  getPartner() {
    this._companyService.getPartner().subscribe((res) => {
      this.partners = res;
      this.setGenericCard();
    });
  }

  setGenericCard(){
    this.genericCard = this.partners.map(partner => ({
        imagen: partner.photoUrl,
        titulo : partner.name,
        descripcion : partner.description,
        url : partner.webUrl
    }));
  }
}
