import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup, FormControl } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { FestivalArtistDialogData } from './festival-artist-data';

@Component({
  selector: 'app-festival-artist-dialog',
  templateUrl: './festival-artist-dialog.component.html',
  styleUrls: ['./festival-artist-dialog.component.scss']
})
export class FestivalArtistDialogComponent {
  constructor(
    public dialogRef: MatDialogRef<FestivalArtistDialogComponent>,
    private fb: FormBuilder,
    @Inject(MAT_DIALOG_DATA) public data: FestivalArtistDialogData,
  ) {}

  VOForm: FormGroup;
  controls = {};

  ngOnInit(): void {
    this.VOForm = this.fb.group({});
    this.data.artistas.forEach(artist => {
      const isAssociated = this.data.artistasAsociados
        ? this.data.artistasAsociados.find(associatedArtist => associatedArtist.name === artist.name)
        : null;
      const initialValue = isAssociated ? true : false;
      this.VOForm.addControl(artist.name, new FormControl(initialValue));
    });
  }

  save() {
    let nuevosArtistas = [];
    let artistasEliminados = [];

    Object.keys(this.VOForm.controls).forEach(key => {
      let control = this.VOForm.get(key);
      const artist = this.data.artistas.find(x => x.name == key);
      const isAssociated = this.data.artistasAsociados
        ? this.data.artistasAsociados.find(artist => artist.name === key)
        : null;

      if (control.value) {
        if (!isAssociated) {
          nuevosArtistas.push(artist);
        }
      } else {
        if (isAssociated) {
          artistasEliminados.push(artist);
        }
      }
    });
    this.dialogRef.close({ nuevosArtistas, artistasEliminados });
  }
}
