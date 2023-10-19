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

  ngOnInit(): void {
    this.VOForm = this.fb.group({});
    this.data.artistas.forEach(artist => {
      let isAssociated = this.data.festival.artistFestivalAsoc.some(
        artistFestival => artistFestival.artistId === artist.id
      );
      let initialValue = isAssociated;
      this.VOForm.addControl(artist.name, new FormControl(initialValue));
    });
  }

  save() {
    let nuevosArtistas = [];
    let artistasEliminados = [];

    Object.keys(this.VOForm.controls).forEach(key => {
      let control = this.VOForm.get(key);
      const artist = this.data.artistas.find(x => x.name == key);

      if (control.value) {
        nuevosArtistas.push(artist);
      } else {
        artistasEliminados.push(artist);
      }
    });

    this.dialogRef.close({ nuevosArtistas, artistasEliminados });
  }
}
