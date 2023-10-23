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
import { Filter } from '../general/generic-filter/filter';
import { faPlus } from '@fortawesome/free-solid-svg-icons';
import { IconButton } from '../general/generic-table/icon-button';



@Component({
  selector: 'app-concert-admin',
  templateUrl: './concert-admin.component.html',
  styleUrls: ['./concert-admin.component.scss']
})
export class ConcertAdminComponent {
  conciertos: Array<any> = new Array<any>();
  artists: Array<any> = new Array<any>();
  conciertosColumns: Column[];
  apiFailing: boolean = false;
  loaded: boolean = false;
  newRowAdded: boolean = false;
  entryBeingEdited: boolean = false;
  pageNumber: number = 1;
  spinner: boolean = false;
  pageSize : number = 10;
  totalConciertos = 50
  iconButtons : IconButton[] = []

  @ViewChild(GenericTableComponent) table: GenericTableComponent;
  @ViewChild('addTemplate') addTemplate: TemplateRef<any>;

  faPlus = faPlus;

  constructor(
    private _concertService: ConcertService,
    private _artistService: ArtistService,
    private _notificationService : NotificationService,
    public _dialog: MatDialog,
  ){}

  ngOnInit(){
    this.getConciertos();
    this.getArtist();
  }

  ngAfterViewInit(){
    this.setIconsButtons()
  }

  setIconsButtons() {
    this.iconButtons = [
      {
        template: this.addTemplate,
        isLeft: true,
      }
    ];
  }

  getConciertos() {
    this.spinner = true;
    this._concertService.get().subscribe(
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
    this.conciertosColumns = [
      {
        name: '_id',
        dataKey: 'id',
        hidden: true
      },
      {
        name: '_urlLocation',
        dataKey: 'urlLocation',
        hidden: true
      },
      {
        name: '_artistId',
        dataKey: 'artistId',
        hidden: true
      },
      {
        name: 'Artista',
        dataKey: 'artist.name',
        position: 'left',
        isSortable: false,
        type: ContentType.plainText
      },
      {
        name: 'Nombre',
        dataKey: 'name',
        position: 'left',
        isSortable: false,
        type: ContentType.editableTextFields,
      },
      {
        name: 'Ciudad',
        dataKey: 'city',
        position: 'left',
        isSortable: false,
        type: ContentType.editableTextFields,
      },
      {
        name: 'Localización',
        dataKey: 'location',
        position: 'left',
        isSortable: false,
        type: ContentType.editableTextFields,
      },
      {
        name: 'Entradas',
        dataKey: 'tickets',
        position: 'left',
        isSortable: false,
        type: ContentType.editableTextFields,
      },
      {
        name: 'Fecha',
        dataKey: 'date',
        position: 'left',
        isSortable: false,
        type: ContentType.datePicker
      }
    ];
  }

  setConciertosForm() : any[]{
    return [
      {
        name: 'Id',
        dataKey : 'id',
        hidden : true,
      },
      {
        name: 'Artista',
        dataKey: 'artistId',
        position: {row: 0, col : 1, rowSpan: 1, colSpan: 1},
        type: ContentType.dropdownFields,
        dropdown : this.artists,
        dropdownKeyValue : 'id',
        dropdownKeyToShow : 'name'
      },
      {
        name: 'Nombre',
        dataKey : 'name',
        position: {row: 0, col : 0, rowSpan: 1, colSpan: 1},
        type : ContentType.editableTextFields,
        validators: [Validators.required]
      },
      {
        name: 'Ciudad',
        dataKey : 'city',
        position: {row: 1, col : 0, rowSpan: 1, colSpan: 1},
        type : ContentType.editableTextFields,
        validators: [Validators.required]
      },
      {
        name: 'Localizacion',
        dataKey : 'location',
        position: {row: 2, col : 0, rowSpan: 1, colSpan: 1},
        type : ContentType.editableTextFields,
        validators: [Validators.required]
      },
      {
        name: 'Entradas',
        dataKey : 'tickets',
        position: {row: 2, col : 0, rowSpan: 1, colSpan: 1},
        type : ContentType.editableTextFields,
        validators: [Validators.required]
      },
      {
        name: 'Fecha',
        dataKey : 'date',
        position: {row: 2, col : 2, rowSpan: 1, colSpan: 1},
        type : ContentType.datePicker,
        validators: [Validators.required]
      },
    ]
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
      (res) => {this.handleResponse(res.message)},
      (err) => {this.handleErrorResponse(err.error.message)}
    );
  }

  updateElement(event: any) {
    this._concertService.update(event.id, event).subscribe(
      (res) => {this.handleResponse(res.message)},
      (err) => {this.handleErrorResponse(err.error.message)}
    );
  }

  deleteElement(event: any) {
    this._concertService.delete(event.id).subscribe(
      (res) => {this.handleResponse(res.message)},
      (err) => {this.handleErrorResponse(err.error.message)}
    );
  }

  private handleGetResponse(res: any) {
    this.conciertos = res;
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

  filterData(filters: Filter[]) {
    this._concertService.getFiltered(filters).subscribe((res) => {
      this.conciertos = res;
    });
  }

  onPaginationChange(PageEvent: PageEvent){
    this.pageNumber = PageEvent.pageIndex + 1;
    this.pageSize = PageEvent.pageSize;
    this.getArtist();
  }
}
