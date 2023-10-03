import { Component, TemplateRef, ViewChild } from '@angular/core';
import { Sort } from '@angular/material/sort';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { NotificationService } from 'src/app/services/notification.service';
import {
  ContentType,
  GenericForm,
} from '../generic-form-dialog/generic-content';
import { Column } from '../generic-table/column';
import { ArtistService } from 'src/app/services/intranet/artist.service';
import { Validators } from '@angular/forms';
import { GenericFormDialogComponent } from '../generic-form-dialog/generic-form-dialog.component';
import { MatTableDataSource } from '@angular/material/table';
import { GenericTableComponent } from '../generic-table/generic-table.component';
import { Filter } from '../generic-table/Filter';
import { SocialNetworkService } from 'src/app/services/intranet/social-network.service';
import { CrewService } from 'src/app/services/intranet/crew.service';
import { notifications } from 'src/app/common/notifications';
import { PageEvent } from '@angular/material/paginator';

@Component({
  selector: 'app-artist-admin',
  templateUrl: './artist-admin.component.html',
  styleUrls: ['./artist-admin.component.scss'],
})
export class ArtistAdminComponent {
  artists: Array<any> = new Array<any>();
  socialNetwork: Array<any> = new Array<any>();
  artistColumns: Column[];
  artistForm: GenericForm[];
  artistData: GenericForm[];
  socialNetworkForm: GenericForm[];
  crewForm: GenericForm[];
  pageNumber: number = 1;
  loaded: boolean = false;
  newRowAdded: boolean = false;
  entryBeingEdited: boolean = false;
  apiFailing: boolean = false;
  collator = new Intl.Collator(undefined, {
    numeric: true,
    sensitivity: 'base',
  });
  spinner: boolean = false;
  pageSize : number = 10;
  totalArtist = 50

  @ViewChild(GenericTableComponent) table: GenericTableComponent;
  @ViewChild('crewTemplate') crewTemplate: TemplateRef<any>;
  @ViewChild('socialNetworkTemplate') socialNetworkTemplate: TemplateRef<any>;

  constructor(
    public _artistService: ArtistService,
    public _dialog: MatDialog,
    private _notificationService: NotificationService,
    private _socialNetworkService : SocialNetworkService,
    private _crewService : CrewService,
  ) {}

  ngOnInit() {
    this.getArtist();
    this.setArtistForm();
    this.setSocialNetworkForm();
    this.setCrewForm();
  }

  getArtist() {
    this.spinner = true;
    this._artistService.get().subscribe({
      next: res => {
        let artists = new Array();
        res.forEach((val) => {
          artists.push(val);
        });
        this.artists = [...artists];
        this.setColumns();
        this.spinner = false
        this.loaded = true;
      },
      error : err => {
        this._notificationService.showMessageOnSnackbar(notifications.LOADING_DATA_FAIL, 'X', 3500, 'err-button');
        this.apiFailing = false;
        this.spinner = false;
      }
    });
  }

  setColumns(): void {
    this.artistColumns = [
      {
        name: '_id',
        dataKey: 'id',
        hidden: true,
      },
      {
        name: '_photo',
        dataKey: 'photo',
        hidden: true,
      },
      {
        name: '_userId',
        dataKey: 'userId',
        hidden: true,
      },
      {
        name: 'Nombre',
        dataKey: 'name',
        position: 'left',
        isSortable: true,
        hidden: false,
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
        name: 'Email de contratación',
        dataKey: 'recruitmentEmail',
        position: 'left',
        isSortable: false,
        type: ContentType.editableTextFields,
      },
      {
        name: 'Email de comunicación',
        dataKey: 'communicationEmail',
        position: 'left',
        isSortable: false,
        type: ContentType.editableTextFields,
      },
      {
        name: 'Teléfono',
        dataKey: 'phone',
        position: 'left',
        isSortable: false,
        type: ContentType.editableTextFields,
      },
      {
        name: 'Equipo',
        dataKey: 'crew',
        position: 'left',
        isSortable: false,
        type: ContentType.specialContent,
        template: this.crewTemplate,
      },
      {
        name: 'Redes',
        dataKey: 'socialNetwork',
        position: 'left',
        isSortable: false,
        type: ContentType.specialContent,
        template: this.socialNetworkTemplate,
      },
    ];
  }

