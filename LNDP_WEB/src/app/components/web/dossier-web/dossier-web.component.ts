import { Component } from '@angular/core';
import { DossierService } from 'src/app/services/intranet/dossier.service';

@Component({
  selector: 'app-dossier-web',
  templateUrl: './dossier-web.component.html',
  styleUrls: ['./dossier-web.component.scss']
})
export class DossierWebComponent {
  images: Array<any> = new Array<any>();
  currentIndex = 0;

  constructor(private _dossierService : DossierService) {
  }

  ngOnInit(){
    this.getDossier();
  }

  getDossier(){
    this._dossierService.get().subscribe((res) => {
      console.log(res);
      let dossier = new Array();
      res.forEach((val) => {
        dossier.push(val);
      });
      this.images = [...dossier];
    });
  }

  prevImage() {
    if (this.currentIndex > 0) {
      this.currentIndex--;
    }
  }

  nextImage() {
    this.currentIndex = (this.currentIndex + 1) % this.images.length;
  }

  goToImage(index: number) {
    this.currentIndex = index;
  }
}
