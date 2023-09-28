import { Component, Input } from '@angular/core';
import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';

@Component({
  selector: 'app-artist-videos-web',
  templateUrl: './artist-videos-web.component.html',
  styleUrls: ['./artist-videos-web.component.scss']
})
export class ArtistVideosWebComponent {
  @Input() array : Array<any>;
  @Input() width : number= 450;
  @Input() widthSmall : Array<any>;


  constructor(private sanitizer: DomSanitizer) {}

  getSafeUrl(url: string): SafeResourceUrl {
    return this.sanitizer.bypassSecurityTrustResourceUrl(url);
  }
}
