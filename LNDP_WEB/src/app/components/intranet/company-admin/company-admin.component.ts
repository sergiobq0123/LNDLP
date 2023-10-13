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


@Component({
  selector: 'app-company-admin',
  templateUrl: './company-admin.component.html',
  styleUrls: ['./company-admin.component.scss']
})
export class CompanyAdminComponent {
  companies: Array<any> = new Array<any>();
  companiesType: Array<any> = new Array<any>();
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
    this._companyService.get().subscribe({
      next : res => {
        this.companies = res;
        this.loaded = true;
        this.spinner = false
      },
      error : err => {
        this._notificationService.showMessageOnSnackbar(notifications.LOADING_DATA_FAIL, 'X', 3500, 'err-button');
        this.apiFailing = false;
        this.spinner = false;
      }
    });
  }

  getCompaniesType() {
    this.spinner = true;
    this._companyTypeService.get().subscribe({
      next : res => {
        this.companiesType = res;
        console.log(this.companiesType);
        this.loaded = true;
        this.spinner = false
        this.setColumns();
      },
      error : err => {
        this._notificationService.showMessageOnSnackbar(notifications.LOADING_DATA_FAIL, 'X', 3500, 'err-button');
        this.apiFailing = false;
        this.spinner = false;
      }
    });
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
      },
      {
        name: 'Tipo',
        dataKey: 'companyTypeId',
        position: 'left',
        hidden: false,
        type: ContentType.dropdownFields,
        dropdown: this.companiesType,
        dropdownKeyToShow: 'companyTypeName',
        dropdownKeyValue: 'id'
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
      },
      {
        name: 'Tipo',
        dataKey: 'companyTypeId',
        position: { row: 0, col: 0, rowSpan: 1, colSpan: 1 },
        type: ContentType.dropdownFields,
        dropdown: this.companiesType,
        dropdownKeyToShow: 'companyTypeName',
        dropdownKeyValue: 'id'
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
        console.log(result);

        this.createElement(result);
      }
    });
  }

  updateElement(event: any) {
    console.log(event);

    this._companyService.update(event.id, event).subscribe(
      (res) => {
        this.getCompanies();
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
    this._companyService.delete(event.id).subscribe(
      (res) => {
        this.getCompanies();
        this._notificationService.showMessageOnSnackbar(
          res.message,
          'OK!',
          3500,
          'success-button'
        );
        this.apiFailing = false;
        if (this.table.tableDataSource.data.length === 1) {
          this.table.setTableDataSource();
        }
      },
      (err) => {
        this._notificationService.showMessageOnSnackbar(
          err.message,
          'KO!',
          3500,
          'err-button'
        );
        this.apiFailing = true;
      }
    );
  }

  filterData(filters: Filter[]) {
    this._companyService.getFiltered(filters).subscribe((res) => {
      this.companies = res;
    });
  }

  createElement(event: any) {
    event.id = 0
    console.log(event);

    this._companyService.create(event).subscribe(
      (res) => {
        console.log(res);
        this.getCompanies();
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

  updatePageNumber(pageNum: number) {
    this.pageNumber = pageNum;
  }

  convertImage(urlImage, name) {
    const matches = urlImage.match(/^data:([A-Za-z-+\/]+);base64,(.+)$/);
    if (!matches || matches.length !== 3) {
      throw new Error('La representación en base64 es incorrecta.');
    }
    const mimeType = matches[1];
    const base64Data = matches[2];
    const byteCharacters = atob(base64Data);
    const byteNumbers = new Array(byteCharacters.length);
    for (let i = 0; i < byteCharacters.length; i++) {
      byteNumbers[i] = byteCharacters.charCodeAt(i);
    }
    const byteArray = new Uint8Array(byteNumbers);
    const blob = new Blob([byteArray], { type: mimeType });
    const originalFileName = name + '.jpg';
    this.photo = new File([blob], originalFileName, { type: mimeType });
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

  onPaginationChange(PageEvent: PageEvent){
    this.pageNumber = PageEvent.pageIndex + 1;
    this.pageSize = PageEvent.pageSize;
    this.getCompanies();
  }
}
