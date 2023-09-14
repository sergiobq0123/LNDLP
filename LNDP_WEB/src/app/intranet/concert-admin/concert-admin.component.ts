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
        name: 'Localizacion',
        dataKey: 'location',
        position: 'left',
        isSortable: false,
        type: ContentType.editableTextFields,
      }
      ,
      {
        name: 'Google Maps',
        dataKey: 'urlLocation',
        position: 'left',
        isSortable: false,
        isEditable: true,
        type: ContentType.buttonMap,
      }
      ,
      {
        name: 'Fecha',
        dataKey: 'date',
        position: 'left',
        isSortable: false,
        type: ContentType.editableTextFields,
      }
    ];
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

  updatePageNumber(pageNum: number) {
    this.pageNumber = pageNum;
  }
}
