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

@Component({
  selector: 'app-social-netwok-admin',
  templateUrl: './social-netwok-admin.component.html',
  styleUrls: ['./social-netwok-admin.component.scss'],
})
export class SocialNetwokAdminComponent {
  socialNetworks: Array<any> = new Array<any>();
  artists: Array<any> = new Array<any>();
  artistsWithoutSN: Array<any> = new Array<any>();
  socialNetworkColumns: Column[];
  socialNetworkForm: GenericForm[];
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
    this.getArtist();
    this.getArtistWithoutSN();
    this.getSocialNetworks();
    this.setSocialNetworkForm();
  }


  getArtistWithoutSN() {
    this.artistService.getArtistWithoutSN().subscribe((res) => {
      console.log(res);
      let artist = new Array();
      res.forEach((val) => {
        artist.push(val);
      });
      this.artistsWithoutSN = [...artist];
      this.socialNetworkForm.find(s => s.name == "Artista").dropdown = this.artistsWithoutSN
    });
  }

  getArtist() {
    this.artistService.get().subscribe((res) => {
      console.log(res);
      let artist = new Array();
      res.forEach((val) => {
        artist.push(val);
      });
      this.artists = [...artist];
    });
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
        name: 'Artista',
        dataKey: 'artistId',
        position: 'left',
        isEditable: true,
        hidden: false,
        type: ContentType.dropdownFields,
        dropdown: this.artists,
        dropdownKeyToShow : 'name',
        dropdownKeyValue : 'id'
      },
      {
        name: 'instagram',
        dataKey: 'instagram',
        position: 'left',
        isSortable: true,
        isEditable: true,
        hidden: false,
        type: ContentType.editableTextFields,
      },
      {
        name: 'youtube',
        dataKey: 'youtube',
        position: 'left',
        isSortable: false,
        isEditable: true,
        type: ContentType.editableTextFields,
      },
      {
        name: 'spotify',
        dataKey: 'spotify',
        position: 'left',
        isSortable: false,
        isEditable: true,
        type: ContentType.editableTextFields,
      },
      {
        name: 'TikTok',
        dataKey: 'tikTok',
        position: 'left',
        isSortable: false,
        isEditable: true,
        type: ContentType.editableTextFields,
      },
      {
        name: 'Twitter',
        dataKey: 'twitter',
        position: 'left',
        isSortable: false,
        isEditable: true,
        type: ContentType.editableTextFields,
      },
    ];
  }

  filterData(filters : Filter[]){
    this.socialNetwokService.getFiltered(filters).subscribe(res =>{
      this.socialNetworks = res
    })
  }

  setSocialNetworkForm() {
    this.socialNetworkForm = [
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
        dropdown: this.artistsWithoutSN,
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
      formFields: this.socialNetworkForm,
      formCols: 2,
      dialogTitle: 'Añade una nueva red social',
    };
    const dialogRef = this.dialog.open(GenericFormDialogComponent, {
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

  sortData(sortParameters: Sort) {
    const keyName = sortParameters.active;
    if (sortParameters.direction === 'asc') {
      this.socialNetworks = [
        ...this.socialNetworks.sort((a, b) =>
          this.collator.compare(a[keyName], b[keyName])
        ),
      ];
    } else if (sortParameters.direction === 'desc') {
      this.socialNetworks = [
        ...this.socialNetworks.sort(
          (a, b) => -1 * this.collator.compare(a[keyName], b[keyName])
        ),
      ];
    } else {
      this.getSocialNetworks();
    }
  }

  updateElement(event: any) {
    this.socialNetwokService.update(event.id, event).subscribe(
      (res) => {
        this.getSocialNetworks();
        this.notificationService.showMessageOnSnackbar(
          notifications.ENTRY_SAVED_SUCCESSFULLY,
          'OK!',
          3500,
          'succes-button'
        );
        this.apiFailing = false;
      },
      (err) => {
        this.notificationService.showMessageOnSnackbar(
          notifications.ENTRY_NOT_SAVED,
          'KO!',
          3500,
          'succes-button'
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
          notifications.ENTRY_DELETED_SUCCESSFULLY,
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
          notifications.ENTRY_NOT_DELETED,
          'KO!',
          3500,
          'succes-button'
        );
        this.apiFailing = true;
      }
    );
  }

  createElement(event: any) {
    event.id = 0;
    this.socialNetwokService.create(event).subscribe(
      (res) => {
        this.getSocialNetworks();
        this.getArtistWithoutSN();
        this.notificationService.showMessageOnSnackbar(
          notifications.ENTRY_CREATED_SUCCESSFULLY,
          'OK!',
          3500,
          'succes-button'
        );
        this.apiFailing = false;
      },
      (err) => {
        this.notificationService.showMessageOnSnackbar(
          notifications.ENTRY_NOT_CREATED,
          'KO!',
          3500,
          'succes-button'
        );
        this.apiFailing = true;
      }
    );
  }

  updatePageNumber(pageNum: number) {
    this.pageNumber = pageNum;
  }
}
