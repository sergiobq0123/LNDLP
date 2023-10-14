import { Component, ElementRef, Input, ViewChild } from '@angular/core';

@Component({
  selector: 'app-viusal-section-carrousel',
  templateUrl: './viusal-section-carrousel.component.html',
  styleUrls: ['./viusal-section-carrousel.component.scss']
})
export class ViusalSectionCarrouselComponent {
  @Input() nombreCarrousel : string;
  @Input() carrouselImages : Array<any>;
  @ViewChild('carouselContainer') carouselContainer: ElementRef;
  screenWidth: number;
  averageImageWidth: number;
  currentIndex: number = 0;


  scrollImages(offset: number) {
    this.currentIndex += offset;

    if (this.currentIndex < 0) {
      this.currentIndex = 0;
    } else {
      // Obtener el ancho del contenedor
      const containerWidth = this.carouselContainer.nativeElement.offsetWidth;
      if (containerWidth <= 1300) {
        this.averageImageWidth = 220;
      } else {
        this.averageImageWidth = 430;
      }
      const imagesPerContainer = Math.floor(containerWidth / this.averageImageWidth);

      if (this.currentIndex >= this.carrouselImages.length - imagesPerContainer) {
        this.currentIndex = this.carrouselImages.length - imagesPerContainer;
      }
    }
    if (this.carouselContainer) {
      const container = this.carouselContainer.nativeElement as HTMLElement;
      container.style.transform = `translateX(${-this.currentIndex * this.averageImageWidth}px)`;
    }
  }
}
