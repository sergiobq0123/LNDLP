import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {

  constructor(
    private _snackBar: MatSnackBar
  ) { }

  showErrorOnSnackbar(error: any, actionText : string, duration: number){
    this._snackBar.open(error, actionText, {duration : duration})
  }

  showMessageOnSnackbar(message: string, actionText : string, duration: number, panelClass?: string){
    this._snackBar.open(message , actionText, {duration : duration, panelClass : panelClass})
  }

  showOkMessage(message: string){
    this.showMessageOnSnackbar(message, 'OK' , 3500 , 'succes-button');
  }

  showErrorMessage(message: string){
    this.showMessageOnSnackbar(message, 'ERROR' , 3500 , 'error-button');
  }
}
