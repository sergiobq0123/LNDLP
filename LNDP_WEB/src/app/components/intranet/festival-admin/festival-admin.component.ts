import { Component, TemplateRef, ViewChild } from '@angular/core';
import { Column } from '../general/generic-table/column';
import { ContentType } from '../general/generic-form-dialog/generic-content';
import { Sort } from '@angular/material/sort';
import { FestivalService } from 'src/app/services/intranet/festival.service';
import { NotificationService } from 'src/app/services/notification.service';
import { notifications } from 'src/app/common/notifications';
import { PageEvent } from '@angular/material/paginator';
import { faPlus } from '@fortawesome/free-solid-svg-icons';
import { IconButton } from '../general/generic-table/icon-button';
import { Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { GenericFormDialogComponent } from '../general/generic-form-dialog/generic-form-dialog.component';
import { GenericTableComponent } from '../general/generic-table/generic-table.component';
import { FestivalArtistDialogComponent } from '../Asoc/festival-artist-dialog/festival-artist-dialog.component';
import { FestivalArtistDialogData } from '../Asoc/festival-artist-dialog/festival-artist-data';
import { Festival } from 'src/app/models/festival.model';
import { ArtistService } from 'src/app/services/intranet/artist.service';
import { FestivalArtistAsocService } from 'src/app/services/intranet/festival-artist-asoc.service';
import { Artist } from 'src/app/models/artist.model';
import { ArtistFestivalAsoc } from '../../../models/artistFestivalAsoc.model';
import { Filter } from '../general/generic-filter/filter';

@Component({
  selector: 'app-festival-admin',
  templateUrl: './festival-admin.component.html',
  styleUrls: ['./festival-admin.component.scss'],
})
export class FestivalAdminComponent {
  entries: Array<Festival> = new Array<Festival>();
  artistas: Array<any> = new Array<any>();
  columns: Column[];
  pageNumber: number = 1;
  loaded: boolean = false;
  collator = new Intl.Collator(undefined, {
    numeric: true,
    sensitivity: 'base',
  });
  spinner: boolean = false;
  newRowAdded: boolean = false;
  entryBeingEdited: boolean = false;
  apiFailing: boolean = false;
  pageSize: number = 10;
  totalRecords: number;
  iconButtons: IconButton[] = [];
  filters: Filter[];
  sortBy: string;
  sortOrder: string;

  @ViewChild(GenericTableComponent) table: GenericTableComponent;
  @ViewChild('addTemplate') addTemplate: TemplateRef<any>;
  @ViewChild('imageTemplate') imageTemplate: TemplateRef<any>;
  @ViewChild('artistTemplate') artistTemplate: TemplateRef<any>;

  faPlus = faPlus;

  constructor(
    private _festivalService: FestivalService,
    private _artistService: ArtistService,
    private _festivalArtistAsocService: FestivalArtistAsocService,
    private _notificationService: NotificationService,
    public _dialog: MatDialog
  ) {}

  ngOnInit() {
    this.getFestivales();
    this.getArtist();
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

  getArtist() {
    this._artistService.getKeys().subscribe((res) => {
      this.artistas = res;
    });
  }

  getFestivales() {
    this.spinner = true;
    this._festivalService
      .get(
        this.pageNumber,
        this.pageSize,
        this.sortBy,
        this.sortOrder,
        this.filters
      )
      .subscribe(
        (res) => {
          this.handleGetResponse(res);
        },
        (error) => {
          this.handleGetErrorResponse();
        }
      );
  }

  setColumns(): void {
    this.columns = [
      {
        name: '_id',
        dataKey: 'id',
        hidden: true,
      },
      {
        name: '_artistFestivalAsoc',
        dataKey: 'artistFestivalAsoc',
        hidden: true,
      },
      {
        name: 'Nombre',
        dataKey: 'name',
        position: 'left',
        isSortable: true,
        isFilterable: true,
        type: ContentType.editableTextFields,
      },
      {
        name: 'Ciudad',
        dataKey: 'city',
        position: 'left',
        isSortable: true,
        isFilterable: true,
        type: ContentType.editableTextFields,
      },
      {
        name: 'Localizacion',
        dataKey: 'location',
        position: 'left',
        isSortable: true,
        isFilterable: true,
        type: ContentType.editableTextFields,
      },
      {
        name: 'Entradas',
        dataKey: 'tickets',
        position: 'left',
        isSortable: true,
        type: ContentType.editableTextFields,
      },
      {
        name: 'Fecha',
        dataKey: 'date',
        position: 'left',
        isSortable: true,
        width: '200px',
        isFilterable: true,
        type: ContentType.datePicker,
      },
      {
        name: 'Artistas',
        dataKey: 'artist',
        position: 'left',
        isSortable: false,
        type: ContentType.specialContent,
        template: this.artistTemplate,
      },
      {
        name: 'Photo',
        dataKey: 'photoUrl',
        type: ContentType.specialContent,
        template: this.imageTemplate,
        isSortable: false,
        validators: [Validators.required],
      },
    ];
  }

  setFestivalesForm(): any[] {
    return [
      {
        name: 'Nombre',
        dataKey: 'name',
        position: { row: 0, col: 0, rowSpan: 1, colSpan: 1 },
        type: ContentType.editableTextFields,
        validators: [Validators.required],
      },
      {
        name: 'Ciudad',
        dataKey: 'city',
        position: { row: 1, col: 0, rowSpan: 1, colSpan: 1 },
        type: ContentType.editableTextFields,
        validators: [Validators.required],
      },
      {
        name: 'Localizacion',
        dataKey: 'location',
        position: { row: 2, col: 0, rowSpan: 1, colSpan: 1 },
        type: ContentType.editableTextFields,
        validators: [Validators.required],
      },
      {
        name: 'Entradas',
        dataKey: 'tickets',
        position: { row: 2, col: 2, rowSpan: 1, colSpan: 1 },
        type: ContentType.editableTextFields,
        validators: [Validators.required],
      },
      {
        name: 'Fecha',
        dataKey: 'date',
        width: '200px',
        position: { row: 2, col: 2, rowSpan: 1, colSpan: 1 },
        type: ContentType.datePicker,
        validators: [Validators.required],
      },
      {
        name: 'Imagen',
        dataKey: 'photoUrl',
        position: { row: 1, col: 1, rowSpan: 1, colSpan: 2 },
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
        position: { row: 0, col: 0, rowSpan: 1, colSpan: 2 },
        type: ContentType.imageFile,
        validators: [Validators.required],
      },
    ];
  }

  showFormDialog() {
    let dialogData = {
      formData: undefined,
      formFields: this.setFestivalesForm(),
      formCols: 2,
      dialogTitle: 'Añade un nuevo festival',
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

  showArtistFestival(festival: Festival) {
    let data: FestivalArtistDialogData = {
      festival: festival,
      artistas: this.artistas,
    };
    const dialogRef = this._dialog.open(FestivalArtistDialogComponent, {
      data: data,
      minWidth: 600,
      maxWidth: 600,
      autoFocus: false,
    });
    dialogRef.afterClosed().subscribe((result) => {
      if (!result.isCancel) {
        this.updateFestivalArtistAsoc({
          festivalId: festival.id,
          nuevosArtistas: result.nuevosArtistas,
          artistasEliminados: result.artistasEliminados,
        });
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

  updateFestivalArtistAsoc(data: any) {
    this._festivalArtistAsocService.updateAll(data).subscribe(
      (res) => {
        this.handleResponse(res.message);
      },
      (err) => {
        this.handleErrorResponse(err.error.message);
      }
    );
  }

  createElement(event: any) {
    event.id = 0;
    this._festivalService.create(event).subscribe(
      (res) => {
        this.handleResponse(res.message);
      },
      (err) => {
        this.handleErrorResponse(err.error.message);
      }
    );
  }

  updateElement(event: any) {
    event.artistFestivalAsoc = null;
    this._festivalService.update(event.id, event).subscribe(
      (res) => {
        this.handleResponse(res.message);
      },
      (err) => {
        this.handleErrorResponse(err.error.message);
      }
    );
  }

  deleteElement(event: any) {
    this._festivalService.delete(event.id).subscribe(
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
    this.getFestivales();
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
    this.getFestivales();
  }

  sortData(sortParameters: Sort) {
    this.sortBy = sortParameters.active;
    this.sortOrder = sortParameters.direction;
    this.pageNumber = 1;
    this.getFestivales();
  }

  filterData(filters: Filter[]) {
    (this.filters = filters),
      (this.pageNumber = 1),
      (this.sortBy = null),
      (this.sortOrder = null),
      this.getFestivales();
  }
}
