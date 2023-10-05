import { Component } from '@angular/core';
import { BrandService } from 'src/app/services/intranet/brand.service';

@Component({
  selector: 'app-agency-web',
  templateUrl: './agency-web.component.html',
  styleUrls: ['./agency-web.component.scss']
})
export class AgencyWebComponent {
  title = "AGENCY"
  description = "Conectamos con tu público objetivo y hacemos crecer tu proyecto mejorando el posicionamiento. Aportamos visibilidad, presencia y calidad a tu proyecto para hacerlo más profesional. Nos introducimos en las redes sociales para que tu proyecto maximice su visibilidad. Trabajamos con diferentes marcas que puedan encajar con tu proyecto"
  brands: Array<any> = new Array<any>();
  buttonTitle : string = "Ver web"

  constructor(
    private _brandService : BrandService
  ){}
  ngOnInit(){
    this.getRecords()
  }

  getRecords() {
    this._brandService.get().subscribe((res) => {
      let brand = new Array();
      res.forEach((val) => {
        brand.push(val);
      });
      this.brands = [...brand];
    });
  }
}
