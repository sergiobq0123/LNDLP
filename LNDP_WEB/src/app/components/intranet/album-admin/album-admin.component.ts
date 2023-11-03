import { Component, TemplateRef, ViewChild } from '@angular/core';
import { Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { notifications } from 'src/app/common/notifications';
import { AlbumService } from 'src/app/services/intranet/album.service';
import { ArtistService } from 'src/app/services/intranet/artist.service';
import { NotificationService } from 'src/app/services/notification.service';
import {
  GenericForm,
  ContentType,
} from '../general/generic-form-dialog/generic-content';
import { GenericFormDialogComponent } from '../general/generic-form-dialog/generic-form-dialog.component';
import { Column } from '../general/generic-table/column';
import { GenericTableComponent } from '../general/generic-table/generic-table.component';
import { PageEvent } from '@angular/material/paginator';
import { faPlus } from '@fortawesome/free-solid-svg-icons';
import { IconButton } from '../general/generic-table/icon-button';
import { Sort } from '@angular/material/sort';
import { Filter } from '../general/generic-filter/filter';
import { lastValueFrom } from 'rxjs';

@Component({
  selector: 'app-album-admin',
  templateUrl: './album-admin.component.html',
  styleUrls: ['./album-admin.component.scss'],
})
export class AlbumAdminComponent {
  entries: Array<any> = new Array<any>();
  artistas: Array<any> = new Array<any>();
  columns: Column[];
  albumForm: GenericForm[];
  apiFailing: boolean = false;
  loaded: boolean = false;
  newRowAdded: boolean = false;
  entryBeingEdited: boolean = false;
  pageNumber: number = 1;
  photo: any;
  spinner: boolean = false;
  pageSize: number = 10;
  iconButtons: IconButton[] = [];
  filters: Filter[];
  sortBy: string;
  sortOrder: string;
  totalRecords: number;

  @ViewChild(GenericTableComponent) table: GenericTableComponent;
  @ViewChild('imageTemplate') imageTemplate: TemplateRef<any>;
  @ViewChild('addTemplate') addTemplate: TemplateRef<any>;

  faPlus = faPlus;

  constructor(
    public _albumService: AlbumService,
    public _artistService: ArtistService,
    public _dialog: MatDialog,
    public _notificationService: NotificationService
  ) {}

  async ngOnInit() {
    this.spinner = true;
    await this.getAlbums();
    await this.getArtist();
    this.setColumns();
    this.loaded = true;
    this.spinner = false;
  }

  ngAfterViewInit() {
    this.setIconsButtons();
  }

  setIconsButtons() {
    this.iconButtons = [
      {
        template: this.addTemplate,
        isLeft: true,
      },
    ];
  }

  async getAlbums() {
    try {
      this.handleGetResponse(
        await lastValueFrom(
          this._albumService.get(
            this.pageNumber,
            this.pageSize,
            this.sortBy,
            this.sortOrder,
            this.filters
          )
        )
      );
    } catch (error) {
      this.handleGetErrorResponse();
    }
  }

  async getArtist() {
    try {
      this.artistas = await lastValueFrom(this._artistService.getKeys());
    } catch (error) {}
  }

  setColumns(): void {
    this.columns = [
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
        isFilterable: true,
        hidden: false,
        type: ContentType.plainText,
        dropdown: this.artistas,
        dropdownKeyToShow: 'name',
      },
      {
        name: 'Nombre',
        dataKey: 'name',
        position: 'left',
        isSortable: true,
        isFilterable: true,
        type: ContentType.editableTextFields,
        validators: [Validators.required],
      },
      {
        name: 'URL',
        dataKey: 'webUrl',
        position: 'left',
        isSortable: true,
        isFilterable: false,
        type: ContentType.editableTextFields,
        validators: [Validators.required],
      },
      {
        name: 'Fecha',
        dataKey: 'date',
        position: 'left',
        isSortable: true,
        isFilterable: true,
        type: ContentType.datePicker,
        validators: [Validators.required],
      },
      {
        name: 'Photo',
        dataKey: 'photoUrl',
        position: 'left',
        isSortable: false,
        isFilterable: false,
        type: ContentType.specialContent,
        template: this.imageTemplate,
        validators: [Validators.required],
      },
    ];
  }

  setAlbumForm(): any[] {
    return [
      {
        name: 'Id',
        dataKey: 'id',
        hidden: true,
      },
      {
        name: 'Artista',
        dataKey: 'artistId',
        position: { row: 0, col: 0, rowSpan: 1, colSpan: 1 },
        hidden: false,
        type: ContentType.dropdownFields,
        dropdown: this.artistas,
        dropdownKeyToShow: 'name',
        dropdownKeyValue: 'id',
        validators: [Validators.required],
      },
      {
        name: 'Nombre',
        dataKey: 'name',
        position: { row: 0, col: 1, rowSpan: 1, colSpan: 1 },
        type: ContentType.editableTextFields,
        validators: [Validators.required],
      },
      {
        name: 'Date',
        dataKey: 'date',
        position: { row: 1, col: 0, rowSpan: 1, colSpan: 1 },
        type: ContentType.datePicker,
        validators: [Validators.required],
      },
      {
        name: 'URL',
        dataKey: 'webUrl',
        position: { row: 1, col: 1, rowSpan: 1, colSpan: 1 },
        type: ContentType.editableTextFields,
        validators: [Validators.required],
      },
      {
        name: 'Imagen',
        dataKey: 'photoUrl',
        position: { row: 2, col: 0, rowSpan: 1, colSpan: 2 },
        type: ContentType.imageFile,
        validators: [Validators.required],
      },
    ];
  }

  setImageForm(): any[] {
    return [
      {
        name: 'Imagen',
        dataKey: 'photoUrl',
        position: { row: 1, col: 1, rowSpan: 1, colSpan: 2 },
        type: ContentType.imageFile,
        validators: [Validators.required],
      },
    ];
  }

  showFormDialog() {
    let dialogData = {
      formData: undefined,
      formFields: this.setAlbumForm(),
      formCols: 2,
      dialogTitle: 'Añade un nuevo álbum',
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

  showFormDialogImage(dataShow: any) {
    let dialogData = {
      formData: dataShow,
      formFields: this.setImageForm(),
      formCols: 2,
      dialogTitle: 'Imagen',
    };
    const dialogRef = this._dialog.open(GenericFormDialogComponent, {
      data: dialogData,
      minWidth: 600,
    });
    dialogRef.afterClosed().subscribe((result) => {
      if (result !== undefined && result !== null && result !== '') {
        dataShow.photoUrl = result.photoUrl;
        this.updateElement(dataShow);
      }
    });
  }

  createElement(event: any) {
    event.id = 0;
    this._albumService.create(event).subscribe(
      (res) => {
        this.handleResponse(res.message);
      },
      (err) => {
        this.handleErrorResponse(err.error.message);
      }
    );
  }

  updateElement(event: any) {
    this._albumService.update(event.id, event).subscribe(
      (res) => {
        this.handleResponse(res.message);
      },
      (err) => {
        this.handleErrorResponse(err.error.message);
      }
    );
  }

  deleteElement(event: any) {
    this._albumService.delete(event.id).subscribe(
      (res) => {
        this.handleResponse(res.message);
      },
      (err) => {
        this.handleErrorResponse(err.error.message);
      }
    );
  }

  private handleGetResponse(res: any) {
    this.entries = res.data;
    this.totalRecords = res.totalEntries;
  }

  private handleGetErrorResponse() {
    this._notificationService.showErrorMessage(notifications.LOADING_DATA_FAIL);
    this.apiFailing = false;
  }

  private handleResponse(message: string) {
    this.getAlbums();
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

  onPaginationChange(PageEvent: PageEvent) {
    this.pageNumber = PageEvent.pageIndex + 1;
    this.pageSize = PageEvent.pageSize;
    this.getAlbums();
  }

  sortData(sortParameters: Sort) {
    this.sortBy = sortParameters.active;
    this.sortOrder = sortParameters.direction;
    this.pageNumber = 1;
    this.getAlbums();
  }

  filterData(filters: Filter[]) {
    (this.filters = filters),
      (this.pageNumber = 1),
      (this.sortBy = null),
      (this.sortOrder = null),
      this.getAlbums();
  }
}
