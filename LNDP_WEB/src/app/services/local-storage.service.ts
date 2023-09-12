import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LocalStorageService {


  constructor() { }

  addItemToLocalStorage(key: string, value: string): void {
    localStorage.setItem(key, value)
  }

  getItemFromLocalStorage(key: string): any {
    try {
      return localStorage.getItem(key)
    } catch(error){
      console.log("Error getting user id from local storage", error);

    }
  }

  clearStorage(): void {
    try{
      localStorage.clear()
    }catch (error){
      console.log("Error clearing local storage", error);

    }
  }
}
