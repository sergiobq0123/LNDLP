import { Component } from '@angular/core';
import { Column } from '../generic-table/column';
import { MatDialog } from '@angular/material/dialog';
import { ContentType } from '../generic-form-dialog/generic-content';
import { Sort } from '@angular/material/sort';
import { FestivalService } from 'src/app/services/intranet/festival.service';


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
  newRowAdded: boolean = false;
  entryBeingEdited: boolean = false;
  apiFailing: boolean = false;
  collator = new Intl.Collator(undefined, { numeric: true, sensitivity: 'base' });
  spinner: boolean = false;

  constructor(
    private festivalService: FestivalService,
    public dialog : MatDialog,
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

  setColumns(): void {
    this.festivalColumns = [
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
      this.festivales = [ ...this.festivales.sort((a, b) => this.collator.compare(a[ keyName ], b[ keyName ])) ];
    } else if (sortParameters.direction === 'desc') {
      this.festivales = [ ...this.festivales.sort((a, b) => (-1) * this.collator.compare(a[ keyName ], b[ keyName ])) ];
    } else {
      this.getFestivales();
    }
  }

  updatePageNumber(pageNum: number) {
    this.pageNumber = pageNum;
  }
}
