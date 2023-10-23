import { Component, TemplateRef, ViewChild } from '@angular/core';
import { Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { notifications } from 'src/app/common/notifications';
import { AlbumService } from 'src/app/services/intranet/album.service';
import { ArtistService } from 'src/app/services/intranet/artist.service';
import { NotificationService } from 'src/app/services/notification.service';
import { GenericForm, ContentType } from '../general/generic-form-dialog/generic-content';
import { GenericFormDialogComponent } from '../general/generic-form-dialog/generic-form-dialog.component';
import { Column } from '../general/generic-table/column';
import { GenericTableComponent } from '../general/generic-table/generic-table.component';
import { PageEvent } from '@angular/material/paginator';
import { faPlus } from '@fortawesome/free-solid-svg-icons';
import { IconButton } from '../general/generic-table/icon-button';


@Component({
  selector: 'app-album-admin',
  templateUrl: './album-admin.component.html',
  styleUrls: ['./album-admin.component.scss']
})
export class AlbumAdminComponent {

    albums: Array<any> = new Array<any>();
    artists: Array<any> = new Array<any>();
    albumColumns: Column[];
    albumForm: GenericForm[];
    apiFailing: boolean = false;
    loaded: boolean = false;
    newRowAdded: boolean = false;
    entryBeingEdited: boolean = false;
    pageNumber: number = 1;
    photo: any;
    spinner: boolean = false;
    pageSize : number = 10;
    totalAlbums = 50
    iconButtons : IconButton[] = []

    @ViewChild(GenericTableComponent) table: GenericTableComponent;
    @ViewChild('imageTemplate') imageTemplate: TemplateRef<any>;
    @ViewChild('addTemplate') addTemplate: TemplateRef<any>;

    faPlus = faPlus;

    constructor(
      public _albumService: AlbumService,
      public _artistService: ArtistService,
      public _dialog: MatDialog,
      public _notificationService : NotificationService
    ) {}

    ngOnInit() {
      this.getAlbums();
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

    getAlbums() {
      this.spinner = true;
      this._albumService.get().subscribe(
        (res) => {
          this.handleGetResponse(res);
        },
        (error) => {
          this.handleGetErrorResponse();
        }
      );
    }

    getArtist() {
      this._artistService.getKeys().subscribe((res) => {
         this.artists = res
      });
    }

    setColumns(): void {
      this.albumColumns = [
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
          name: 'URL',
          dataKey: 'webUrl',
          position: 'left',
          isSortable: true,
          hidden: false,
          type: ContentType.editableTextFields,
          validators: [Validators.required]
        },
        {
          name: 'Fecha',
          dataKey: 'date',
          position: 'left',
          isSortable: true,
          hidden: false,
          type: ContentType.datePicker,
          validators: [Validators.required]
        },
        {
          name: 'Photo',
          dataKey: 'photoUrl',
          type: ContentType.specialContent,
          template: this.imageTemplate,
          validators: [Validators.required]
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
          dropdown: this.artists,
          dropdownKeyToShow: 'name',
          dropdownKeyValue: 'id',
          validators: [Validators.required]
        },
        {
          name: 'Nombre',
          dataKey: 'name',
          position: { row: 0, col: 1, rowSpan: 1, colSpan: 1 },
          type: ContentType.editableTextFields,
          validators: [Validators.required]
        },
        {
          name: 'Date',
          dataKey: 'date',
          position: { row: 1, col: 0, rowSpan: 1, colSpan: 1 },
          type: ContentType.datePicker,
          validators: [Validators.required]
        },
        {
          name: 'URL',
          dataKey: 'webUrl',
          position: { row: 1, col: 1, rowSpan: 1, colSpan: 1 },
          type: ContentType.editableTextFields,
          validators: [Validators.required]
        },
        {
          name: 'Imagen',
          dataKey: 'photoUrl',
          position: { row: 2, col: 0, rowSpan: 1, colSpan: 2 },
          type: ContentType.imageFile,
          validators: [Validators.required]
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
          validators: [Validators.required]
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
          dataShow.photoUrl = result.photoUrl
          this.updateElement(dataShow)
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
      this.albums = res;
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

    updatePageNumber(pageNum: number) {
      this.pageNumber = pageNum;
    }

    onPaginationChange(PageEvent: PageEvent){
      this.pageNumber = PageEvent.pageIndex + 1;
      this.pageSize = PageEvent.pageSize;
      this.getAlbums();
    }


}
