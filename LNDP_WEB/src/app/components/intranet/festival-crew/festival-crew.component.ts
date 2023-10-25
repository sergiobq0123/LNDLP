import { Component, TemplateRef, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { notifications } from 'src/app/common/notifications';
import { AuthService } from 'src/app/services/auth.service';
import { NotificationService } from 'src/app/services/notification.service';
import { ContentType } from '../general/generic-form-dialog/generic-content';
import { Column } from '../general/generic-table/column';
import { GenericTableComponent } from '../general/generic-table/generic-table.component';
import { PageEvent } from '@angular/material/paginator';
import { FestivalArtistAsocService } from 'src/app/services/intranet/festival-artist-asoc.service';
import { Filter } from '../general/generic-filter/filter';
import { Sort } from '@angular/material/sort';

@Component({
  selector: 'app-festival-crew',
  templateUrl: './festival-crew.component.html',
  styleUrls: ['./festival-crew.component.scss'],
})
export class FestivalCrewComponent {
  entries: Array<any> = new Array<any>();
  artists: Array<any> = new Array<any>();
  columns: Column[];
  apiFailing: boolean = false;
  loaded: boolean = false;
  newRowAdded: boolean = false;
  entryBeingEdited: boolean = false;
  pageNumber: number = 1;
  spinner: boolean = false;
  pageSize: number = 10;
  totalRecords: number;
  filters: Filter[];
  sortBy: string;
  sortOrder: string;

  @ViewChild(GenericTableComponent) table: GenericTableComponent;
  @ViewChild('ubicacionTemplate') ubicacionTemplate: TemplateRef<any>;

  constructor(
    private _festivalArtistAsocService: FestivalArtistAsocService,
    private _notificationService: NotificationService,
    private _authService: AuthService,
    public _dialog: MatDialog
  ) {}

  ngOnInit() {
    this.getfestivales();
  }

  getfestivales() {
    this.spinner = true;
    this._festivalArtistAsocService
      .getFestivalForArtist(
        this._authService.getUserId(),
        this.pageNumber,
        this.pageSize,
        this.sortBy,
        this.sortOrder,
        this.filters
      )
      .subscribe(
        (res) => {
          this.handleGetResponse(res);
        },
        (error) => {
          this.handleGetErrorResponse();
        }
      );
  }

  setColumns(): void {
    this.columns = [
      {
        name: 'Nombre',
        dataKey: 'festival.name',
        position: 'left',
        isSortable: true,
        type: ContentType.plainText,
      },
      {
        name: 'Ciudad',
        dataKey: 'festival.city',
        position: 'left',
        isSortable: true,
        type: ContentType.plainText,
      },
      {
        name: 'Localizacion',
        dataKey: 'festival.location',
        position: 'left',
        isSortable: true,
        type: ContentType.plainText,
      },
      {
        name: 'Fecha',
        dataKey: 'festival.date',
        position: 'left',
        isSortable: true,
        width: '200px',
        type: ContentType.dateText,
      },
    ];
  }

  private handleGetResponse(res: any) {
    this.entries = res.data;
    this.totalRecords = res.totalEntries;
    this.setColumns();
    this.loaded = true;
    this.spinner = false;
  }

  private handleGetErrorResponse() {
    this._notificationService.showErrorMessage(notifications.LOADING_DATA_FAIL);
    this.apiFailing = false;
    this.spinner = false;
  }

  onPaginationChange(PageEvent: PageEvent) {
    this.pageNumber = PageEvent.pageIndex + 1;
    this.pageSize = PageEvent.pageSize;
    this.getfestivales();
  }

  sortData(sortParameters: Sort) {
    this.sortBy = sortParameters.active;
    this.sortOrder = sortParameters.direction;
    this.pageNumber = 1;
    this.getfestivales();
  }

  filterData(filters: Filter[]) {
    (this.filters = filters),
      (this.pageNumber = 1),
      (this.sortBy = null),
      (this.sortOrder = null),
      this.getfestivales();
  }
}
