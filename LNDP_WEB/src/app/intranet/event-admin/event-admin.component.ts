import { Component, ViewChild } from '@angular/core';
import { Column } from '../generic-table/column';
import { GenericTableComponent } from '../generic-table/generic-table.component';
import { EventService } from 'src/app/services/intranet/event.service';
import { MatDialog } from '@angular/material/dialog';
import { NotificationService } from 'src/app/services/notification.service';
import { ContentType, GenericForm } from '../generic-form-dialog/generic-content';
import { Validators } from '@angular/forms';
import { GenericFormDialogComponent } from '../generic-form-dialog/generic-form-dialog.component';
import { Sort } from '@angular/material/sort';
import { notifications } from 'src/app/common/notifications';
import { EventTypeService } from 'src/app/services/intranet/event-type.service';
import { Filter } from '../generic-table/Filter';

@Component({
  selector: 'app-event-admin',
  templateUrl: './event-admin.component.html',
  styleUrls: ['./event-admin.component.scss']
})
export class EventAdminComponent {
  eventos: Array<any> = new Array<any>();
  eventosType: Array<any> = new Array<any>();
  eventsColumns: Column[];
  eventsForm : GenericForm[];
  pageNumber: number = 1;
  loaded: boolean = false;
  newRowAdded: boolean = false;
  entryBeingEdited: boolean = false;
  apiFailing: boolean = false;
  collator = new Intl.Collator(undefined, { numeric: true, sensitivity: 'base' });
  spinner: boolean = false;

  @ViewChild(GenericTableComponent) table: GenericTableComponent;

  constructor(
    private eventsService: EventService,
    private eventsTypeService : EventTypeService,
    public dialog : MatDialog,
    private notificationService : NotificationService
  ){}

  ngOnInit(){
    this.getEventsType()
    this.getEvents()
    this.setEventsForm()
  }

  getEventsType(){
    this.eventsTypeService.get().subscribe((res) => {
      let eventsType = new Array();
      res.forEach(val => {
        eventsType.push(val)
      });
      this.eventosType = [... eventsType];
      this.eventsForm.find(e => e.name == "Tipo").dropdown = this.eventosType
    });
  }

  getEvents() {
    this.eventsService.get().subscribe((res) => {
      console.log(res);

      let events = new Array();
      res.forEach(val => {
        events.push(val)
      });
      this.eventos = [... events];
      this.setColumns();
      this.loaded = true;
    });
  }
  filterData(filters : Filter[]){
    this.eventsService.getFiltered(filters).subscribe(res =>{
      this.eventos = res
    })
  }

  setColumns(): void {
    this.eventsColumns = [
      {
        name: '_id',
        dataKey: 'id',
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
        name: 'Tipo',
        dataKey: 'eventTypeId',
        position: 'left',
        isSortable: false,
        isEditable: true,
        type: ContentType.dropdownFields,
        dropdown: this.eventosType,
        dropdownKeyToShow : 'eventName',
        dropdownKeyValue : 'id'
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

  setEventsForm() {
    this.eventsForm = [
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
        name: 'Tipo',
        dataKey: 'eventTypeId',
        position: {row: 0, col : 1, rowSpan: 1, colSpan: 1},
        type: ContentType.dropdownFields,
        dropdown : this.eventosType,
        dropdownKeyValue : 'id',
        dropdownKeyToShow : 'eventName'
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
      formFields: this.eventsForm,
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
      this.eventos = [ ...this.eventos.sort((a, b) => this.collator.compare(a[ keyName ], b[ keyName ])) ];
    } else if (sortParameters.direction === 'desc') {
      this.eventos = [ ...this.eventos.sort((a, b) => (-1) * this.collator.compare(a[ keyName ], b[ keyName ])) ];
    } else {
      this.getEvents();
    }
  }

  updateElement(event: any) {
    this.eventsService.update(event.id, event).subscribe(res => {
      this.getEvents();
      this.notificationService.showMessageOnSnackbar(notifications.ENTRY_SAVED_SUCCESSFULLY, 'OK!', 3500, 'succes-button');
      this.apiFailing = false;
    }, err => {
      this.notificationService.showMessageOnSnackbar(notifications.ENTRY_NOT_SAVED, 'KO!', 3500, 'succes-button')
      this.apiFailing = true;
    }
    )
  }

  deleteElement(event: any) {
    this.eventsService.delete(event.id).subscribe(res => {
      this.getEvents();
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
    this.eventsService.create(event).subscribe(res => {
      this.getEvents();
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
