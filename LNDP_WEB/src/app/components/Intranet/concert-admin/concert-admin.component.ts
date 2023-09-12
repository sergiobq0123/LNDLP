import { Component } from '@angular/core';
import { Column } from '../../generic-table/column';
import { MatDialog } from '@angular/material/dialog';
import { NotificationService } from 'src/app/services/notification.service';
import { ContentType } from '../../generic-form-dialog/generic-content';
import { Sort } from '@angular/material/sort';
import { ConcertService } from 'src/app/services/intranet/concert.service';

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
  newRowAdded: boolean = false;
  entryBeingEdited: boolean = false;
  apiFailing: boolean = false;
  collator = new Intl.Collator(undefined, { numeric: true, sensitivity: 'base' });
  spinner: boolean = false;

  constructor(
    private concertService: ConcertService,
    public dialog : MatDialog,
    private notificationService : NotificationService
  ){}

  ngOnInit(){
    this.getConciertos()
  }

  getConciertos() {
    this.concertService.get().subscribe((res) => {
      console.log(res);

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
        name: 'name',
        dataKey: 'name',
        position: 'left',
        isSortable: true,
        isEditable: true,
        hidden: false,
        type: ContentType.editableTextFields
      },
      {
        name: 'city',
        dataKey: 'city',
        position: 'left',
        isSortable: false,
        type: ContentType.editableTextFields,
      },
      {
        name: 'recruitmentEmail',
        dataKey: 'recruitmentEmail',
        position: 'left',
        isSortable: false,
        type: ContentType.editableTextFields,
      }
    ];
  }

  showFormDialog() {}

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

  updateElement(event: any) {}

  deleteElement(event: any) {}

  createElement(event: any) {}

  updatePageNumber(pageNum: number) {
    this.pageNumber = pageNum;
  }
}
