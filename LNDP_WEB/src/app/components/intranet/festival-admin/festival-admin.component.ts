import { Component } from '@angular/core';
import { Column } from '../generic-table/column';
import { ContentType } from '../generic-form-dialog/generic-content';
import { Sort } from '@angular/material/sort';
import { FestivalService } from 'src/app/services/intranet/festival.service';
import { Filter } from '../generic-table/Filter';


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

  constructor(
    private festivalService: FestivalService,
  ){}

  ngOnInit(){
    this.getFestivales()
  }

  getFestivales() {
    this.festivalService.get().subscribe((res) => {
      console.log(res);

      let festivales = new Array();
      res.forEach(val => {
        festivales.push(val)
      });
      this.festivales = [... festivales];
      console.log(this.festivales);

      this.setColumns();
      this.loaded = true;
    })
  }

  filterData(filters : Filter[]){
    this.festivalService.getFiltered(filters).subscribe(res =>{
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

  updatePageNumber(pageNum: number) {
    this.pageNumber = pageNum;
  }
}