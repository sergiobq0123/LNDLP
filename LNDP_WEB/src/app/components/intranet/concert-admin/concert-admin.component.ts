import { Component, ViewChild } from '@angular/core';
import { Column } from '../general/generic-table/column';
import { ContentType } from '../general/generic-form-dialog/generic-content';
import { Sort } from '@angular/material/sort';
import { ConcertService } from 'src/app/services/intranet/concert.service';
import { GenericTableComponent } from '../general/generic-table/generic-table.component';
import { Filter } from '../general/generic-table/Filter';
import { NotificationService } from 'src/app/services/notification.service';
import { notifications } from 'src/app/common/notifications';
import { PageEvent } from '@angular/material/paginator';


@Component({
  selector: 'app-concert-admin',
  templateUrl: './concert-admin.component.html',
  styleUrls: ['./concert-admin.component.scss']
})
export class ConcertAdminComponent {
  conciertos: Array<any> = new Array<any>();
  conciertosColumns: Column[];
  pageNumber: number = 1;
  loaded: boolean = false;
  spinner: boolean = false;
  apiFailing: boolean = false;
  pageSize : number = 10;
  totalConcerts = 50

  constructor(
    private _concertService: ConcertService,
    private _notificationService : NotificationService
  ){}

  ngOnInit(){
    this.getConciertos();
  }

  getConciertos() {
    this.spinner = true;
    this._concertService.get().subscribe({
      next : res => {
        let conciertos = new Array();
        res.forEach(val => {
          conciertos.push(val)
        });
        this.conciertos = [... conciertos];
        console.log(this.conciertos);
        this.setColumns();
        this.loaded = true;
        this.spinner = false;
      },
      error : err => {
        this._notificationService.showMessageOnSnackbar(notifications.LOADING_DATA_FAIL, 'X', 3500, 'err-button');
        this.apiFailing = false;
        this.spinner = false;
      }
    })
  }

  setColumns(): void {
    this.conciertosColumns = [
      {
        name: '_Id',
        dataKey: 'id',
        hidden: true
      },
      {
        name: 'Nombre',
        dataKey: 'name',
        position: 'left',
        isSortable: true,
        type: ContentType.plainText,
      },
      {
        name: 'Ciudad',
        dataKey: 'city',
        position: 'left',
        isSortable: true,
        type: ContentType.plainText,
      },
      {
        name: 'Localización',
        dataKey: 'location',
        position: 'left',
        isSortable: false,
        type: ContentType.plainText,
      }
      ,
      {
        name: 'Google Maps',
        dataKey: 'urlLocation',
        position: 'left',
        isSortable: false,
        type: ContentType.buttonMap,
      }
      ,
      {
        name: 'Fecha',
        dataKey: 'date',
        position: 'left',
        isSortable: true,
        type: ContentType.plainText,
      }
    ];
  }

  filterData(filters : Filter[]){
    this._concertService.getFiltered(filters).subscribe(res =>{
      this.conciertos = res
    })
  }

  onPaginationChange(PageEvent: PageEvent){
    this.pageNumber = PageEvent.pageIndex + 1;
    this.pageSize = PageEvent.pageSize;
    this.getConciertos();
  }
}
