import { Component } from '@angular/core';
import { CompanyService } from 'src/app/services/intranet/company.service';

@Component({
  selector: 'app-agency-section-projectos',
  templateUrl: './agency-section-projectos.component.html',
  styleUrls: ['./agency-section-projectos.component.scss'],
})
export class AgencySectionProjectosComponent {
  projects: Array<any> = new Array<any>();
  buttonTitle: string = 'Ver más';
  genericCard: Array<any> = new Array<any>();

  constructor(private _companyService: CompanyService) {}

  ngOnInit() {
    this.getProjects();
  }

  getProjects() {
    this._companyService.getProjects().subscribe((res) => {
      this.projects = res;
      this.setGenericCard();
    });
  }

  setGenericCard() {
    this.genericCard = this.projects.map((project) => ({
      imagen: project.photoUrl,
      titulo: project.name,
      descripcion: project.description,
      url: project.webUrl,
    }));
  }
}
