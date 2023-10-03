import { Component } from '@angular/core';
import { BrandService } from 'src/app/services/intranet/brand.service';

@Component({
  selector: 'app-agency-web',
  templateUrl: './agency-web.component.html',
  styleUrls: ['./agency-web.component.scss']
})
export class AgencyWebComponent {
  title = "AGENCY"
  description = "Aliqua non nulla ad non consequat deserunt dolore Lorem consequat ipsum aliqua. Nostrud irure dolore do ut in officia veniam incididunt culpa irure commodo consectetur tempor. Nisi ex consectetur deserunt culpa magna est nostrud ut do nisi anim duis exercitation. Nulla dolor qui ullamco reprehenderit dolor minim ut ad do aute esse in laboris commodo. Tempor adipisicing laboris sunt dolore excepteur amet culpa veniam ex fugiat dolore irure. Eu eu ad adipisicing et sunt. Cupidatat nulla est veniam sunt amet duis."
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
