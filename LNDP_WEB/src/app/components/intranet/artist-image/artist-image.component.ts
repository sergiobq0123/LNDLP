import { Component, ElementRef, ViewChild } from '@angular/core';
import { ArtistService } from 'src/app/services/intranet/artist.service';
import { NotificationService } from '../../../services/notification.service';

@Component({
  selector: 'app-artist-image',
  templateUrl: './artist-image.component.html',
  styleUrls: ['./artist-image.component.scss'],
})
export class ArtistImageComponent {
  artists: Array<any> = new Array<any>();
  image: any;
  @ViewChild('fileInput', { static: false }) fileInput: ElementRef;
  @ViewChild('fileInputEdit', { static: false }) fileInputEdit: ElementRef;

  constructor(
    private artistService: ArtistService,
    private notificationService: NotificationService
  ) {}
  ngOnInit() {
    this.getArtist();
  }

  getArtist() {
    this.artistService.get().subscribe((res) => {
      console.log(res);

      let artists = new Array();
      res.forEach((val) => {
        artists.push(val);
      });
      this.artists = [...artists];
    });
  }

  onImageUpload(event: any, artist: any) {
    this.image =
      event.target.files === undefined ? null : event.target.files[0];

    this.artistService
      .postImageArtist(this.image, artist.id)
      .subscribe((res) => {
        this.notificationService.showMessageOnSnackbar(
          res.message,
          'OK!',
          3500,
          'success-button'
        );
        this.getArtist();
        const fileInput: HTMLInputElement | null = document.getElementById(
          'fileInput'
        ) as HTMLInputElement;
        if (fileInput) {
          fileInput.value = '';
        }
      });
      (err) => {
        this.notificationService.showMessageOnSnackbar(
          err.error.message,
          'ERROR!',
          3500,
          'err-button'
        );
      }
  }
}
