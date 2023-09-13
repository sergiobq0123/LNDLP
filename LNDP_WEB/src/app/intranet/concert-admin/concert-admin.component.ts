import { Component, ViewChild } from '@angular/core';
import { Column } from '../generic-table/column';
import { MatDialog } from '@angular/material/dialog';
import { NotificationService } from 'src/app/services/notification.service';
import { ContentType, GenericForm } from '../generic-form-dialog/generic-content';
import { Sort } from '@angular/material/sort';
import { ConcertService } from 'src/app/services/intranet/concert.service';
import { GenericTableComponent } from '../generic-table/generic-table.component';
import { notifications } from 'src/app/common/notifications';
import { Validators } from '@angular/forms';
import { GenericFormDialogComponent } from '../generic-form-dialog/generic-form-dialog.component';

@Component({
  selector: 'app-concert-admin',
  templateUrl: './concert-admin.component.html',
  styleUrls: ['./concert-admin.component.scss']
})
export class ConcertAdminComponent {
  conciertos: Array<any> = new Array<any>();
  conciertosColumns: Column[];
  conciertoForm: GenericForm[];
  pageNumber: number = 1;
  loaded: boolean = false;
  newRowAdded: boolean = false;
  entryBeingEdited: boolean = false;
  apiFailing: boolean = false;
  collator = new Intl.Collator(undefined, { numeric: true, sensitivity: 'base' });
  spinner: boolean = false;

  @ViewChild(GenericTableComponent) table: GenericTableComponent;

  constructor(
    private concertService: ConcertService,
    public dialog : MatDialog,
    private notificationService : NotificationService
  ){}

  ngOnInit(){
    this.getConciertos();
    this.setConciertForm();
  }

  getConciertos() {
    this.concertService.get().subscribe((res) => {
      let conciertos = new Array();
      res.forEach(val => {
        conciertos.push(val)
      });
      this.conciertos = [... conciertos];
      console.log(this.conciertos);

      this.setColumns();
      this.loaded = true;
    })
  }

  setColumns(): void {
    this.conciertosColumns = [
      {
        name: 'id',
        dataKey: 'id',
        hidden: true
      },
      {
        name: 'type',
        dataKey: 'eventTypeId',
        hidden: true
      },
      {
        name: 'name',
        dataKey: 'name',
        position: 'left',
        isSortable: false,
        isEditable: true,
        type: ContentType.editableTextFields,
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
        name: 'location',
        dataKey: 'location',
        position: 'left',
        isSortable: false,
        isEditable: true,
        type: ContentType.editableTextFields,
      }
      ,
      {
        name: 'date',
        dataKey: 'date',
        position: 'left',
        isSortable: false,
        isEditable: true,
        type: ContentType.datePicker
      }
    ];
  }

  setConciertForm() {
    this.conciertoForm = [
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
      {
        name: 'Fecha',
        dataKey : 'eventTypeId',
        hidden: true,
        type : ContentType.editableTextFields,
      }
    ]
  }

  showFormDialog() {

    let dialogData = {
      formData: undefined,
      formFields: this.conciertoForm,
      formCols: 2,
      dialogTitle: 'Añade un nuevo concierto'
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
      this.conciertos = [ ...this.conciertos.sort((a, b) => this.collator.compare(a[ keyName ], b[ keyName ])) ];
    } else if (sortParameters.direction === 'desc') {
      this.conciertos = [ ...this.conciertos.sort((a, b) => (-1) * this.collator.compare(a[ keyName ], b[ keyName ])) ];
    } else {
      this.getConciertos();
    }
  }

  updateElement(event: any) {
    this.concertService.update(event.id, event).subscribe(res => {
      this.getConciertos();
      this.notificationService.showMessageOnSnackbar(notifications.ENTRY_SAVED_SUCCESSFULLY, 'OK!', 3500, 'succes-button');
      this.apiFailing = false;
    }, err => {
      this.notificationService.showMessageOnSnackbar(notifications.ENTRY_NOT_SAVED, 'KO!', 3500, 'succes-button')
      this.apiFailing = true;
    }
    )
  }

  deleteElement(event: any) {
    this.concertService.delete(event.id).subscribe(res => {
      this.getConciertos();
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
    this.concertService.create(event).subscribe(res => {
      this.getConciertos();
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
