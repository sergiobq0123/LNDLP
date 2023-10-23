import { Component, TemplateRef, ViewChild } from '@angular/core';
import { Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { notifications } from 'src/app/common/notifications';
import { ConcertService } from 'src/app/services/intranet/concert.service';
import { NotificationService } from 'src/app/services/notification.service';
import { ContentType } from '../general/generic-form-dialog/generic-content';
import { GenericFormDialogComponent } from '../general/generic-form-dialog/generic-form-dialog.component';
import { Column } from '../general/generic-table/column';
import { GenericTableComponent } from '../general/generic-table/generic-table.component';
import { PageEvent } from '@angular/material/paginator';
import { AuthService } from 'src/app/services/auth.service';
import { Filter } from '../general/generic-filter/filter';


@Component({
  selector: 'app-concert-crew',
  templateUrl: './concert-crew.component.html',
  styleUrls: ['./concert-crew.component.scss']
})
export class ConcertCrewComponent {
  conciertos: Array<any> = new Array<any>();
  artists: Array<any> = new Array<any>();
  conciertosColumns: Column[];
  apiFailing: boolean = false;
  loaded: boolean = false;
  newRowAdded: boolean = false;
  entryBeingEdited: boolean = false;
  pageNumber: number = 1;
  spinner: boolean = false;
  pageSize : number = 10;
  totalConciertos = 50

  @ViewChild(GenericTableComponent) table: GenericTableComponent;
  @ViewChild('ubicacionTemplate') ubicacionTemplate: TemplateRef<any>;

  constructor(
    private _concertService: ConcertService,
    private _notificationService : NotificationService,
    private _authService : AuthService,
    public _dialog: MatDialog,
  ){}

  ngOnInit(){
    this.getConciertos();
  }

  getConciertos() {
    this.spinner = true;
    console.log(this._authService.getUserId());

    this._concertService.getConcertForArtist(this._authService.getUserId()).subscribe(
      (res) => {
        this.handleGetResponse(res);
      },
      (error) => {
        console.log(error);

        this.handleGetErrorResponse();
      }
    );
  }

  setColumns(): void {
    this.conciertosColumns = [
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
      },
      {
        name: 'Fecha',
        dataKey: 'date',
        position: 'left',
        isSortable: false,
        type: ContentType.dateText
      }
    ];
  }

  getUrl(event: any){
    console.log(event);

  }

  private handleGetResponse(res: any) {
    this.conciertos = res;
    this.setColumns();
    this.loaded = true;
    this.spinner = false;
  }

  private handleGetErrorResponse() {
    this._notificationService.showErrorMessage(notifications.LOADING_DATA_FAIL);
    this.apiFailing = false;
    this.spinner = false;
  }

  filterData(filters: Filter[]) {
    this._concertService.getFiltered(filters).subscribe((res) => {
      this.conciertos = res;
    });
  }

  onPaginationChange(PageEvent: PageEvent){
    this.pageNumber = PageEvent.pageIndex + 1;
    this.pageSize = PageEvent.pageSize;
  }
}
