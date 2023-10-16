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
import { Validators } from '@angular/forms';


@Component({
  selector: 'app-artist-song',
  templateUrl: './song-admin.component.html',
  styleUrls: ['./song-admin.component.scss'],
})

export class SongAdminComponent {
  songs: Array<any> = new Array<any>();
  artists: Array<any> = new Array<any>();
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
    this.getArtist();
  }

  getSongs() {
    this.spinner = true;
    this._songService.getIntranet().subscribe(
      (res) => {
        this.handleGetResponse(res);
      },
      (error) => {
        this.handleGetErrorResponse();
      }
    );
  }

  getArtist() {
    this._artistService.getKeys().subscribe(
      (res) => {
       this.artists = res
      }
    );
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
        dataKey: 'artistName',
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
        validators: [Validators.required]
      },
      {
        name: 'Url',
        dataKey: 'url',
        position: 'left',
        isSortable: false,
        type: ContentType.editableTextFields,
        validators: [Validators.required]
      },
    ];
  }

  setSongForm(): any[] {
    return [
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
        validators: [Validators.required]
      },
      {
        name: 'URL',
        dataKey: 'url',
        position: { row: 1, col: 0, rowSpan: 1, colSpan: 1 },
        type: ContentType.editableTextFields,
        validators: [Validators.required]
      },
      {
        name: 'Artista',
        dataKey: 'artistId',
        position: { row: 0, col: 0, rowSpan: 1, colSpan: 1 },
        hidden: false,
        type: ContentType.dropdownFields,
        dropdown: this.artists,
        dropdownKeyToShow: 'name',
        dropdownKeyValue: 'id',
        validators: [Validators.required]
      },
    ];
  }

  showFormDialog() {
    let dialogData = {
      formData: undefined,
      formFields: this.setSongForm(),
      formCols: 2,
      dialogTitle: 'Añade una nueva canción',
    };
    const dialogRef = this._dialog.open(GenericFormDialogComponent, {
      data: dialogData,
      minWidth: 600,
    });
    dialogRef.afterClosed().subscribe((result) => {
      if (result !== undefined && result !== null && result !== '') {
        this.createElement(result);
      }
    });
  }

  createElement(event: any) {
    event.id = 0;
    this._songService.create(event).subscribe(
      (res) => {this.handleResponse(res.message)},
      (err) => {this.handleErrorResponse(err.error.message)}
    );
  }

  updateElement(event: any) {
    this._songService.update(event.id, event).subscribe(
      (res) => {this.handleResponse(res.message)},
      (err) => {this.handleErrorResponse(err.error.message)}
    );
  }

  deleteElement(event: any) {
    this._songService.delete(event.id).subscribe(
      (res) => {this.handleResponse(res.message)},
      (err) => {this.handleErrorResponse(err.error.message)}
    );
  }

  private handleGetResponse(res: any) {
    this.songs = res;
    this.setColumns();
    this.loaded = true;
    this.spinner = false;
  }

  private handleGetErrorResponse() {
    this._notificationService.showErrorMessage(notifications.LOADING_DATA_FAIL);
    this.apiFailing = false;
    this.spinner = false;
  }

  private handleResponse(message: string) {
    this.getSongs();
    this._notificationService.showOkMessage(message);
    this.apiFailing = false;
    if (this.table.tableDataSource.data.length === 1) {
      this.table.setTableDataSource();
    }
  }

  private handleErrorResponse(message: string) {
    this._notificationService.showErrorMessage(message);
    this.apiFailing = true;
  }

  filterData(filters: Filter[]) {
    this._songService.getFiltered(filters).subscribe((res) => {
      this.songs = res;
    });
  }

  onPaginationChange(PageEvent: PageEvent){
    this.pageNumber = PageEvent.pageIndex + 1;
    this.pageSize = PageEvent.pageSize;
    this.getArtist();
  }
}
