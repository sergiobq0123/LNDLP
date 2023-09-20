import { Component, ViewChild } from '@angular/core';
import { Column } from '../generic-table/column';
import {
  ContentType,
  GenericForm,
} from '../generic-form-dialog/generic-content';
import { Sort } from '@angular/material/sort';
import { MatDialog } from '@angular/material/dialog';
import { NotificationService } from 'src/app/services/notification.service';
import { SocialNetworkService } from 'src/app/services/intranet/social-network.service';
import { notifications } from 'src/app/common/notifications';
import { GenericTableComponent } from '../generic-table/generic-table.component';
import { Validators } from '@angular/forms';
import { GenericFormDialogComponent } from '../generic-form-dialog/generic-form-dialog.component';
import { ArtistService } from 'src/app/services/intranet/artist.service';
import { Filter } from '../generic-table/Filter';
import { Artist } from 'src/app/models/artist.model';
import { SocialNetwork } from '../../models/socialNetwork.model';

@Component({
  selector: 'app-social-netwok-admin',
  templateUrl: './social-netwok-admin.component.html',
  styleUrls: ['./social-netwok-admin.component.scss'],
})
export class SocialNetwokAdminComponent {
  socialNetworks: Array<any> = new Array<any>();
  socialNetworkColumns: Column[];
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

  @ViewChild(GenericTableComponent) table: GenericTableComponent;

  constructor(
    private socialNetwokService: SocialNetworkService,
    private artistService: ArtistService,
    public dialog: MatDialog,
    private notificationService: NotificationService
  ) {}

  ngOnInit() {
    this.getSocialNetworks();
  }

  getSocialNetworks() {
    this.socialNetwokService.get().subscribe((res) => {
     let socialNetworks = new Array();
      res.forEach((val) => {
        socialNetworks.push(val);
      });
      this.socialNetworks = [...socialNetworks];
      this.setColumns();
      this.loaded = true;
    });
  }

  setColumns(): void {
    this.socialNetworkColumns = [
      {
        name: '_id',
        dataKey: 'id',
        hidden: true,
      },
      {
        name: '_idArtista',
        dataKey: 'artistId',
        hidden: true,
      },
      {
        name: 'Artista',
        dataKey: 'artist.name',
        position: 'left',
        hidden: false,
        type: ContentType.plainText
      },
      {
        name: 'Instagram',
        dataKey: 'instagram',
        position: 'left',
        isSortable: true,
        hidden: false,
        type: ContentType.editableTextFields,
      },
      {
        name: 'YouTube',
        dataKey: 'youtube',
        position: 'left',
        isSortable: false,
        type: ContentType.editableTextFields,
      },
      {
        name: 'Spotify',
        dataKey: 'spotify',
        position: 'left',
        isSortable: false,
        type: ContentType.editableTextFields,
      },
      {
        name: 'TikTok',
        dataKey: 'tikTok',
        position: 'left',
        isSortable: false,
        type: ContentType.editableTextFields,
      },
      {
        name: 'Twitter',
        dataKey: 'twitter',
        position: 'left',
        isSortable: false,
        type: ContentType.editableTextFields,
      },
    ];
  }

  getArtistWithoutSN(): any[] {
    var artistWithoutSN: any[] = [];
    this.artistService.getArtistWithoutSN().subscribe((res) => {
      res.forEach((val) => {
        artistWithoutSN.push(val);
      });
    });
    return artistWithoutSN;
  }

  setSocialNetworkForm() : any[]{
    return [
      {
        name: '_id',
        dataKey: 'id',
        hidden: true,
      },
      {
        name: 'Artista',
        dataKey: 'artistId',
        position: {row : 0, col : 0, rowSpan : 1, colSpan : 1},
        hidden: false,
        type: ContentType.dropdownFields,
        dropdown: this.getArtistWithoutSN(),
        dropdownKeyToShow : 'name',
        dropdownKeyValue : 'id'
      },
      {
        name: 'Intagram',
        dataKey: 'instagram',
        position: { row: 0, col: 0, rowSpan: 1, colSpan: 1 },
        type: ContentType.editableTextFields,
        validators: [Validators.required],
      },
      {
        name: 'Spotify',
        dataKey: 'spotify',
        position: { row: 1, col: 0, rowSpan: 1, colSpan: 1 },
        type: ContentType.editableTextFields,
        validators: [Validators.required],
      },
      {
        name: 'TikTok',
        dataKey: 'tikTok',
        position: { row: 2, col: 0, rowSpan: 1, colSpan: 1 },
        type: ContentType.editableTextFields,
        validators: [Validators.required],
      },
      {
        name: 'Twitter',
        dataKey: 'twitter',
        position: { row: 2, col: 2, rowSpan: 1, colSpan: 1 },
        type: ContentType.editableTextFields,
        validators: [Validators.required],
      },
      {
        name: 'Youtube',
        dataKey: 'youtube',
        position: { row: 3, col: 1, rowSpan: 1, colSpan: 1 },
        type: ContentType.editableTextFields,
        validators: [Validators.required],
      },
    ];
  }

  showFormDialog() {
    let dialogData = {
      formData: undefined,
      formFields: this.setSocialNetworkForm(),
      formCols: 2,
      dialogTitle: 'Añade una nueva red social',
    };
    const dialogRef = this.dialog.open(GenericFormDialogComponent, {
      data: dialogData,
      minWidth: 600,
    });
    dialogRef.afterClosed().subscribe((result) => {
      if (result !== undefined && result !== null && result !== '') {
        this.createElement(result);
      }
    });
  }

  updateElement(event: any) {
    console.log(event);

      this.socialNetwokService.update(event.id, event).subscribe(
      (res) => {
        this.notificationService.showMessageOnSnackbar(
          res.message,
          'OK!',
          3500,
          'succes-button'
        );
        this.apiFailing = false;
      },
      (err) => {
        this.notificationService.showMessageOnSnackbar(
          err.error.message,
          'ERROR!',
          3500,
          'err-button'
        );
        this.apiFailing = true;
      }
    );
  }

  deleteElement(event: any) {

    this.socialNetwokService.delete(event.id).subscribe(
      (res) => {
        this.getSocialNetworks();
        this.notificationService.showMessageOnSnackbar(
          res.message,
          'OK!',
          3500,
          'succes-button'
        );
        this.apiFailing = false;
        if (this.table.tableDataSource.data.length === 1) {
          this.table.setTableDataSource();
        }
      },
      (err) => {
        this.notificationService.showMessageOnSnackbar(
          err.error.message,
          'ERROR!',
          3500,
          'err-button'
        );
        this.apiFailing = true;
      }
    );
  }

  createElement(event: any) {
    console.log(event);

    event.id = 0;
    this.socialNetwokService.create(event).subscribe(
      (res) => {
        this.getSocialNetworks();
        this.notificationService.showMessageOnSnackbar(
          res.message,
          'OK!',
          3500,
          'succes-button'
        );
        this.apiFailing = false;
      },
      (err) => {
        this.notificationService.showMessageOnSnackbar(
          err.error.message,
          'ERROR!',
          3500,
          'err-button'
        );
        this.apiFailing = true;
      }
    );
  }

  filterData(filters : Filter[]){
    this.socialNetwokService.getFiltered(filters).subscribe(res =>{
      this.socialNetworks = res
    })
  }

  updatePageNumber(pageNum: number) {
    this.pageNumber = pageNum;
  }
}
