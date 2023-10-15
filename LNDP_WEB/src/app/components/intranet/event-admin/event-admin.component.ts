import { Component, ViewChild } from '@angular/core';
import { Column } from '../general/generic-table/column';
import { GenericTableComponent } from '../general/generic-table/generic-table.component';
import { EventService } from 'src/app/services/intranet/event.service';
import { MatDialog } from '@angular/material/dialog';
import { NotificationService } from 'src/app/services/notification.service';
import { ContentType, GenericForm } from '../general/generic-form-dialog/generic-content';
import { Validators } from '@angular/forms';
import { GenericFormDialogComponent } from '../general/generic-form-dialog/generic-form-dialog.component';
import { Sort } from '@angular/material/sort';
import { notifications } from 'src/app/common/notifications';
import { EventTypeService } from 'src/app/services/intranet/event-type.service';
import { Filter } from '../general/generic-table/Filter';
import { ArtistService } from '../../../services/intranet/artist.service';
import { PageEvent } from '@angular/material/paginator';

@Component({
  selector: 'app-event-admin',
  templateUrl: './event-admin.component.html',
  styleUrls: ['./event-admin.component.scss']
})
export class EventAdminComponent {
  eventos: Array<any> = new Array<any>();
  artistas: Array<any> = new Array<any>();
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
  pageSize : number = 10;
  totalEvents = 50

  @ViewChild(GenericTableComponent) table: GenericTableComponent;

  constructor(
    private _eventsService: EventService,
    private _artistService: ArtistService,
    private _eventsTypeService : EventTypeService,
    public _dialog : MatDialog,
    private _notificationService : NotificationService
  ){}

  ngOnInit(){
    this.getEvents()
    this.getEventsType()
    this.getArtist();
  }

  getEventsType(){
    this._eventsTypeService.get().subscribe((res) => {
      let eventsType = new Array();
      res.forEach(val => {
        eventsType.push(val)
      });
      this.eventosType = [... eventsType];
    });
  }

  getEvents() {
    this.spinner = true;
    this._eventsService.get().subscribe({
      next : res => {
        let events = new Array();
        res.forEach(val => {
          events.push(val)
        });
        this.eventos = [... events];
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

  getArtist(){
    this._artistService.get().subscribe((res) => {
      let artists = new Array();
      res.forEach(val => {
        artists.push(val)
      });
      this.artistas = [... artists]
    });
  }

  setColumns(): void {
    this.eventsColumns = [
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
        name: '_eventTypeId',
        dataKey: 'eventTypeId',
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
        name: 'Tipo',
        dataKey: 'eventType.eventName',
        position: 'left',
        isSortable: false,
        type: ContentType.plainText,
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
      }
      ,
      {
        name: 'Fecha',
        dataKey: 'date',
        position: 'left',
        isSortable: false,
        type: ContentType.datePicker
      }
    ];
  }

  setEventsForm() : any[]{
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
        name: 'Tipo',
        dataKey: 'eventTypeId',
        position: {row: 0, col : 1, rowSpan: 1, colSpan: 1},
        type: ContentType.dropdownFields,
        dropdown : this.eventosType,
        dropdownKeyToShow : 'eventName',
        dropdownKeyValue : 'id',
      },
      {
        name: 'Artista',
        dataKey: 'artistId',
        position: {row: 0, col : 1, rowSpan: 1, colSpan: 1},
        type: ContentType.dropdownFields,
        dropdown : this.artistas,
        dropdownKeyValue : 'id',
        dropdownKeyToShow : 'name'
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
      formFields: this.setEventsForm(),
      formCols: 2,
      dialogTitle: 'Añade un nuevo evento'
    }

    const dialogRef = this._dialog.open(GenericFormDialogComponent, {data: dialogData, minWidth : 600});
    dialogRef.afterClosed().subscribe(result => {
      if(result !== undefined && result !== null && result !== ''){
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
    this._eventsService.update(event.id, event).subscribe(res => {
      this.getEvents();
      this._notificationService.showMessageOnSnackbar(res.message, 'OK!', 3500, 'success-button');
      this.apiFailing = false;
    }, err => {
      this._notificationService.showMessageOnSnackbar(err.error.message, 'KO!', 3500, 'err-button')
      this.apiFailing = true;
    }
    )
  }

  deleteElement(event: any) {
    this._eventsService.delete(event.id).subscribe(res => {
      this.getEvents();
      this._notificationService.showMessageOnSnackbar(res.message, 'OK!', 3500, 'success-button');
      this.apiFailing = false;
      if(this.table.tableDataSource.data.length === 1){
        this.table.setTableDataSource();
      }
    }, err => {
      this._notificationService.showMessageOnSnackbar(err.error.message, 'KO!', 3500, 'err-button')
      this.apiFailing = true;
    }
    )
  }

  createElement(event: any) {
    event.id = 0;
    this._eventsService.create(event).subscribe(res => {
      this.getEvents();
      this._notificationService.showMessageOnSnackbar(res.message, 'OK!', 3500, 'success-button');
      this.apiFailing = false;
    }, err => {
      this._notificationService.showMessageOnSnackbar(err.error.message, 'KO!', 3500, 'err-button')
      this.apiFailing = true;
    }
    )
  }

  filterData(filters : Filter[]){
    this._eventsService.getFiltered(filters).subscribe(res =>{
      this.eventos = res
    })
  }

  onPaginationChange(PageEvent: PageEvent){
    this.pageNumber = PageEvent.pageIndex + 1;
    this.pageSize = PageEvent.pageSize;
    this.getEvents();
  }
}
