import { Component, ViewChild } from '@angular/core';
import { Column } from '../generic-table/column';
import { ContentType } from '../generic-form-dialog/generic-content';
import { Sort } from '@angular/material/sort';
import { ConcertService } from 'src/app/services/intranet/concert.service';
import { GenericTableComponent } from '../generic-table/generic-table.component';
import { Filter } from '../generic-table/Filter';

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

  constructor(
    private concertService: ConcertService
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
    this.concertService.getFiltered(filters).subscribe(res =>{
      this.conciertos = res
    })
  }

  updatePageNumber(pageNum: number) {
    this.pageNumber = pageNum;
  }
}
