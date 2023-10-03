import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'LNDP_WEB';

  ngOnInit(){
    document.addEventListener("DOMContentLoaded", () => {
      // Obtén todos los elementos iframe en la página
      const iframes = document.querySelectorAll("iframe");

      // Recorre todos los iframes y agrega el atributo loading="lazy"
      iframes.forEach((iframe) => {
        iframe.setAttribute("loading", "lazy");
      });
    });
  }
}

