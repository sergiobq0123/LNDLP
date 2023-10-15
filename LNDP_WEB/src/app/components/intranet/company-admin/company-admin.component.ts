import { Component, TemplateRef, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { notifications } from 'src/app/common/notifications';
import { NotificationService } from 'src/app/services/notification.service';
import { GenericForm, ContentType } from '../general/generic-form-dialog/generic-content';
import { GenericFormDialogComponent } from '../general/generic-form-dialog/generic-form-dialog.component';
import { Filter } from '../general/generic-table/Filter';
import { Column } from '../general/generic-table/column';
import { GenericTableComponent } from '../general/generic-table/generic-table.component';
import { PageEvent } from '@angular/material/paginator';

import { CompanyService } from 'src/app/services/intranet/company.service';
import { CompanyTypeService } from 'src/app/services/intranet/company-type.service';
import { Validators } from '@angular/forms';


@Component({
  selector: 'app-company-admin',
  templateUrl: './company-admin.component.html',
  styleUrls: ['./company-admin.component.scss']
})
export class CompanyAdminComponent {
  companies: Array<any> = new Array<any>();
  companiesKeys: Array<any> = new Array<any>();
  companiesColumns: Column[];
  companyForm: GenericForm[];
  imageForm: GenericForm[];
  apiFailing: boolean = false;
  loaded: boolean = false;
  newRowAdded: boolean = false;
  entryBeingEdited: boolean = false;
  pageNumber: number = 1;
  photo: any;
  spinner: boolean = false;
  pageSize : number = 10;
  totalCompanies = 50

  @ViewChild(GenericTableComponent) table: GenericTableComponent;
  @ViewChild('imageTemplate') imageTemplate: TemplateRef<any>;

  constructor(
    public _companyService: CompanyService,
    public _companyTypeService: CompanyTypeService,
    public _dialog: MatDialog,
    public _notificationService : NotificationService
  ) {}

  ngOnInit() {
    this.getCompaniesType();
    this.getCompanies();
  }

  getCompanies() {
    this.spinner = true;
    this._companyService.get().subscribe(
      (res) => {
        this.handleGetResponse(res);
      },
      (error) => {
        this.handleGetErrorResponse();
      }
    );
  }

  getCompaniesType() {
    this._companyTypeService.get().subscribe(
      (res) => {
        this.companiesKeys = res;
      },
    );
  }

  setColumns(): void {
    this.companiesColumns = [
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
        validators: [Validators.required]
      },
      {
        name: 'Tipo',
        dataKey: 'companyTypeId',
        position: 'left',
        hidden: false,
        type: ContentType.dropdownFields,
        dropdown: this.companiesKeys,
        dropdownKeyToShow: 'companyTypeName',
        dropdownKeyValue: 'id',
        validators: [Validators.required]
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
        name: 'Nombre',
        dataKey: 'name',
        position: { row: 0, col: 0, rowSpan: 1, colSpan: 1 },
        type: ContentType.editableTextFields,
        validators: [Validators.required]
      },
      {
        name: 'Tipo',
        dataKey: 'companyTypeId',
        position: { row: 0, col: 0, rowSpan: 1, colSpan: 1 },
        type: ContentType.dropdownFields,
        dropdown: this.companiesKeys,
        dropdownKeyToShow: 'companyTypeName',
        dropdownKeyValue: 'id',
        validators: [Validators.required]
      },
      {
        name: 'Descripcion',
        dataKey: 'description',
        position: { row: 0, col: 0, rowSpan: 1, colSpan: 1 },
        type: ContentType.editableTextFields,
      },
      {
        name: 'Pagina web',
        dataKey: 'webUrl',
        position: { row: 0, col: 0, rowSpan: 1, colSpan: 1 },
        type: ContentType.editableTextFields,
      },
      {
        name: 'Imagen',
        dataKey: 'photoUrl',
        position: { row: 1, col: 1, rowSpan: 1, colSpan: 2 },
        type: ContentType.imageFile,
        validators: [Validators.required]
      },
    ];
  }

  setImageForm(): any[] {
    return [
      {
        name: 'Id',
        dataKey: 'id',
        hidden : true
      },
      {
        name: 'Nombre',
        dataKey: 'name',
        hidden : true
      },
      {
        name: 'Tipo',
        dataKey: 'companyTypeId',
        hidden : true
      },
      {
        name: 'Descripcion',
        dataKey: 'description',
        hidden : true
      },
      {
        name: 'Pagina web',
        dataKey: 'webUrl',
        hidden : true
      },
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
      formData: dataShow ,
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
        this.updateElement(result)
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
    this.companies = res;
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

  onPaginationChange(PageEvent: PageEvent){
    this.pageNumber = PageEvent.pageIndex + 1;
    this.pageSize = PageEvent.pageSize;
    this.getCompanies();
  }

  filterData(filters: Filter[]) {
    this._companyService.getFiltered(filters).subscribe((res) => {
      this.companies = res;
    });
  }

  updatePageNumber(pageNum: number) {
    this.pageNumber = pageNum;
  }
}
