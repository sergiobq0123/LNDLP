import { Component, ViewChild } from '@angular/core';
import { Sort } from '@angular/material/sort';
import {
  ContentType,
  GenericForm,
} from '../generic-form-dialog/generic-content';
import { NotificationService } from 'src/app/services/notification.service';
import { MatDialog } from '@angular/material/dialog';
import { Column } from '../generic-table/column';
import { UsersService } from 'src/app/services/intranet/users.service';
import { GenericTableComponent } from '../generic-table/generic-table.component';
import { Validators } from '@angular/forms';
import { notifications } from 'src/app/common/notifications';
import { GenericFormDialogComponent } from '../generic-form-dialog/generic-form-dialog.component';
import { Filter } from '../generic-table/Filter';

@Component({
  selector: 'app-user-admin',
  templateUrl: './user-admin.component.html',
  styleUrls: ['./user-admin.component.scss'],
})
export class UserAdminComponent {
  users: Array<any> = new Array<any>();
  usersColumns: Column[];
  usersForm: GenericForm[];
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
    private userService: UsersService,
    public dialog: MatDialog,
    private notificationService: NotificationService
  ) {}

  ngOnInit() {
    this.getUsers();
    this.setUserForm();
  }

  getUsers() {
    this.userService.get().subscribe((res) => {
      console.log(res);

      let users = new Array();
      res.forEach((val) => {
        users.push(val);
      });
      this.users = [...users];
      this.setColumns();
      this.loaded = true;
    });
  }

  filterData(filters : Filter[]){
    this.userService.getFiltered(filters).subscribe(res =>{
      this.users = res
    })
  }

  setColumns(): void {
    this.usersColumns = [
      {
        name: '_id',
        dataKey: 'id',
        hidden: true
      },
      {
        name: 'username',
        dataKey: 'username',
        position: 'left',
        isSortable: true,
        isEditable: true,
        hidden: false,
        type: ContentType.editableTextFields,
      },
      {
        name: 'email',
        dataKey: 'email',
        position: 'left',
        isSortable: false,
        isEditable: true,
        type: ContentType.editableTextFields,
      },
      {
        name: 'userRole',
        dataKey: 'userRoleId',
        position: 'left',
        isSortable: false,
        isEditable: true,
        type: ContentType.editableTextFields,
      },
    ];
  }

  setUserForm() {
    this.usersForm = [
      {
        name: '_id',
        dataKey: 'id',
        hidden: true,
      },
      {
        name: 'Nombre de usuario',
        dataKey: 'username',
        position: { row: 0, col: 0, rowSpan: 1, colSpan: 1 },
        type: ContentType.editableTextFields,
        validators: [Validators.required],
      },
      {
        name: 'Contraseña',
        dataKey: 'password',
        position: { row: 0, col: 0, rowSpan: 1, colSpan: 1 },
        type: ContentType.editableTextFields,
        validators: [Validators.required],
      },
      {
        name: 'Correo',
        dataKey: 'email',
        position: { row: 1, col: 0, rowSpan: 1, colSpan: 1 },
        type: ContentType.editableTextFields,
        validators: [Validators.required],
      },
      {
        name: 'Tipo',
        dataKey: 'userRoleId',
        position: { row: 1, col: 0, rowSpan: 1, colSpan: 1 },
        type: ContentType.editableTextFields,
        validators: [Validators.required],
      },
    ];
  }

  showFormDialog() {
    let dialogData = {
      formData: undefined,
      formFields: this.usersForm,
      formCols: 2,
      dialogTitle: 'Añade un nuevo usuario'
    }
    const dialogRef = this.dialog.open(GenericFormDialogComponent, {data: dialogData, minWidth : 600});
    dialogRef.afterClosed().subscribe(result => {
      if(result !== undefined && result !== null && result !== ''){
        console.log(result);
        this.createElement(result)
      }
    })
  }

  sortData(sortParameters: Sort) {
    const keyName = sortParameters.active;
    if (sortParameters.direction === 'asc') {
      this.users = [
        ...this.users.sort((a, b) =>
          this.collator.compare(a[keyName], b[keyName])
        ),
      ];
    } else if (sortParameters.direction === 'desc') {
      this.users = [
        ...this.users.sort(
          (a, b) => -1 * this.collator.compare(a[keyName], b[keyName])
        ),
      ];
    } else {
      this.getUsers();
    }
  }

  deleteElement(event: any) {
    this.userService.delete(event.id).subscribe(
      (res) => {
        this.getUsers();
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
    this.userService.create(event).subscribe(
      (res) => {
        this.getUsers();
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

  updateElement(event: any) {
    this.userService.update(event.id, event).subscribe(
      (res) => {
        this.getUsers();
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

  updatePageNumber(pageNum: number) {
    this.pageNumber = pageNum;
  }
}
