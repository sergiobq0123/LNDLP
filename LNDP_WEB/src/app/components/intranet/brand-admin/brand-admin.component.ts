import { Component, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { PageEvent } from '@angular/material/paginator';
import { notifications } from 'src/app/common/notifications';
import { NotificationService } from 'src/app/services/notification.service';
import { GenericForm, ContentType } from '../generic-form-dialog/generic-content';
import { GenericFormDialogComponent } from '../generic-form-dialog/generic-form-dialog.component';
import { Filter } from '../generic-table/Filter';
import { Column } from '../generic-table/column';
import { GenericTableComponent } from '../generic-table/generic-table.component';
import { BrandService } from 'src/app/services/intranet/brand.service';

@Component({
  selector: 'app-brand-admin',
  templateUrl: './brand-admin.component.html',
  styleUrls: ['./brand-admin.component.scss']
})
export class BrandAdminComponent {
  brands: Array<any> = new Array<any>();
  brandColumns: Column[];
  brandForm: GenericForm[];
  apiFailing: boolean = false;
  loaded: boolean = false;
  newRowAdded: boolean = false;
  entryBeingEdited: boolean = false;
  pageNumber: number = 1;
  photo: any;
  spinner: boolean = false;
  pageSize : number = 10;
  totalBrands = 50

  @ViewChild(GenericTableComponent) table: GenericTableComponent;

  constructor(
    public _brandService: BrandService,
    public _dialog: MatDialog,
    public _notificationService : NotificationService
  ) {}

  ngOnInit() {
    this.getBrands();
    this.setBrandForm();
  }

  getBrands() {
    this.spinner = true;
    this._brandService.get().subscribe({
      next : res => {
        let brand = new Array();
        res.forEach((val) => {
          brand.push(val);
        });
        this.brands = [...brand];
        this.setColumns();
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

  setColumns(): void {
    this.brandColumns = [
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
        name: 'Descripcion',
        dataKey: 'description',
        position: 'left',
        isSortable: true,
        hidden: false,
        type: ContentType.editableTextFields,
      },
      {
        name: 'URL',
        dataKey: 'url',
        position: 'left',
        isSortable: true,
        hidden: false,
        type: ContentType.editableTextFields,
      },
      {
        name: 'Photo',
        dataKey: 'photo',
        type: ContentType.imageFile
      },
    ];
  }

  setBrandForm() {
    this.brandForm = [
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
        name: 'Descripcion',
        dataKey: 'description',
        position: { row: 0, col: 0, rowSpan: 1, colSpan: 1 },
        type: ContentType.editableTextFields,
      },
      {
        name: 'Pagina web',
        dataKey: 'url',
        position: { row: 0, col: 0, rowSpan: 1, colSpan: 1 },
        type: ContentType.editableTextFields,
      },
      {
        name: 'Imagen',
        dataKey: 'photo',
        position: { row: 1, col: 1, rowSpan: 1, colSpan: 2 },
        type: ContentType.imageFile,
      },
    ];
  }

  showFormDialog() {
    let dialogData = {
      formData: undefined,
      formFields: this.brandForm,
      formCols: 2,
      dialogTitle: 'Añade una nueva marca',
    };
    const dialogRef = this._dialog.open(GenericFormDialogComponent, {
      data: dialogData,
      minWidth: 600,
    });
    dialogRef.afterClosed().subscribe((result) => {
      if (result !== undefined && result !== null && result !== '') {
        this.convertImage(result.photo);
        this.createElement(this.photo,result);
      }
    });
  }

  updateElement(event: any) {
    this._brandService.update(event.id, event).subscribe(
      (res) => {
        this.getBrands();
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
    this._brandService.delete(event.id).subscribe(
      (res) => {
        this.getBrands();
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
    this._brandService.getFiltered(filters).subscribe((res) => {
      this.brands = res;
    });
  }

  createElement(photo: any, event: any) {
    event.id = 0;
    this._brandService.postImage(event, photo).subscribe(
      (res) => {
        console.log(res);

        this.getBrands();
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

  convertImage(urlImage) {
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
    const originalFileName = this.generarNombreUnico('image');
    this.photo = new File([blob], originalFileName, { type: mimeType });
  }

  generarNombreUnico(nombreOriginal: string): string {
    const fechaActual = new Date();
    const timestamp = fechaActual.getTime();
    const nombreSinExtension = nombreOriginal.replace(/\.[^/.]+$/, '');
    const extension = nombreOriginal.split('.').pop();
    const nombreUnico = `${nombreSinExtension}_${timestamp}.jpg`;
    return nombreUnico;
  }

  onPaginationChange(PageEvent: PageEvent){
    this.pageNumber = PageEvent.pageIndex + 1;
    this.pageSize = PageEvent.pageSize;
    this.getBrands();
  }
}
