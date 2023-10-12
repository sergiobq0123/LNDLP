import { Component } from '@angular/core';

@Component({
  selector: 'app-visual-section-videos',
  templateUrl: './visual-section-videos.component.html',
  styleUrls: ['./visual-section-videos.component.scss']
})
export class VisualSectionVideosComponent {
  youtubeVideo : Array<any> = [
    {url : 'https://www.youtube.com/embed/AUdz46rXKCM'},
    {url : 'https://www.youtube.com/embed/AUdz46rXKCM'},
    {url : 'https://www.youtube.com/embed/AUdz46rXKCM'},
    {url : 'https://www.youtube.com/embed/AUdz46rXKCM'},
    {url : 'https://www.youtube.com/embed/AUdz46rXKCM'},
    {url : 'https://www.youtube.com/embed/AUdz46rXKCM'},
  ]
}
