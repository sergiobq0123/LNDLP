import { Component } from '@angular/core';
import { YoutubeVideoService } from 'src/app/services/intranet/youtube-video.service';

@Component({
  selector: 'app-visual-section-videos',
  templateUrl: './visual-section-videos.component.html',
  styleUrls: ['./visual-section-videos.component.scss']
})
export class VisualSectionVideosComponent {
  youtubeVideo: Array<any> = new Array<any>();

  constructor(
    private _youtubeService : YoutubeVideoService
  ) {
  }

  ngOnInit(){
    this._youtubeService.getWeb().subscribe(res => {
      this.youtubeVideo = res;
    })
  }
}
