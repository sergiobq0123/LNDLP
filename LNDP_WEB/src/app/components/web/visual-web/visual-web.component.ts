import { Component } from '@angular/core';


@Component({
  selector: 'app-visual-web',
  templateUrl: './visual-web.component.html',
  styleUrls: ['./visual-web.component.scss'],
})
export class VisualWebComponent {
  title = "Visual"
  description = "Contamos con más de 5 años en el sector y más de 200 videoclips a nuestras espaldas. Nos encargamos de la preproducción, rodaje, montaje y etalonaje.Nos encargamos de cubrir los eventos y actuaciones con fotografía y vídeo, a gusto del cliente. Con mucha experiencia en el sector hemos cubierto eventos de empresas importantes de la industria."

  carrouselName1 = "Boombastic 2023"
  carrouselImages1: Array<any> = [
    {
      url: './../../../../assets/Visual/robledo.jpg',
    },
    {
      url: './../../../../assets/Visual/robledo.jpg',
    },
    {
      url: './../../../../assets/Visual/robledo.jpg',
    },
    {
      url: './../../../../assets/Visual/robledo.jpg',
    },
    {
      url: './../../../../assets/Visual/robledo.jpg',
    },
    {
      url: './../../../../assets/Visual/robledo.jpg',
    },
    {
      url: './../../../../assets/Visual/robledo.jpg',
    },
    {
      url: './../../../../assets/Visual/robledo.jpg',
    },
    {
      url: './../../../../assets/Visual/robledo.jpg',
    },
  ];

  carrouselName2 = "Madrid Salvaje 2022"
  carrouselImages2 : Array<any> = [
    {
      url : './../../../../assets/Visual/dudi.jpg'
    },
    {
      url : './../../../../assets/Visual/dudi.jpg'
    },
    {
      url : './../../../../assets/Visual/dudi.jpg'
    },
    {
      url : './../../../../assets/Visual/dudi.jpg'
    },
    {
      url : './../../../../assets/Visual/dudi.jpg'
    },
    {
      url : './../../../../assets/Visual/dudi.jpg'
    },
    {
      url : './../../../../assets/Visual/dudi.jpg'
    },
    {
      url : './../../../../assets/Visual/dudi.jpg'
    },
    {
      url : './../../../../assets/Visual/dudi.jpg'
    },
  ]

  carrouselName3 = "Riverland 2025"
  carrouselImages3 : Array<any> = [
    {
      url : './../../../../assets/Visual/igle.jpg'
    },
    {
      url : './../../../../assets/Visual/igle.jpg'
    },
    {
      url : './../../../../assets/Visual/igle.jpg'
    },
    {
      url : './../../../../assets/Visual/igle.jpg'
    },
    {
      url : './../../../../assets/Visual/igle.jpg'
    },
    {
      url : './../../../../assets/Visual/igle.jpg'
    },
    {
      url : './../../../../assets/Visual/igle.jpg'
    },
    {
      url : './../../../../assets/Visual/igle.jpg'
    },
    {
      url : './../../../../assets/Visual/igle.jpg'
    },
  ]

  youtubeVideo : Array<any> = [
    {url : 'https://www.youtube.com/embed/AUdz46rXKCM'},
    {url : 'https://www.youtube.com/embed/AUdz46rXKCM'},
    {url : 'https://www.youtube.com/embed/AUdz46rXKCM'},
    {url : 'https://www.youtube.com/embed/AUdz46rXKCM'},
    {url : 'https://www.youtube.com/embed/AUdz46rXKCM'},
    {url : 'https://www.youtube.com/embed/AUdz46rXKCM'},
  ]
}
