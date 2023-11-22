import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  title = 'LNDP_WEB';

  ngOnInit() {
    document.addEventListener('DOMContentLoaded', () => {
      const iframes = document.querySelectorAll('iframe');

      iframes.forEach((iframe) => {
        iframe.setAttribute('loading', 'lazy');
      });
    });
  }
}
