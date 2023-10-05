import { Component, ViewChild } from '@angular/core';
import { Column } from '../general/generic-table/column';
import { SongService } from '../../../services/intranet/song.service';
import {
  ContentType,
  GenericForm,
} from '../general/generic-form-dialog/generic-content';
import { notifications } from 'src/app/common/notifications';
import { GenericTableComponent } from '../general/generic-table/generic-table.component';
import { Filter } from '../general/generic-table/Filter';
import { GenericFormDialogComponent } from '../general/generic-form-dialog/generic-form-dialog.component';
import { MatDialog } from '@angular/material/dialog';
import { ArtistService } from 'src/app/services/intranet/artist.service';
import { NotificationService } from 'src/app/services/notification.service';
import { PageEvent } from '@angular/material/paginator';


@Component({
  selector: 'app-artist-song',
  templateUrl: './artist-song.component.html',
  styleUrls: ['./artist-song.component.scss'],
})
export class ArtistSongComponent {
  songs: Array<any> = new Array<any>();
  songColumns: Column[];
  songForm: GenericForm[];
  apiFailing: boolean = false;
  loaded: boolean = false;
  newRowAdded: boolean = false;
  entryBeingEdited: boolean = false;
  pageNumber: number = 1;
  spinner: boolean = false;
  pageSize : number = 10;
  totalSongs = 50

  @ViewChild(GenericTableComponent) table: GenericTableComponent;

  constructor(
    public _songService: SongService,
    public _artistService: ArtistService,
    public _dialog: MatDialog,
    public _notificationService: NotificationService
  ) {}

  ngOnInit() {
    this.getSongs();
    this.setSongForm();
  }

  getArtist(): any[] {
    var artist: any[] = [];
    this._artistService.get().subscribe((res) => {
      res.forEach((val) => {
        artist.push(val);
      });
    });
    console.log(artist);

    return artist;
  }

  getSongs() {
    this.spinner = true;
    this._songService.get().subscribe({
      next : res => {
        let songs = new Array();
        res.forEach((val) => {
          songs.push(val);
        });
        this.songs = [...songs];
        this.setColumns();
        this.loaded = true;
        this.spinner = false;
      },
      error : err => {
        this._notificationService.showMessageOnSnackbar(notifications.LOADING_DATA_FAIL, 'X', 3500, 'err-button');
        this.apiFailing = false;
        this.spinner = false;
      }
    });
  }

  setColumns(): void {
    this.songColumns = [
      {
        name: '_id',
        dataKey: 'id',
        hidden: true,
      },
      {
        name: '_artistaId',
        dataKey: 'artistId',
        hidden: true,
      },
      {
        name: 'Artista',
        dataKey: 'artist.name',
        position: 'left',
        isSortable: true,
        hidden: false,
        type: ContentType.plainText,
      },
      {
        name: 'Nombre',
        dataKey: 'name',
        position: 'left',
        isSortable: true,
        hidden: false,
        type: ContentType.editableTextFields,
      },
      {
        name: 'Url',
        dataKey: 'url',
        position: 'left',
        isSortable: false,
        type: ContentType.editableTextFields,
      },
    ];
  }

  setSongForm() {
    this.songForm = [
      {
        name: 'Id',
        dataKey: 'id',
        hidden: true,
      },
      {
        name: 'Nombre',
        dataKey: 'name',
        position: { row: 0, col: 0, rowSpan: 1, colSpan: 1 },
        type: ContentType.editableTextFields,
      },
      {
        name: 'URL',
        dataKey: 'url',
        position: { row: 1, col: 0, rowSpan: 1, colSpan: 1 },
        type: ContentType.editableTextFields,
      },
      {
        name: 'Artista',
        dataKey: 'artistId',
        position: { row: 0, col: 0, rowSpan: 1, colSpan: 1 },
        hidden: false,
        type: ContentType.dropdownFields,
        dropdown: this.getArtist(),
        dropdownKeyToShow: 'name',
        dropdownKeyValue: 'id',
      },
    ];
  }

  showFormDialog() {
    let dialogData = {
      formData: undefined,
      formFields: this.songForm,
      formCols: 2,
      dialogTitle: 'Añade una nueva canción',
    };
    const dialogRef = this._dialog.open(GenericFormDialogComponent, {
      data: dialogData,
      minWidth: 600,
    });
    dialogRef.afterClosed().subscribe((result) => {
      if (result !== undefined && result !== null && result !== '') {
        console.log(result);
        this.createElement(result);
      }
    });
  }

  updateElement(event: any) {
    this._songService.update(event.id, event).subscribe(
      (res) => {
        this.getSongs();
        this._notificationService.showMessageOnSnackbar(
          res.message,
          'OK!',
          3500,
          'success-button'
        );
        this.apiFailing = false;
      },
      (err) => {
        this._notificationService.showMessageOnSnackbar(
          err.error.message,
          'KO!',
          3500,
          'err-button'
        );
        this.apiFailing = true;
      }
    );
  }

  deleteElement(event: any) {
    this._songService.delete(event.id).subscribe(
      (res) => {
        this.getSongs();
        this._notificationService.showMessageOnSnackbar(
          res.message,
          'OK!',
          350000,
          'success-button'
        );
        this.apiFailing = false;
        if (this.table.tableDataSource.data.length === 1) {
          this.table.setTableDataSource();
        }
      },
      (err) => {
        this._notificationService.showMessageOnSnackbar(
          err.error.message,
          'KO!',
          3500,
          'err-button'
        );
        this.apiFailing = true;
      }
    );
  }

  filterData(filters: Filter[]) {
    this._songService.getFiltered(filters).subscribe((res) => {
      this.songs = res;
    });
  }

  createElement(event: any) {
    event.id = 0;
    this._songService.create(event).subscribe(
      (res) => {
        this.getSongs();
        this._notificationService.showMessageOnSnackbar(
          res.message,
          'OK!',
          3500,
          'success-button'
        );
        this.apiFailing = false;
      },
      (err) => {
        this._notificationService.showMessageOnSnackbar(
          err.error.message,
          'ERROr!',
          3500,
          'err-button'
        );
        this.apiFailing = true;
      }
    );
  }

  onPaginationChange(PageEvent: PageEvent){
    this.pageNumber = PageEvent.pageIndex + 1;
    this.pageSize = PageEvent.pageSize;
    this.getArtist();
  }
}
