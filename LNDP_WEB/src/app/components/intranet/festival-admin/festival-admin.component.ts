import { Component, TemplateRef, ViewChild } from '@angular/core';
import { Column } from '../general/generic-table/column';
import { ContentType } from '../general/generic-form-dialog/generic-content';
import { Sort } from '@angular/material/sort';
import { FestivalService } from 'src/app/services/intranet/festival.service';
import { NotificationService } from 'src/app/services/notification.service';
import { notifications } from 'src/app/common/notifications';
import { PageEvent } from '@angular/material/paginator';
import { Filter } from '../general/generic-filter/filter';
import { faPlus } from '@fortawesome/free-solid-svg-icons';
import { IconButton } from '../general/generic-table/icon-button';
import { Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { GenericFormDialogComponent } from '../general/generic-form-dialog/generic-form-dialog.component';
import { GenericTableComponent } from '../general/generic-table/generic-table.component';


@Component({
  selector: 'app-festival-admin',
  templateUrl: './festival-admin.component.html',
  styleUrls: ['./festival-admin.component.scss']
})
export class FestivalAdminComponent {
  festivales: Array<any> = new Array<any>();
  festivalColumns: Column[];
  pageNumber: number = 1;
  loaded: boolean = false;
  collator = new Intl.Collator(undefined, { numeric: true, sensitivity: 'base' });
  spinner: boolean = false;
  newRowAdded: boolean = false;
  entryBeingEdited: boolean = false;
  apiFailing: boolean = false;
  pageSize : number = 10;
  totalFestivales = 50
  iconButtons : IconButton[] = []

  @ViewChild(GenericTableComponent) table: GenericTableComponent;
  @ViewChild('addTemplate') addTemplate: TemplateRef<any>;

  faPlus = faPlus;

  constructor(
    private _festivalService: FestivalService,
    private _notificationService : NotificationService,
    public _dialog: MatDialog,
  ){}

  ngOnInit(){
    this.getFestivales()
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

  getFestivales() {
    this.spinner = true;
    this._festivalService.getIntranet().subscribe(
      (res) => {
        this.handleGetResponse(res);
      },
      (error) => {
        this.handleGetErrorResponse();
      }
    );
  }

  setColumns(): void {
    this.festivalColumns = [
      {
        name: '_id',
        dataKey: 'id',
        hidden: true
      },
      {
        name: 'Nombre',
        dataKey: 'name',
        position: 'left',
        isSortable: false,
        type: ContentType.plainText,
      },
      {
        name: 'Ciudad',
        dataKey: 'city',
        position: 'left',
        isSortable: false,
        type: ContentType.plainText,
      },
      {
        name: 'Localizacion',
        dataKey: 'location',
        position: 'left',
        isSortable: false,
        type: ContentType.plainText,
      },
      {
        name: 'Fecha',
        dataKey: 'date',
        position: 'left',
        isSortable: false,
        type: ContentType.plainText,
      }
    ];
  }

  setFestivalesForm() : any[]{
    return [
      {
        name: 'Id',
        dataKey : 'id',
        hidden : true,
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
      formFields: this.setFestivalesForm(),
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
    this._festivalService.create(event).subscribe(
      (res) => {this.handleResponse(res.message)},
      (err) => {this.handleErrorResponse(err.error.message)}
    );
  }

  updateElement(event: any) {
    this._festivalService.update(event.id, event).subscribe(
      (res) => {this.handleResponse(res.message)},
      (err) => {this.handleErrorResponse(err.error.message)}
    );
  }

  deleteElement(event: any) {
    this._festivalService.delete(event.id).subscribe(
      (res) => {this.handleResponse(res.message)},
      (err) => {this.handleErrorResponse(err.error.message)}
    );
  }

  private handleGetResponse(res: any) {
    this.festivales = res;
    this.setColumns();
    this.loaded = true;
    this.spinner = false;
  }

  private handleGetErrorResponse() {
    this._notificationService.showOkMessage(notifications.LOADING_DATA_FAIL);
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

  filterData(filters: Filter[]) {
    this._festivalService.getFiltered(filters).subscribe((res) => {
      this.festivales = res;
    });
  }

  onPaginationChange(PageEvent: PageEvent){
    this.pageNumber = PageEvent.pageIndex + 1;
    this.pageSize = PageEvent.pageSize;
    this.getFestivales();
  }
}
