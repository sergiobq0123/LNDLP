import { Component, TemplateRef, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { notifications } from 'src/app/common/notifications';
import { NotificationService } from 'src/app/services/notification.service';
import {
  GenericForm,
  ContentType,
} from '../general/generic-form-dialog/generic-content';
import { GenericFormDialogComponent } from '../general/generic-form-dialog/generic-form-dialog.component';
import { Column } from '../general/generic-table/column';
import { GenericTableComponent } from '../general/generic-table/generic-table.component';
import { PageEvent } from '@angular/material/paginator';
import { CompanyService } from 'src/app/services/intranet/company.service';
import { CompanyTypeService } from 'src/app/services/intranet/company-type.service';
import { Validators } from '@angular/forms';
import { faPlus } from '@fortawesome/free-solid-svg-icons';
import { IconButton } from '../general/generic-table/icon-button';
import { Filter } from '../general/generic-filter/filter';
import { Sort } from '@angular/material/sort';

@Component({
  selector: 'app-company-admin',
  templateUrl: './company-admin.component.html',
  styleUrls: ['./company-admin.component.scss'],
})
export class CompanyAdminComponent {
  entries: Array<any> = new Array<any>();
  companiesKeys: Array<any> = new Array<any>();
  columns: Column[];
  companyForm: GenericForm[];
  imageForm: GenericForm[];
  apiFailing: boolean = false;
  loaded: boolean = false;
  newRowAdded: boolean = false;
  entryBeingEdited: boolean = false;
  pageNumber: number = 1;
  photo: any;
  spinner: boolean = false;
  pageSize: number = 10;
  totalRecords: number;
  iconButtons: IconButton[] = [];
  filters: Filter[];
  sortBy: string;
  sortOrder: string;

  @ViewChild(GenericTableComponent) table: GenericTableComponent;
  @ViewChild('imageTemplate') imageTemplate: TemplateRef<any>;
  @ViewChild('addTemplate') addTemplate: TemplateRef<any>;

  faPlus = faPlus;

  constructor(
    public _companyService: CompanyService,
    public _companyTypeService: CompanyTypeService,
    public _dialog: MatDialog,
    public _notificationService: NotificationService
  ) {}

  ngOnInit() {
    this.getCompaniesType();
    this.getCompanies();
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

  getCompanies() {
    this.spinner = true;
    this._companyService
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

  getCompaniesType() {
    this._companyTypeService.getKeys().subscribe((res) => {
      this.companiesKeys = res;
    });
  }

  setColumns(): void {
    this.columns = [
      {
        name: '_id',
        dataKey: 'id',
        hidden: true,
      },
      {
        name: 'Nombre',
        dataKey: 'name',
        position: 'left',
        isSortable: true,
        hidden: false,
        type: ContentType.editableTextFields,
        validators: [Validators.required],
      },
      {
        name: 'Tipo',
        dataKey: 'companyTypeId',
        position: 'left',
        hidden: false,
        type: ContentType.dropdownFields,
        dropdown: this.companiesKeys,
        dropdownKeyToShow: 'name',
        dropdownKeyValue: 'id',
        validators: [Validators.required],
      },
      {
        name: 'Descripcion',
        dataKey: 'description',
        position: 'left',
        isSortable: true,
        hidden: false,
        type: ContentType.editableTextFields,
      },
      {
        name: 'Enlace',
        dataKey: 'webUrl',
        position: 'left',
        isSortable: true,
        hidden: false,
        type: ContentType.editableTextFields,
      },
      {
        name: 'Photo',
        dataKey: 'photoUrl',
        type: ContentType.specialContent,
        template: this.imageTemplate,
      },
    ];
  }

  setCompanyForm(): any[] {
    return [
      {
        name: 'Id',
        dataKey: 'id',
        hidden: true,
      },
      {
        name: 'Tipo',
        dataKey: 'companyTypeId',
        position: { row: 0, col: 0, rowSpan: 1, colSpan: 1 },
        type: ContentType.dropdownFields,
        dropdown: this.companiesKeys,
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
        name: 'Descripcion',
        dataKey: 'description',
        position: { row: 1, col: 0, rowSpan: 1, colSpan: 1 },
        type: ContentType.editableTextFields,
      },
      {
        name: 'Pagina web',
        dataKey: 'webUrl',
        position: { row: 1, col: 1, rowSpan: 1, colSpan: 1 },
        type: ContentType.editableTextFields,
      },
      {
        name: 'Imagen',
        dataKey: 'photoUrl',
        position: { row: 2, col: 1, rowSpan: 1, colSpan: 2 },
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
      },
    ];
  }

  showFormDialog() {
    let dialogData = {
      formData: undefined,
      formFields: this.setCompanyForm(),
      formCols: 2,
      dialogTitle: 'Añade una nueva empresa',
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
    this._companyService.create(event).subscribe(
      (res) => {
        this.handleResponse(res.message);
      },
      (err) => {
        this.handleErrorResponse(err.error.message);
      }
    );
  }

  updateElement(event: any) {
    this._companyService.update(event.id, event).subscribe(
      (res) => {
        this.handleResponse(res.message);
      },
      (err) => {
        this.handleErrorResponse(err.error.message);
      }
    );
  }

  deleteElement(event: any) {
    this._companyService.delete(event.id).subscribe(
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
    this.getCompanies();
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
    this.getCompanies();
  }

  sortData(sortParameters: Sort) {
    this.sortBy = sortParameters.active;
    this.sortOrder = sortParameters.direction;
    this.pageNumber = 1;
    this.getCompanies();
  }

  filterData(filters: Filter[]) {
    console.log(filters);

    (this.filters = filters),
      (this.pageNumber = 1),
      (this.sortBy = null),
      (this.sortOrder = null),
      this.getCompanies();
  }
}
