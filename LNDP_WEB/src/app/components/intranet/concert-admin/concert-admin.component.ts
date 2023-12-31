import { Component, TemplateRef, ViewChild } from '@angular/core';
import { Column } from '../general/generic-table/column';
import { ContentType } from '../general/generic-form-dialog/generic-content';
import { ConcertService } from 'src/app/services/intranet/concert.service';
import { GenericTableComponent } from '../general/generic-table/generic-table.component';
import { NotificationService } from 'src/app/services/notification.service';
import { notifications } from 'src/app/common/notifications';
import { PageEvent } from '@angular/material/paginator';
import { ArtistService } from 'src/app/services/intranet/artist.service';
import { Validators } from '@angular/forms';
import { GenericFormDialogComponent } from '../general/generic-form-dialog/generic-form-dialog.component';
import { MatDialog } from '@angular/material/dialog';
import { faPlus } from '@fortawesome/free-solid-svg-icons';
import { IconButton } from '../general/generic-table/icon-button';
import { Filter } from '../general/generic-filter/filter';
import { Sort } from '@angular/material/sort';
import { lastValueFrom } from 'rxjs';

@Component({
  selector: 'app-concert-admin',
  templateUrl: './concert-admin.component.html',
  styleUrls: ['./concert-admin.component.scss'],
})
export class ConcertAdminComponent {
  entries: Array<any> = new Array<any>();
  artistas: Array<any> = new Array<any>();
  columns: Column[];
  apiFailing: boolean = false;
  loaded: boolean = false;
  newRowAdded: boolean = false;
  entryBeingEdited: boolean = false;
  pageNumber: number = 1;
  spinner: boolean = false;
  pageSize: number = 10;
  iconButtons: IconButton[] = [];
  filters: Filter[];
  sortBy: string;
  sortOrder: string;
  totalRecords: number;

  @ViewChild(GenericTableComponent) table: GenericTableComponent;
  @ViewChild('addTemplate') addTemplate: TemplateRef<any>;

  faPlus = faPlus;

  constructor(
    private _concertService: ConcertService,
    private _artistService: ArtistService,
    private _notificationService: NotificationService,
    public _dialog: MatDialog
  ) {}

  async ngOnInit() {
    this.spinner = true;
    await this.getConciertos();
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

  async getConciertos() {
    try {
      this.handleGetResponse(
        await lastValueFrom(
          this._concertService.get(
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
        name: '_artistId',
        dataKey: 'artistId',
        hidden: true,
      },
      {
        name: 'Artista',
        dataKey: 'artist.name',
        position: 'left',
        isSortable: true,
        isFilterable: true,
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
        name: 'Localización',
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
        isFilterable: true,
        width: '200px',
        type: ContentType.datePicker,
      },
    ];
  }

  setConciertosForm(): any[] {
    return [
      {
        name: 'Id',
        dataKey: 'id',
        hidden: true,
      },
      {
        name: 'Artista',
        dataKey: 'artistId',
        position: { row: 0, col: 1, rowSpan: 1, colSpan: 1 },
        type: ContentType.dropdownFields,
        dropdown: this.artistas,
        dropdownKeyValue: 'id',
        dropdownKeyToShow: 'name',
      },
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
        position: { row: 2, col: 0, rowSpan: 1, colSpan: 1 },
        type: ContentType.editableTextFields,
        validators: [Validators.required],
      },
      {
        name: 'Fecha',
        dataKey: 'date',
        position: { row: 2, col: 2, rowSpan: 1, colSpan: 1 },
        type: ContentType.datePicker,
        validators: [Validators.required],
      },
    ];
  }

  showFormDialog() {
    let dialogData = {
      formData: undefined,
      formFields: this.setConciertosForm(),
      formCols: 2,
      dialogTitle: 'Añade un nuevo concierto',
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
    this._concertService.create(event).subscribe(
      (res) => {
        this.handleResponse(res.message);
      },
      (err) => {
        this.handleErrorResponse(err.error.message);
      }
    );
  }

  updateElement(event: any) {
    this._concertService.update(event.id, event).subscribe(
      (res) => {
        this.handleResponse(res.message);
      },
      (err) => {
        this.handleErrorResponse(err.error.message);
      }
    );
  }

  deleteElement(event: any) {
    this._concertService.delete(event.id).subscribe(
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
    this.getConciertos();
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
    this.getConciertos();
  }

  sortData(sortParameters: Sort) {
    this.sortBy = sortParameters.active;
    this.sortOrder = sortParameters.direction;
    this.pageNumber = 1;
    this.getConciertos();
  }

  filterData(filters: Filter[]) {
    (this.filters = filters),
      (this.pageNumber = 1),
      (this.sortBy = null),
      (this.sortOrder = null),
      this.getConciertos();
  }
}
