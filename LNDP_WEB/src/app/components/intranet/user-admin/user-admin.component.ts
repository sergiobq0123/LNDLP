import { Component, ViewChild } from '@angular/core';
import { Sort } from '@angular/material/sort';
import {
  ContentType,
  GenericForm,
} from '../general/generic-form-dialog/generic-content';
import { NotificationService } from 'src/app/services/notification.service';
import { MatDialog } from '@angular/material/dialog';
import { Column } from '../general/generic-table/column';
import { UsersService } from 'src/app/services/intranet/users.service';
import { GenericTableComponent } from '../general/generic-table/generic-table.component';
import { Validators } from '@angular/forms';
import { GenericFormDialogComponent } from '../general/generic-form-dialog/generic-form-dialog.component';
import { Filter } from '../general/generic-table/Filter';
import { PageEvent } from '@angular/material/paginator';



@Component({
  selector: 'app-user-admin',
  templateUrl: './user-admin.component.html',
  styleUrls: ['./user-admin.component.scss'],
})
export class UserAdminComponent {
  users: Array<any> = new Array<any>();
  usersRole: Array<any> = new Array<any>();
  artistWithoutUser: Array<any> = new Array<any>();
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
  pageSize : number = 10;
  totalUsers = 50

  @ViewChild(GenericTableComponent) table: GenericTableComponent;

  constructor(
    private _userService: UsersService,
    public dialog: MatDialog,
    private notificationService: NotificationService
  ) {}

  ngOnInit() {
    this.getUsers();
  }

  getUsers() {
    this._userService.get().subscribe((res) => {
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
    this._userService.getFiltered(filters).subscribe(res =>{
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
        name: '_userRoleId',
        dataKey: 'userRoleId',
        hidden: true
      },
      {
        name: 'Nombre de usuario',
        dataKey: 'username',
        position: 'left',
        isSortable: true,
        hidden: false,
        type: ContentType.editableTextFields,
      },
      {
        name: 'Email',
        dataKey: 'email',
        position: 'left',
        isSortable: false,
        type: ContentType.editableTextFields,
      }
    ];
  }

  setUserForm() : any[] {
    return [
      {
        name: '_id',
        dataKey: 'id',
        hidden: true,
      },
      {
        name: 'UserRole',
        dataKey: 'userRoleId',
        hidden : true,
      },
      {
        name: 'Correo',
        dataKey: 'email',
        position: { row: 1, col: 0, rowSpan: 1, colSpan: 1 },
        type: ContentType.editableTextFields,
        validators: [Validators.required],
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
    ];
  }

  showFormDialog() {
    let dialogData = {
      formData: undefined,
      formFields: this.setUserForm(),
      formCols: 2,
      dialogTitle: 'Añade un nuevo usuario'
    }
    const dialogRef = this.dialog.open(GenericFormDialogComponent, {data: dialogData, minWidth : 600});
    dialogRef.afterClosed().subscribe(result => {
      if(result !== undefined && result !== null && result !== ''){
        console.log(result);
        result["userRoleId"] = 2
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

  createElement(event: any) {
    event.id = 0;
    event.userRoleId = 1
    this._userService.create(event).subscribe(
      (res) => {
        this.getUsers();
        this.notificationService.showMessageOnSnackbar(
          res.message,
          'OK!',
          3500,
          'success-button'
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

  onPaginationChange(PageEvent: PageEvent){
    this.pageNumber = PageEvent.pageIndex + 1;
    this.pageSize = PageEvent.pageSize;
    this.getUsers();
  }
}
