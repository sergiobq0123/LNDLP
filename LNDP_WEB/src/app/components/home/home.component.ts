import { Component, ElementRef, HostListener, ViewChild } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {

  @ViewChild('scrollObserver') scrollObserver!: ElementRef;
  observer!: IntersectionObserver;
  showMajor: boolean = true;
  showSecond: boolean = false;

  constructor() {}

  AfterViewInit (): void {
    this.observer = new IntersectionObserver(
      (entries) => {
        entries.forEach((entry) => {
          if (entry.isIntersecting) {
            // El elemento scrollObserver está completamente en el viewport
            this.showMajor = !this.showMajor;
            this.showSecond = !this.showSecond;
          }
        });
      },
      { threshold: 0.1 } // Cuando al menos el 50% del elemento está en el viewport
    );

    this.observer.observe(this.scrollObserver.nativeElement);
  }
}
