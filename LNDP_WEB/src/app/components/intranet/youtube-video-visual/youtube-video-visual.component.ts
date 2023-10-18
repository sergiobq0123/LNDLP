import { Component, TemplateRef, ViewChild } from '@angular/core';
import { Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { notifications } from 'src/app/common/notifications';
import { YoutubeVideoService } from 'src/app/services/intranet/youtube-video.service';
import { NotificationService } from 'src/app/services/notification.service';
import { GenericForm, ContentType } from '../general/generic-form-dialog/generic-content';
import { GenericFormDialogComponent } from '../general/generic-form-dialog/generic-form-dialog.component';
import { GenericTableComponent } from '../general/generic-table/generic-table.component';
import { PageEvent } from '@angular/material/paginator';
import { Filter } from '../general/generic-filter/filter';
import { Column } from '../general/generic-table/column';
import { IconButton } from '../general/generic-table/icon-button';
import { faPlus } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-youtube-video-visual',
  templateUrl: './youtube-video-visual.component.html',
  styleUrls: ['./youtube-video-visual.component.scss']
})
export class YoutubeVideoVisualComponent {
  videos: Array<any> = new Array<any>();
  videoColumns: Column[];
  videoForm: GenericForm[];
  apiFailing: boolean = false;
  loaded: boolean = false;
  newRowAdded: boolean = false;
  entryBeingEdited: boolean = false;
  pageNumber: number = 1;
  spinner: boolean = false;
  pageSize : number = 10;
  totalVideos = 50
  iconButtons : IconButton[] = []

  @ViewChild(GenericTableComponent) table: GenericTableComponent;
  @ViewChild('addTemplate') addTemplate: TemplateRef<any>;

  faPlus = faPlus;

  constructor(
    public _youtubeVideoService : YoutubeVideoService,
    public _dialog: MatDialog,
    public _notificationService: NotificationService
  ) {}

  ngOnInit() {
    this.getvideos();
  }

  ngAfterViewInit(){
    this.setIconsButtons()
  }

  setIconsButtons() {
    this.iconButtons = [
      {
        template: this.addTemplate,
        isLeft: true,
      }
    ];
  }

  getvideos() {
    this.spinner = true;
    this._youtubeVideoService.get().subscribe(
      (res) => {
        console.log(res);

        this.handleGetResponse(res);
      },
      (error) => {
        this.handleGetErrorResponse();
      }
    );
  }


  setColumns(): void {
    this.videoColumns = [
      {
        name: '_id',
        dataKey: 'id',
        hidden: true,
      },
      {
        name: 'Nombre',
        dataKey: 'name',
        position: 'left',
        isSortable: true,
        hidden: false,
        type: ContentType.editableTextFields,
        validators: [Validators.required]
      },
      {
        name: 'Url',
        dataKey: 'url',
        position: 'left',
        isSortable: false,
        type: ContentType.editableTextFields,
        validators: [Validators.required]
      },
    ];
  }

  setvideoForm(): any[] {
    return [
      {
        name: 'Id',
        dataKey: 'id',
        hidden: true,
      },
      {
        name: 'Nombre',
        dataKey: 'name',
        position: { row: 0, col: 0, rowSpan: 1, colSpan: 1 },
        type: ContentType.editableTextFields,
        validators: [Validators.required]
      },
      {
        name: 'URL',
        dataKey: 'url',
        position: { row: 1, col: 0, rowSpan: 1, colSpan: 1 },
        type: ContentType.editableTextFields,
        validators: [Validators.required]
      }
    ];
  }

  showFormDialog() {
    let dialogData = {
      formData: undefined,
      formFields: this.setvideoForm(),
      formCols: 2,
      dialogTitle: 'Añade un nuevo video',
    };
    const dialogRef = this._dialog.open(GenericFormDialogComponent, {
      data: dialogData,
      minWidth: 600,
    });
    dialogRef.afterClosed().subscribe((result) => {
      if (result !== undefined && result !== null && result !== '') {
        this.createElement(result);
      }
    });
  }

  createElement(event: any) {
    event.id = 0;
    this._youtubeVideoService.create(event).subscribe(
      (res) => {this.handleResponse(res.message)},
      (err) => {this.handleErrorResponse(err.error.message)}
    );
  }

  updateElement(event: any) {
    this._youtubeVideoService.update(event.id, event).subscribe(
      (res) => {this.handleResponse(res.message)},
      (err) => {this.handleErrorResponse(err.error.message)}
    );
  }

  deleteElement(event: any) {
    this._youtubeVideoService.delete(event.id).subscribe(
      (res) => {this.handleResponse(res.message)},
      (err) => {this.handleErrorResponse(err.error.message)}
    );
  }

  private handleGetResponse(res: any) {
    this.videos = res;
    this.setColumns();
    this.loaded = true;
    this.spinner = false;
  }

  private handleGetErrorResponse() {
    this._notificationService.showErrorMessage(notifications.LOADING_DATA_FAIL);
    this.apiFailing = false;
    this.spinner = false;
  }

  private handleResponse(message: string) {
    this.getvideos();
    this._notificationService.showOkMessage(message);
    this.apiFailing = false;
    if (this.table.tableDataSource.data.length === 1) {
      this.table.setTableDataSource();
    }
  }

  private handleErrorResponse(message: string) {
    this._notificationService.showErrorMessage(message);
    this.apiFailing = true;
  }

  filterData(filters: Filter[]) {
    this._youtubeVideoService.getFiltered(filters).subscribe((res) => {
      this.videos = res;
    });
  }

  onPaginationChange(PageEvent: PageEvent){
    this.pageNumber = PageEvent.pageIndex + 1;
    this.pageSize = PageEvent.pageSize;
  }
}