  setArtistForm() {
    this.artistForm = [
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
        validators: [Validators.required],
      },
      {
        name: 'Ciudad',
        dataKey: 'city',
        position: { row: 1, col: 0, rowSpan: 1, colSpan: 1 },
        type: ContentType.editableTextFields,
        validators: [Validators.required],
      },
      {
        name: 'Email Contratacion',
        dataKey: 'recruitmentemail',
        position: { row: 2, col: 0, rowSpan: 1, colSpan: 1 },
        type: ContentType.editableTextFields,
        validators: [Validators.required],
      },
      {
        name: 'Email Comunicacion',
        dataKey: 'communicationemail',
        position: { row: 2, col: 2, rowSpan: 1, colSpan: 1 },
        type: ContentType.editableTextFields,
        validators: [Validators.required],
      },
      {
        name: 'Telefono',
        dataKey: 'phone',
        position: { row: 3, col: 1, rowSpan: 1, colSpan: 1 },
        type: ContentType.editableTextFields,
        validators: [Validators.required],
      },
      {
        name: 'artistId',
        dataKey: 'artistId',
        hidden: true,
      },
      {
        name: 'Instagram',
        dataKey: 'instagram',
        position: { row: 0, col: 0, rowSpan: 1, colSpan: 1 },
        type: ContentType.editableTextFields,
        validators: [Validators.required],
      },
      {
        name: 'Youtube',
        dataKey: 'youtube',
        position: { row: 1, col: 0, rowSpan: 1, colSpan: 1 },
        type: ContentType.editableTextFields,
        validators: [Validators.required],
      },
      {
        name: 'Spotify',
        dataKey: 'spotify',
        position: { row: 2, col: 0, rowSpan: 1, colSpan: 1 },
        type: ContentType.editableTextFields,
        validators: [Validators.required],
      },
      {
        name: 'TikTok',
        dataKey: 'tikTok',
        position: { row: 2, col: 2, rowSpan: 1, colSpan: 1 },
        type: ContentType.editableTextFields,
        validators: [Validators.required],
      },
      {
        name: 'Twitter',
        dataKey: 'twitter',
        position: { row: 3, col: 1, rowSpan: 1, colSpan: 1 },
        type: ContentType.editableTextFields,
        validators: [Validators.required],
      },
      {
        name: 'DJ',
        dataKey: 'dj',
        position: { row: 0, col: 0, rowSpan: 1, colSpan: 1 },
        type: ContentType.editableTextFields,
      },
      {
        name: 'Road Manager',
        dataKey: 'roadManager',
        position: { row: 1, col: 0, rowSpan: 1, colSpan: 1 },
        type: ContentType.editableTextFields,
      },
      {
        name: 'Tecnico de sonido',
        dataKey: 'soundTechnician',
        position: { row: 2, col: 0, rowSpan: 1, colSpan: 1 },
        type: ContentType.editableTextFields,
        validators: [Validators.required],
      },
      {
        name: 'Tecnico de luces',
        dataKey: 'lightingTechnician',
        position: { row: 2, col: 2, rowSpan: 1, colSpan: 1 },
        type: ContentType.editableTextFields,
        validators: [Validators.required],
      },
    ];
  }

  setSocialNetworkForm() {
    this.socialNetworkForm = [
      {
        name: 'Id',
        dataKey: 'id',
        hidden: true,
      },
      {
        name: 'artistId',
        dataKey: 'artistId',
        hidden: true,
      },
      {
        name: 'Instagram',
        dataKey: 'instagram',
        position: { row: 0, col: 0, rowSpan: 1, colSpan: 1 },
        type: ContentType.editableTextFields,
        validators: [Validators.required],
      },
      {
        name: 'Youtube',
        dataKey: 'youtube',
        position: { row: 1, col: 0, rowSpan: 1, colSpan: 1 },
        type: ContentType.editableTextFields,
        validators: [Validators.required],
      },
      {
        name: 'Spotify',
        dataKey: 'spotify',
        position: { row: 2, col: 0, rowSpan: 1, colSpan: 1 },
        type: ContentType.editableTextFields,
        validators: [Validators.required],
      },
      {
        name: 'TikTok',
        dataKey: 'tikTok',
        position: { row: 2, col: 2, rowSpan: 1, colSpan: 1 },
        type: ContentType.editableTextFields,
        validators: [Validators.required],
      },
      {
        name: 'Twitter',
        dataKey: 'twitter',
        position: { row: 3, col: 1, rowSpan: 1, colSpan: 1 },
        type: ContentType.editableTextFields,
        validators: [Validators.required],
      },
    ];
  }

  setCrewForm() {
    this.crewForm =  [
      {
        name: 'Id',
        dataKey: 'id',
        hidden: true,
      },
      {
        name: 'artistId',
        dataKey: 'artistId',
        hidden: true,
      },
      {
        name: 'DJ',
        dataKey: 'dj',
        position: { row: 0, col: 0, rowSpan: 1, colSpan: 1 },
        type: ContentType.editableTextFields,
      },
      {
        name: 'Road Manager',
        dataKey: 'roadManager',
        position: { row: 1, col: 0, rowSpan: 1, colSpan: 1 },
        type: ContentType.editableTextFields,
      },
      {
        name: 'Tecnico de sonido',
        dataKey: 'soundTechnician',
        position: { row: 2, col: 0, rowSpan: 1, colSpan: 1 },
        type: ContentType.editableTextFields,
        validators: [Validators.required],
      },
      {
        name: 'Tecnico de luces',
        dataKey: 'lightingTechnician',
        position: { row: 2, col: 2, rowSpan: 1, colSpan: 1 },
        type: ContentType.editableTextFields,
        validators: [Validators.required],
      },
    ];
  }

  showFormDialog() {
    let dialogData = {
      formData: this.artistData,
      formFields: this.artistForm,
      formCols: 2,
      dialogTitle: 'Añade un nuevo artista',
    };
    const dialogRef = this._dialog.open(GenericFormDialogComponent, {
      data: dialogData,
      minWidth: 600,
    });
    dialogRef.afterClosed().subscribe((result) => {
      if (result !== undefined && result !== null && result !== '') {
        console.log(result);
        this.createElement(result);
      }
    });
  }

  showFormDialogSocialNetwork(dataShow: any) {
    let dialogData = {
      formData: dataShow,
      formFields: this.socialNetworkForm,
      formCols: 2,
      dialogTitle: 'Red Social',
    };
    const dialogRef = this._dialog.open(GenericFormDialogComponent, {
      data: dialogData,
      minWidth: 600,
    });
    dialogRef.afterClosed().subscribe((result) => {
      if (result !== undefined && result !== null && result !== '') {
        console.log(result);
        this.updateElement(this._socialNetworkService, result);
      }
    });
  }

  showFormDialogCrew(dataShow: any) {
    console.log(dataShow);
    let dialogData = {
      formData: dataShow,
      formFields: this.crewForm,
      formCols: 2,
      dialogTitle: 'Equipo',
    };
    const dialogRef = this._dialog.open(GenericFormDialogComponent, {
      data: dialogData,
      minWidth: 600,
    });
    dialogRef.afterClosed().subscribe((result) => {
      if (result !== undefined && result !== null && result !== '') {
        console.log(result);
        this.updateElement(this._crewService,result);
      }
    });
  }

  sortData(sortParameters: Sort) {
    const keyName = sortParameters.active;
    if (sortParameters.direction === 'asc') {
      this.artists = [
        ...this.artists.sort((a, b) =>
          this.collator.compare(a[keyName], b[keyName])
        ),
      ];
    } else if (sortParameters.direction === 'desc') {
      this.artists = [
        ...this.artists.sort(
          (a, b) => -1 * this.collator.compare(a[keyName], b[keyName])
        ),
      ];
    } else {
      this.getArtist();
    }
  }

  updateElement(service : any ,event: any) {
    service.update(event.id, event).subscribe(
      (res) => {
        this.getArtist();
        this._notificationService.showMessageOnSnackbar(
          res.message,
          'OK!',
          3500,
          'success-button'
        );
        this.apiFailing = false;
      },
      (err) => {
        this._notificationService.showMessageOnSnackbar(
          err.error.message,
          'KO!',
          3500,
          'err-button'
        );
        this.apiFailing = true;
      }
    );
  }

  deleteElement(event: any) {
    this._artistService.delete(event.id).subscribe(
      (res) => {
        this.getArtist();
        this._notificationService.showMessageOnSnackbar(
          res.message,
          'OK!',
          350000,
          'success-button'
        );
        this.apiFailing = false;
        if (this.table.tableDataSource.data.length === 1) {
          this.table.setTableDataSource();
        }
      },
      (err) => {
        this._notificationService.showMessageOnSnackbar(
          err.error.message,
          'KO!',
          3500,
          'err-button'
        );
        this.apiFailing = true;
      }
    );
  }

  filterData(filters: Filter[]) {
    this._artistService.getFiltered(filters).subscribe((res) => {
      this.artists = res;
    });
  }

  createElement(event: any) {
    event.id = 0;
    this._artistService.create(event).subscribe(
      (res) => {
        this.getArtist();
        this._notificationService.showMessageOnSnackbar(
          res.message,
          'OK!',
          3500,
          'success-button'
        );
        this.apiFailing = false;
      },
      (err) => {
        this._notificationService.showMessageOnSnackbar(
          err.error.message,
          'ERROr!',
          3500,
          'err-button'
        );
        this.apiFailing = true;
      }
    );
  }

  onPaginationChange(PageEvent: PageEvent){
    this.pageNumber = PageEvent.pageIndex + 1;
    this.pageSize = PageEvent.pageSize;
    this.getArtist();
  }
}
