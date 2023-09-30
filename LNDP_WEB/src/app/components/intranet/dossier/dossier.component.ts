import {
  CdkDragDrop,
  moveItemInArray,
  transferArrayItem,
} from '@angular/cdk/drag-drop';
import { Component, TemplateRef, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ContentType } from '../generic-form-dialog/generic-content';
import { Validators } from '@angular/forms';
import { GenericFormDialogComponent } from '../generic-form-dialog/generic-form-dialog.component';
import { DossierService } from '../../../services/intranet/dossier.service';
import { NotificationService } from 'src/app/services/notification.service';
import { notifications } from 'src/app/common/notifications';

@Component({
  selector: 'app-dossier',
  templateUrl: './dossier.component.html',
  styleUrls: ['./dossier.component.scss'],
})
export class DossierComponent {
  photo: any;
  dossiers: Array<any> = new Array<any>();
  spinner: boolean = false;
  dossierLink: any[] = [
    {
      seccion: 'Home',
      seccionUrl: '/Home',
    },
    {
      seccion: 'Marketing',
      seccionUrl: '/Marketing',
    },
    {
      seccion: 'Agency',
      seccionUrl: '/Agency',
    },
    {
      seccion: 'Visual',
      seccionUrl: '/Visual',
    },
    {
      seccion: 'TourManager',
      seccionUrl: '/Tourmanager',
    },
    {
      seccion: 'Artistas y sellos',
      seccionUrl: '/ArtistasSellos',
    },
  ];

  constructor(
    public _dialog: MatDialog,
    private _dossierService: DossierService,
    private _notificationService: NotificationService
  ) {}

  @ViewChild('dossierImageTemplate') crewTemplate: TemplateRef<any>;

  ngOnInit() {
    this.getDossier();
  }

  getDossier() {
    this.spinner = true;
    this._dossierService.get().subscribe({
      next: (res) => {
        let dossier = new Array();
        res.forEach((val) => {
          dossier.push(val);
        });
        this.dossiers = [...dossier];
        this.spinner = false;
      },
      error: (err) => {
        this._notificationService.showMessageOnSnackbar(
          notifications.LOADING_DATA_FAIL,
          'X',
          3500,
          'err-button'
        );
        this.spinner = false;
      },
    });
  }

  drop(event: CdkDragDrop<any[]>) {
    moveItemInArray(this.dossiers, event.previousIndex, event.currentIndex);

    this.dossiers.forEach((item, index) => {
      item.index = index;
    });

    const updatedDossierItems = this.dossiers.map((item) => {
      return {
        id: item.id,
        order: item.index,
        photo: item.photo,
        section: item.section,
      };
    });
    this._dossierService.updateAll(updatedDossierItems).subscribe({
      next: (res) => {;
        this._notificationService.showMessageOnSnackbar(
          res.message,
          'X',
          3500,
          'success-button'
        );
        this.spinner = false;
      },
      error: (err) => {
        this._notificationService.showMessageOnSnackbar(
          notifications.LOADING_DATA_FAIL,
          'X',
          3500,
          'err-button'
        );
        this.spinner = false;
      },
    });
  }

  setDossierForm(): any[] {
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
      },
      {
        name: 'Tipo',
        dataKey: 'section',
        position: { row: 0, col: 1, rowSpan: 1, colSpan: 1 },
        type: ContentType.dropdownFields,
        dropdown: this.dossierLink,
        dropdownKeyToShow: 'seccion',
        dropdownKeyValue: 'seccionUrl',
      },
      {
        name: 'Imagen',
        dataKey: 'photo',
        position: { row: 1, col: 1, rowSpan: 1, colSpan: 2 },
        type: ContentType.imageFile,
      },
    ];
  }

  openAddItemDialog() {
    let dialogData = {
      formData: undefined,
      formFields: this.setDossierForm(),
      formCols: 2,
      dialogTitle: 'Añade una nueva imagen',
    };
    const dialogRef = this._dialog.open(GenericFormDialogComponent, {
      data: dialogData,
      minWidth: 600,
    });
    dialogRef.afterClosed().subscribe((result) => {
      if (result !== undefined && result !== null && result !== '') {
        console.log(result);

        this.convertImage(result.photo);
        this._dossierService
          .postImage(result.section, this.photo)
          .subscribe((res) => {
            this.getDossier();
          });
      }
    });
  }
  convertImage(urlImage) {
    const matches = urlImage.match(/^data:([A-Za-z-+\/]+);base64,(.+)$/);
    if (!matches || matches.length !== 3) {
      throw new Error('La representación en base64 es incorrecta.');
    }
    const mimeType = matches[1];
    const base64Data = matches[2];
    const byteCharacters = atob(base64Data);
    const byteNumbers = new Array(byteCharacters.length);
    for (let i = 0; i < byteCharacters.length; i++) {
      byteNumbers[i] = byteCharacters.charCodeAt(i);
    }
    const byteArray = new Uint8Array(byteNumbers);
    const blob = new Blob([byteArray], { type: mimeType });
    const originalFileName = this.generarNombreUnico('image');
    this.photo = new File([blob], originalFileName, { type: mimeType });
  }

  generarNombreUnico(nombreOriginal: string): string {
    const fechaActual = new Date();
    const timestamp = fechaActual.getTime();
    const nombreSinExtension = nombreOriginal.replace(/\.[^/.]+$/, '');
    const extension = nombreOriginal.split('.').pop();
    const nombreUnico = `${nombreSinExtension}_${timestamp}.jpg`;
    return nombreUnico;
  }

  deleteDossier(id: number) {
    this._dossierService.delete(id).subscribe((res) => {
      console.log(res);
      this.getDossier();
    });
  }
}
