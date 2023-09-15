import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-artist-crew',
  templateUrl: './artist-crew.component.html',
  styleUrls: ['./artist-crew.component.scss']
})
export class ArtistCrewComponent {
  dataForm : any
  constructor(@Inject(MAT_DIALOG_DATA) public data: any) { }

  ngOnInit() {
    if (this.data && this.data.crewData) {
      this.dataForm = this.data.crewData;
      console.log(this.dataForm);
    }
    console.log(this.getProperties(this.dataForm));
    console.log(this.dataForm['artistId']);

  }

  getProperties(obj: any): string[] {
    if (obj === undefined || obj === null) {
      return [];
    }
    return Object.keys(obj);
  }
}
