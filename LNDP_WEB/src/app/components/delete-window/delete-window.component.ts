import { Component } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-delete-window',
  templateUrl: './delete-window.component.html',
  styleUrls: ['./delete-window.component.scss']
})
export class DeleteWindowComponent {
  @Output() confirmDelete: EventEmitter<boolean> = new EventEmitter<boolean>();

  constructor(
    public dialogRef: MatDialogRef<DeleteWindowComponent>
  ) { }

  onNoClick(): void {
    this.dialogRef.close();
  }

  onYesClick(): void {
    this.dialogRef.close(true);
    this.confirmDelete.emit(true);
  }
}
