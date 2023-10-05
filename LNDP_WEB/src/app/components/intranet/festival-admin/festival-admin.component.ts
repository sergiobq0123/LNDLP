import { Component } from '@angular/core';
import { Column } from '../general/generic-table/column';
import { ContentType } from '../general/generic-form-dialog/generic-content';
import { Sort } from '@angular/material/sort';
import { FestivalService } from 'src/app/services/intranet/festival.service';
import { Filter } from '../general/generic-table/Filter';
import { NotificationService } from 'src/app/services/notification.service';
import { notifications } from 'src/app/common/notifications';
import { PageEvent } from '@angular/material/paginator';

@Component({
  selector: 'app-festival-admin',
  templateUrl: './festival-admin.component.html',
  styleUrls: ['./festival-admin.component.scss']
})
export class FestivalAdminComponent {
  festivales: Array<any> = new Array<any>();
  festivalColumns: Column[];
  pageNumber: number = 1;
  loaded: boolean = false;
  collator = new Intl.Collator(undefined, { numeric: true, sensitivity: 'base' });
  spinner: boolean = false;
  apiFailing: boolean = false;
  pageSize : number = 10;
  totalFestivals = 50

  constructor(
    private _festivalService: FestivalService,
    private _notificationService : NotificationService
  ){}

  ngOnInit(){
    this.getFestivales()
  }

  getFestivales() {
    this.spinner = true;
    this._festivalService.get().subscribe({
      next : res => {
        let festivales = new Array();
        res.forEach(val => {
          festivales.push(val)
        });
        this.festivales = [... festivales];
        this.setColumns();
        this.loaded = true;
        this.spinner = false;
      },
      error : err => {
        this._notificationService.showMessageOnSnackbar(notifications.LOADING_DATA_FAIL, 'X', 3500, 'err-button');
        this.spinner = false;
      }
    })
  }

  filterData(filters : Filter[]){
    this._festivalService.getFiltered(filters).subscribe(res =>{
      this.festivales = res
    })
  }

  setColumns(): void {
    this.festivalColumns = [
      {
        name: '_id',
        dataKey: 'id',
        hidden: true
      },
      {
        name: 'Nombre',
        dataKey: 'name',
        position: 'left',
        isSortable: false,
        type: ContentType.plainText,
      },
      {
        name: 'Ciudad',
        dataKey: 'city',
        position: 'left',
        isSortable: false,
        type: ContentType.plainText,
      },
      {
        name: 'Localizacion',
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
        isSortable: false,
        type: ContentType.plainText,
      }
    ];
  }

  onPaginationChange(PageEvent: PageEvent){
    this.pageNumber = PageEvent.pageIndex + 1;
    this.pageSize = PageEvent.pageSize;
    this.getFestivales();
  }
}
