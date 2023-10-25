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
import { Sort } from '@angular/material/sort';

@Component({
  selector: 'app-concert-crew',
  templateUrl: './concert-crew.component.html',
  styleUrls: ['./concert-crew.component.scss'],
})
export class ConcertCrewComponent {
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
    private _concertService: ConcertService,
    private _notificationService: NotificationService,
    private _authService: AuthService,
    public _dialog: MatDialog
  ) {}

  ngOnInit() {
    this.getConciertos();
  }

  getConciertos() {
    this.spinner = true;
    this._concertService
      .getConcertForArtist(
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
        name: 'Localizacion',
        dataKey: 'location',
        position: 'left',
        isSortable: true,
        type: ContentType.plainText,
      },
      {
        name: 'Fecha',
        dataKey: 'date',
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
    this.getConciertos();
  }

  sortData(sortParameters: Sort) {
    this.sortBy = sortParameters.active;
    this.sortOrder = sortParameters.direction;
    this.pageNumber = 1;
    this.getConciertos();
  }

  filterData(filters: Filter[]) {
    (this.filters = filters),
      (this.pageNumber = 1),
      (this.sortBy = null),
      (this.sortOrder = null),
      this.getConciertos();
  }
}
