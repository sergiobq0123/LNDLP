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
import { ArtistService } from '../../../services/intranet/artist.service';
import { MatFormField } from '@angular/material/form-field';

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

  @ViewChild(GenericTableComponent) table: GenericTableComponent;

  constructor(
    private eventsService: EventService,
    private artistService: ArtistService,
    private eventsTypeService : EventTypeService,
    public dialog : MatDialog,
    private notificationService : NotificationService
  ){}

  ngOnInit(){
    this.getEvents()
    this.getEventsType()
    this.getArtist();
  }

  getEventsType(){
    this.eventsTypeService.get().subscribe((res) => {
      let eventsType = new Array();
      res.forEach(val => {
        eventsType.push(val)
      });
      this.eventosType = [... eventsType];
    });
  }

  getEvents() {
    this.eventsService.get().subscribe((res) => {
      let events = new Array();
      res.forEach(val => {
        events.push(val)
      });
      this.eventos = [... events];
      this.setColumns();
      this.loaded = true;
    });
  }

  getArtist(){
    this.artistService.get().subscribe((res) => {
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
    console.log(dialogData.formFields);

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
      this.notificationService.showMessageOnSnackbar(res.message, 'OK!', 3500, 'success-button');
      this.apiFailing = false;
    }, err => {
      this.notificationService.showMessageOnSnackbar(err.error.message, 'KO!', 3500, 'err-button')
      this.apiFailing = true;
    }
    )
  }

  deleteElement(event: any) {
    this.eventsService.delete(event.id).subscribe(res => {
      this.getEvents();
      this.notificationService.showMessageOnSnackbar(res.message, 'OK!', 3500, 'success-button');
      this.apiFailing = false;
      if(this.table.tableDataSource.data.length === 1){
        this.table.setTableDataSource();
      }
    }, err => {
      this.notificationService.showMessageOnSnackbar(err.error.message, 'KO!', 3500, 'err-button')
      this.apiFailing = true;
    }
    )
  }

  createElement(event: any) {
    event.id = 0;
    this.eventsService.create(event).subscribe(res => {
      this.getEvents();
      this.notificationService.showMessageOnSnackbar(res.message, 'OK!', 3500, 'success-button');
      this.apiFailing = false;
    }, err => {
      this.notificationService.showMessageOnSnackbar(err.error.message, 'KO!', 3500, 'err-button')
      this.apiFailing = true;
    }
    )
  }

  filterData(filters : Filter[]){
    this.eventsService.getFiltered(filters).subscribe(res =>{
      this.eventos = res
    })
  }

  updatePageNumber(pageNum: number) {
    this.pageNumber = pageNum;
  }
}
