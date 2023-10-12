import { Component } from '@angular/core';
import { CompanyService } from 'src/app/services/intranet/company.service';

@Component({
  selector: 'app-agency-section-partners',
  templateUrl: './agency-section-partners.component.html',
  styleUrls: ['./agency-section-partners.component.scss']
})
export class AgencySectionPartnersComponent {
  collabs: Array<any> = new Array<any>();
  buttonTitle : "Ver más"

  constructor(
    private _companyService : CompanyService,
  ){}
  ngOnInit(){
    this.getPartner()

  }

  getPartner() {
    this._companyService.getPartner().subscribe((res) => {
      this.collabs = res;
    });
  }
}
