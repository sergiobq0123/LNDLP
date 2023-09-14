import { Component, TemplateRef, ViewChild } from '@angular/core';
import { Sort } from '@angular/material/sort';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { NotificationService } from 'src/app/services/notification.service';
import { ContentType, GenericForm } from '../generic-form-dialog/generic-content';
import { Column } from '../generic-table/column';
import { ArtistService } from 'src/app/services/intranet/artist.service';
import { Validators } from '@angular/forms';
import { GenericFormDialogComponent } from '../generic-form-dialog/generic-form-dialog.component';
import { notifications } from 'src/app/common/notifications';
import { MatTableDataSource } from '@angular/material/table';
import { GenericTableComponent } from '../generic-table/generic-table.component';


@Component({
  selector: 'app-artist-admin',
  templateUrl: './artist-admin.component.html',
  styleUrls: ['./artist-admin.component.scss']
})
export class ArtistAdminComponent {
  artists: Array<any> = new Array<any>();
  socialNetwork: Array<any> = new Array<any>();
  artistColumns: Column[];
  artistForm : GenericForm[];
  pageNumber: number = 1;
  loaded: boolean = false;
  newRowAdded: boolean = false;
  entryBeingEdited: boolean = false;
  apiFailing: boolean = false;
  collator = new Intl.Collator(undefined, { numeric: true, sensitivity: 'base' });
  spinner: boolean = false;

  @ViewChild(GenericTableComponent) table: GenericTableComponent;
  @ViewChild('socialNetworkTemplate') socialNetworkTemplate : TemplateRef<any>

  constructor(
    private artistService: ArtistService,
    public dialog : MatDialog,
    private notificationService : NotificationService
  ){}

  ngOnInit(){
    this.getArtist()
    this.setArtistForm()
  }

  getArtist() {
    this.artistService.get().subscribe((res) => {
      let artists = new Array();
      res.forEach(val => {
        artists.push(val)
      });
      this.artists = [... artists];
      this.setColumns();
      this.loaded = true;
    });
  }

  setColumns(): void {
    this.artistColumns = [
      {
        name: 'id',
        dataKey: 'id',
        hidden: true
      },
      {
        name: 'name',
        dataKey: 'name',
        position: 'left',
        isSortable: true,
        isEditable: true,
        hidden: false,
        type: ContentType.editableTextFields
      },
      {
        name: 'city',
        dataKey: 'city',
        position: 'left',
        isSortable: false,
        isEditable: true,
        type: ContentType.editableTextFields,
      },
      {
        name: 'recruitmentEmail',
        dataKey: 'recruitmentEmail',
        position: 'left',
        isSortable: false,
        isEditable: true,
        type: ContentType.editableTextFields,
      },
      {
        name: 'communicationemail',
        dataKey: 'communicationEmail',
        position: 'left',
        isSortable: false,
        isEditable: true,
        type: ContentType.editableTextFields,
      },
      {
        name: 'phone',
        dataKey: 'phone',
        position: 'left',
        isSortable: false,
        isEditable: true,
        type: ContentType.editableTextFields,
      }
      ,
      {
        name: 'Foto',
        dataKey: 'photo',
        position: 'left',
        isSortable: false,
        isEditable: true,
        type: ContentType.editableTextFields,
      }
    ];
  }

  setArtistForm() {
    this.artistForm = [
      {
        name: 'Id',
        dataKey : 'id',
        hidden : true
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
        name: 'Email Contratacion',
        dataKey : 'recruitmentemail',
        position: {row: 2, col : 0, rowSpan: 1, colSpan: 1},
        type : ContentType.editableTextFields,
        validators: [Validators.required]
      },
      {
        name: 'Email Comunicacion',
        dataKey : 'communicationemail',
        position: {row: 2, col : 2, rowSpan: 1, colSpan: 1},
        type : ContentType.editableTextFields,
        validators: [Validators.required]
      },
      {
        name: 'Telefono',
        dataKey : 'phone',
        position: {row: 3, col : 1, rowSpan: 1, colSpan: 1},
        type : ContentType.editableTextFields,
        validators: [Validators.required]
      },
      {
        name: 'Foto',
        dataKey: 'photo',
        position: {row: 3, col : 1, rowSpan: 1, colSpan: 1},
        type: ContentType.image,
      }
    ]
  }

  showFormDialog() {
    let dialogData = {
      formData: undefined,
      formFields: this.artistForm,
      formCols: 2,
      dialogTitle: 'Añade un nuevo artista'
    }
    const dialogRef = this.dialog.open(GenericFormDialogComponent, {data: dialogData, minWidth : 600});
    dialogRef.afterClosed().subscribe(result => {
      if(result !== undefined && result !== null && result !== ''){
        console.log(result);
        this.createElement(result)
      }
    })
  }

  sortData(sortParameters: Sort) {
    const keyName = sortParameters.active;
    if (sortParameters.direction === 'asc') {
      this.artists = [ ...this.artists.sort((a, b) => this.collator.compare(a[ keyName ], b[ keyName ])) ];
    } else if (sortParameters.direction === 'desc') {
      this.artists = [ ...this.artists.sort((a, b) => (-1) * this.collator.compare(a[ keyName ], b[ keyName ])) ];
    } else {
      this.getArtist();
    }
  }

  updateElement(event: any) {
    this.artistService.update(event.id, event).subscribe(res => {
      this.getArtist();
      this.notificationService.showMessageOnSnackbar(notifications.ENTRY_SAVED_SUCCESSFULLY, 'OK!', 3500, 'succes-button');
      this.apiFailing = false;
    }, err => {
      this.notificationService.showMessageOnSnackbar(notifications.ENTRY_NOT_SAVED, 'KO!', 3500, 'succes-button')
      this.apiFailing = true;
    }
    )
  }

  deleteElement(event: any) {
    this.artistService.delete(event.id).subscribe(res => {
      this.getArtist();
      this.notificationService.showMessageOnSnackbar(notifications.ENTRY_DELETED_SUCCESSFULLY, 'OK!', 3500, 'succes-button');
      this.apiFailing = false;
      if(this.table.tableDataSource.data.length === 1){
        this.table.setTableDataSource();
      }
    }, err => {
      this.notificationService.showMessageOnSnackbar(notifications.ENTRY_NOT_DELETED, 'KO!', 3500, 'succes-button')
      this.apiFailing = true;
    }
    )
  }

  createElement(event: any) {
    event.id = 0;
    this.artistService.create(event).subscribe(res => {
      this.getArtist();
      this.notificationService.showMessageOnSnackbar(notifications.ENTRY_CREATED_SUCCESSFULLY, 'OK!', 3500, 'succes-button');
      this.apiFailing = false;
    }, err => {
      this.notificationService.showMessageOnSnackbar(notifications.ENTRY_NOT_CREATED, 'KO!', 3500, 'succes-button')
      this.apiFailing = true;
    }
    )
  }


  updatePageNumber(pageNum: number) {
    this.pageNumber = pageNum;
  }
}
