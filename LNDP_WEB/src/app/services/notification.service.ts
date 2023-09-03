import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {

  constructor(
    private _snackBar: MatSnackBar
  ) { }

  showError(error: any, actionText : string, duration: number){
    this._snackBar.open(error.description, actionText, {duration : duration})
  }

  showMessage(message: string, actionText : string, duration: number, panelClass?: string){
    this._snackBar.open(message , actionText, {duration : duration, panelClass : panelClass})
  }
}
