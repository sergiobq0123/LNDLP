import { Component } from '@angular/core';
import { CompanyService } from 'src/app/services/intranet/company.service';

@Component({
  selector: 'app-agency-section-marcas',
  templateUrl: './agency-section-marcas.component.html',
  styleUrls: ['./agency-section-marcas.component.scss']
})
export class AgencySectionMarcasComponent {
  brands: Array<any> = new Array<any>();
  genericCard: Array<any> = new Array<any>();
  buttonTitle : string = "Ver web"

  constructor(
    private _companyService : CompanyService,
  ){}

  ngOnInit(){
    this.getBrands()
  }

  getBrands() {
    this._companyService.getBrands().subscribe((res) => {
      this.brands = res;
      this.setGenericCard();
    });
  }

  setGenericCard(){
    this.genericCard = this.brands.map(item => ({
        imagen: item.photoUrl,
        titulo : item.name,
        descripcion : item.description,
        url : item.webUrl
    }));
  }
}
