import { Component, ViewChild } from '@angular/core';
import { Column } from '../generic-table/column';
import { ContentType, GenericForm } from '../generic-form-dialog/generic-content';
import { Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { Sort } from '@angular/material/sort';
import { notifications } from 'src/app/common/notifications';
import { ArtistService } from 'src/app/services/intranet/artist.service';
import { SocialNetworkService } from 'src/app/services/intranet/social-network.service';
import { NotificationService } from 'src/app/services/notification.service';
import { GenericFormDialogComponent } from '../generic-form-dialog/generic-form-dialog.component';
import { GenericTableComponent } from '../generic-table/generic-table.component';
import { CrewService } from 'src/app/services/intranet/crew.service';
import { Filter } from '../generic-table/Filter';

@Component({
  selector: 'app-crew-admin',
  templateUrl: './crew-admin.component.html',
  styleUrls: ['./crew-admin.component.scss']
})
export class CrewAdminComponent {
  crew: Array<any> = new Array<any>();
  crewColumns: Column[];
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
    private crewService: CrewService,
    private artistService: ArtistService,
    public dialog: MatDialog,
    private notificationService: NotificationService
  ) {}

  ngOnInit() {
    this.getCrew();
  }

  getCrew() {
    this.crewService.get().subscribe((res) => {
      console.log(res);

      let crew = new Array();
      res.forEach((val) => {
        crew.push(val);
      });
      this.crew = [...crew];
      this.setColumns();
      this.loaded = true;
    });
  }

  setColumns(): void {
    this.crewColumns = [
      {
        name: '_id',
        dataKey: 'id',
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
        name: 'DJ',
        dataKey: 'dj',
        position: 'left',
        isSortable: true,
        hidden: false,
        type: ContentType.editableTextFields,
      },
      {
        name: 'Road Manager',
        dataKey: 'roadManager',
        position: 'left',
        isSortable: false,
        type: ContentType.editableTextFields,
      },
      {
        name: 'Tecnico de sonido',
        dataKey: 'soundTechnician',
        position: 'left',
        isSortable: false,
        type: ContentType.editableTextFields,
      },
      {
        name: 'Tecnico de luces',
        dataKey: 'lightingTechnician',
        position: 'left',
        isSortable: false,
        type: ContentType.editableTextFields,
      },
    ];
  }

  getArtistWithoutC(): any[] {
    var artistWithotCrew: any [] = [];
    this.artistService.getArtistWithoutC().subscribe((res) => {
      res.forEach((val) => {
        artistWithotCrew.push(val);
      });
    });
    return artistWithotCrew;
  }

  setCrewForm(): any[] {
    return [
      {
        name: 'Id',
        dataKey: 'id',
        hidden: true,
      },
      {
        name: 'Artista',
        dataKey: 'artistId',
        position: {row : 0, col : 0, rowSpan : 1, colSpan : 1},
        hidden: false,
        type: ContentType.dropdownFields,
        dropdown: this.getArtistWithoutC(),
        dropdownKeyToShow : 'name',
        dropdownKeyValue : 'id'
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
      formData: undefined,
      formFields: this.setCrewForm(),
      formCols: 2,
      dialogTitle: 'Añade un nuevo equipo',
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
      this.crew = [
        ...this.crew.sort((a, b) =>
          this.collator.compare(a[keyName], b[keyName])
        ),
      ];
    } else if (sortParameters.direction === 'desc') {
      this.crew = [
        ...this.crew.sort(
          (a, b) => -1 * this.collator.compare(a[keyName], b[keyName])
        ),
      ];
    } else {
      this.getCrew();
    }
  }

  updateElement(event: any) {
    this.crewService.update(event.id, event).subscribe(
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
          'succes-button'
        );
        this.apiFailing = true;
      }
    );
  }

  deleteElement(event: any) {
    this.crewService.delete(event.id).subscribe(
      (res) => {
        this.getCrew();
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
    event.id = 0;
    this.crewService.create(event).subscribe(
      (res) => {
        this.getCrew();
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
    this.crewService.getFiltered(filters).subscribe(res =>{
      this.crew = res
    })
  }

  updatePageNumber(pageNum: number) {
    this.pageNumber = pageNum;
  }
}