import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup, FormControl } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { FestivalArtistDialogData } from './festival-artist-data';
import { Artist } from 'src/app/models/artist.model';

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

  originalArtistasAsociados: Artist[];

  ngOnInit(): void {
    this.VOForm = this.fb.group({});
    this.originalArtistasAsociados = [].concat(...this.data.festival.artistFestivalAsoc.map(af => af.artist));
    this.data.artistas.forEach(artist => {
      let isAssociated = this.originalArtistasAsociados.some(a => a.id === artist.id);
      let initialValue = isAssociated;
      this.VOForm.addControl(artist.name, new FormControl(initialValue));
    });
  }

  save() {
    let nuevosArtistas = this.data.artistas.filter(artist => {
      const control = this.VOForm.get(artist.name);
      return control.value && !this.originalArtistasAsociados.some(a => a.id === artist.id);
    });

    let artistasEliminados = this.originalArtistasAsociados.filter(artist => {
      const control = this.VOForm.get(artist.name);
      return !control.value && this.data.festival.artistFestivalAsoc.some(af => af.artistId === artist.id);
    });

    this.dialogRef.close({ nuevosArtistas, artistasEliminados });
  }
}
