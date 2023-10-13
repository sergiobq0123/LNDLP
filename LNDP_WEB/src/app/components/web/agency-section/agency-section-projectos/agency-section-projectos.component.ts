import { Component } from '@angular/core';
import { CompanyService } from 'src/app/services/intranet/company.service';

@Component({
  selector: 'app-agency-section-projectos',
  templateUrl: './agency-section-projectos.component.html',
  styleUrls: ['./agency-section-projectos.component.scss']
})
export class AgencySectionProjectosComponent {
  projects: Array<any> = new Array<any>();
  buttonTitle : string = "Ver más"

  constructor(
    private _companyService : CompanyService,
  ){}
  ngOnInit(){
    this.getPartner()

  }

  getPartner() {
    this._companyService.getProjects().subscribe((res) => {
      this.projects = res;
    });
  }
}
