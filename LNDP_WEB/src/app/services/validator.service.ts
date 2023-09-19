import { Injectable } from '@angular/core';

const messages = {
  email : "La direccion de email es incorrecta",
  required : "Campo obigatorio"
}


@Injectable({
  providedIn: 'root'
})
export class ValidatorService {

  constructor() { }

  getErrorMessage(errors: any){
    if(!errors){
      return ""
    }
    for (let key in messages){
      if(errors[key]){
        let message = messages[key];
        return message
      }
    }

  }
}
