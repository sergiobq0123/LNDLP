import { Component, TemplateRef, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { notifications } from 'src/app/common/notifications';
import { AuthService } from 'src/app/services/auth.service';
import { ConcertService } from 'src/app/services/intranet/concert.service';
import { NotificationService } from 'src/app/services/notification.service';
import { Filter } from '../general/generic-filter/filter';
import { ContentType } from '../general/generic-form-dialog/generic-content';
import { Column } from '../general/generic-table/column';
import { GenericTableComponent } from '../general/generic-table/generic-table.component';
import { PageEvent } from '@angular/material/paginator';
import { FestivalService } from 'src/app/services/intranet/festival.service';
import { FestivalArtistAsocService } from 'src/app/services/intranet/festival-artist-asoc.service';

@Component({
  selector: 'app-festival-crew',
  templateUrl: './festival-crew.component.html',
  styleUrls: ['./festival-crew.component.scss']
})
export class FestivalCrewComponent {
  festivales: Array<any> = new Array<any>();
  artists: Array<any> = new Array<any>();
  festivalesColumns: Column[];
  apiFailing: boolean = false;
  loaded: boolean = false;
  newRowAdded: boolean = false;
  entryBeingEdited: boolean = false;
  pageNumber: number = 1;
  spinner: boolean = false;
  pageSize : number = 10;
  totalfestivales = 50

  @ViewChild(GenericTableComponent) table: GenericTableComponent;
  @ViewChild('ubicacionTemplate') ubicacionTemplate: TemplateRef<any>;

  constructor(
    private _festivalArtistAsocService: FestivalArtistAsocService,
    private _notificationService : NotificationService,
    private _authService : AuthService,
    public _dialog: MatDialog,
  ){}

  ngOnInit(){
    this.getfestivales();
  }

  getfestivales() {
    this.spinner = true;
    console.log(this._authService.getUserId());

    this._festivalArtistAsocService.getFestivalForArtist(this._authService.getUserId()).subscribe(
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
    this.festivalesColumns = [
      {
        name: 'Nombre',
        dataKey: 'festival.name',
        position: 'left',
        isSortable: false,
        type: ContentType.plainText,
      },
      {
        name: 'Ciudad',
        dataKey: 'festival.city',
        position: 'left',
        isSortable: false,
        type: ContentType.plainText,
      },
      {
        name: 'Localizacion',
        dataKey: 'festival.location',
        position: 'left',
        isSortable: false,
        type: ContentType.plainText,
      },
      {
        name: 'Fecha',
        dataKey: 'festival.date',
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
    this.festivales = res;
    this.setColumns();
    this.loaded = true;
    this.spinner = false;
  }

  private handleGetErrorResponse() {
    this._notificationService.showErrorMessage(notifications.LOADING_DATA_FAIL);
    this.apiFailing = false;
    this.spinner = false;
  }

  onPaginationChange(PageEvent: PageEvent){
    this.pageNumber = PageEvent.pageIndex + 1;
    this.pageSize = PageEvent.pageSize;
  }
}
