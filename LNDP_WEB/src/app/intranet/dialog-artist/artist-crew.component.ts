import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-artist-crew',
  templateUrl: './artist-crew.component.html',
  styleUrls: ['./artist-crew.component.scss']
})
export class ArtistCrewComponent {
  dataForm : any
  dataName : any
  constructor(@Inject(MAT_DIALOG_DATA) public data: any) { }

  ngOnInit() {
      this.dataForm = this.data.dataShow;
      this.dataName = this.data.artistaName;
  }

  getProperties(obj: any): string[] {
    if (obj === undefined || obj === null) {
      return [];
    }
    return Object.keys(obj);
  }
}
