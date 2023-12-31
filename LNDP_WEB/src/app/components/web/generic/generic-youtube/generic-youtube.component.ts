import { Component, Input } from '@angular/core';
import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';

@Component({
  selector: 'app-generic-youtube',
  templateUrl: './generic-youtube.component.html',
  styleUrls: ['./generic-youtube.component.scss']
})
export class GenericYoutubeComponent {
  @Input() array : Array<any>;

  constructor(private sanitizer: DomSanitizer) {}

  getSafeUrl(url: string): SafeResourceUrl {
    return this.sanitizer.bypassSecurityTrustResourceUrl(url);
  }
}
