import { Component } from '@angular/core';
import { ArtistService } from 'src/app/services/intranet/artist.service';

@Component({
  selector: 'app-artist-image',
  templateUrl: './artist-image.component.html',
  styleUrls: ['./artist-image.component.scss']
})
export class ArtistImageComponent {
  artists: Array<any> = new Array<any>();
  /**
   *
   */
  constructor(private artistService: ArtistService,) {
  }
  ngOnInit(){
    this.getArtist()
  }

  getArtist() {
    this.artistService.get().subscribe((res) => {
      console.log(res);

      let artists = new Array();
      res.forEach(val => {
        artists.push(val)
      });
      this.artists = [... artists];
    });
  }


  onImageUpload(event: any, artist : any){
      const file = event.target.files[0];
      console.log(file);

      if(file){
        this.artistService.postImageArtist(file, artist.id).subscribe(res => {
          console.log(res);
        })
      }
  }
}
