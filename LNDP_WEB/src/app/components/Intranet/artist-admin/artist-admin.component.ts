import { Component } from '@angular/core';
import { Sort } from '@angular/material/sort';
import { MatDialog } from '@angular/material/dialog';
import { NotificationService } from 'src/app/services/notification.service';
import { ContentType } from '../../generic-form-dialog/generic-content';
import { Column } from '../../generic-table/column';
import { ArtistService } from 'src/app/services/intranet/artist.service';


@Component({
  selector: 'app-artist-admin',
  templateUrl: './artist-admin.component.html',
  styleUrls: ['./artist-admin.component.scss']
})
export class ArtistAdminComponent {
  artists: Array<any> = new Array<any>();
  artistColumns: Column[];
  pageNumber: number = 1;
  loaded: boolean = false;
  newRowAdded: boolean = false;
  entryBeingEdited: boolean = false;
  apiFailing: boolean = false;
  collator = new Intl.Collator(undefined, { numeric: true, sensitivity: 'base' });
  spinner: boolean = false;

  constructor(
    private artistService: ArtistService,
    public dialog : MatDialog,
    private notificationService : NotificationService
  ){}

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
      console.log(this.artists);

      this.setColumns();
      this.loaded = true;
    })
  }

  setColumns(): void {
    this.artistColumns = [
      {
        name: 'name',
        dataKey: 'name',
        position: 'left',
        isSortable: true,
        isEditable: true,
        hidden: false,
        type: ContentType.editableTextFields
      },
      {
        name: 'city',
        dataKey: 'city',
        position: 'left',
        isSortable: false,
        type: ContentType.editableTextFields,
      },
      {
        name: 'recruitmentEmail',
        dataKey: 'recruitmentEmail',
        position: 'left',
        isSortable: false,
        type: ContentType.editableTextFields,
      }
    ];
  }

  showFormDialog() {}

  sortData(sortParameters: Sort) {
    const keyName = sortParameters.active;
    if (sortParameters.direction === 'asc') {
      this.artists = [ ...this.artists.sort((a, b) => this.collator.compare(a[ keyName ], b[ keyName ])) ];
    } else if (sortParameters.direction === 'desc') {
      this.artists = [ ...this.artists.sort((a, b) => (-1) * this.collator.compare(a[ keyName ], b[ keyName ])) ];
    } else {
      this.getArtist();
    }
  }

  updateElement(event: any) {}

  deleteElement(event: any) {}

  createElement(event: any) {}

  updatePageNumber(pageNum: number) {
    this.pageNumber = pageNum;
  }
}
