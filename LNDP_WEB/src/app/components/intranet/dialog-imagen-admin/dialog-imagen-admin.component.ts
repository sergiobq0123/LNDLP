import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-dialog-imagen-admin',
  templateUrl: './dialog-imagen-admin.component.html',
  styleUrls: ['./dialog-imagen-admin.component.scss']
})
export class DialogImagenAdminComponent {
  constructor(
    public dialogRef: MatDialogRef<DialogImagenAdminComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) { }

  ngOnInit(){
    console.log(this.data.imagenURL);
  }

  cerrarModal(): void {
    this.dialogRef.close();
  }
}
