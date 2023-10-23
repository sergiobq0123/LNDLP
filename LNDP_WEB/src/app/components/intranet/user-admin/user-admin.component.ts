import { Component, TemplateRef, ViewChild } from '@angular/core';
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
import { PageEvent } from '@angular/material/paginator';
import { UserRoleService } from 'src/app/services/intranet/user-role.service';
import { AuthService } from 'src/app/services/auth.service';
import { notifications } from 'src/app/common/notifications';
import { Filter } from '../general/generic-filter/filter';
import { faPlus } from '@fortawesome/free-solid-svg-icons';
import { IconButton } from '../general/generic-table/icon-button';
import { AccesService } from 'src/app/services/intranet/acces.service';

@Component({
  selector: 'app-user-admin',
  templateUrl: './user-admin.component.html',
  styleUrls: ['./user-admin.component.scss'],
})
export class UserAdminComponent {
  users: Array<any> = new Array<any>();
  usersRole: Array<any> = new Array<any>();
  usersKeys: Array<any> = new Array<any>();
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
  pageSize: number = 10;
  totalUsers = 50;
  iconButtons: IconButton[] = [];

  @ViewChild(GenericTableComponent) table: GenericTableComponent;
  @ViewChild('passwordTemplate') passwordTemplate: TemplateRef<any>;
  @ViewChild('addTemplate') addTemplate: TemplateRef<any>;

  faPlus = faPlus;

  constructor(
    private _userService: UsersService,
    private _userRoleService: UserRoleService,
    private _accesService: AccesService,
    public dialog: MatDialog,
    private _notificationService: NotificationService
  ) {}

  ngOnInit() {
    this.getUsers();
    this.getUserKeys();
  }

  ngAfterViewInit() {
    this.setIconsButtons();
  }

  setIconsButtons() {
    this.iconButtons = [
      {
        template: this.addTemplate,
        isLeft: true,
      },
    ];
  }

  getUsers() {
    this.spinner = true;
    this._userService.get().subscribe(
      (res) => {
        this.handleGetResponse(res);
      },
      (error) => {
        this.handleGetErrorResponse();
      }
    );
  }

  getUserKeys() {
    this._userRoleService.getKeys().subscribe((res) => {
      this.usersKeys = res;
    });
  }

  setColumns(): void {
    this.usersColumns = [
      {
        name: '_id',
        dataKey: 'id',
        hidden: true,
      },
      {
        name: '_userRoleId',
        dataKey: 'userRoleId',
        hidden: true,
      },
      {
        name: 'Nombre de usuario',
        dataKey: 'acces.userName',
        position: 'left',
        isSortable: true,
        hidden: false,
        type: ContentType.plainText,
      },
      {
        name: 'Nombre',
        dataKey: 'firstName',
        position: 'left',
        isSortable: false,
        type: ContentType.editableTextFields,
      },
      {
        name: 'Apellido',
        dataKey: 'lastName',
        position: 'left',
        isSortable: false,
        type: ContentType.editableTextFields,
      },
      {
        name: 'Email',
        dataKey: 'email',
        position: 'left',
        isSortable: false,
        type: ContentType.editableTextFields,
      },
      {
        name: 'Role',
        dataKey: 'userRole.role',
        position: 'left',
        isSortable: false,
        type: ContentType.plainText,
      },
      {
        name: 'Password',
        dataKey: 'password',
        position: 'left',
        isSortable: false,
        type: ContentType.specialContent,
        template: this.passwordTemplate,
      },
    ];
  }

  setUserForm(): any[] {
    return [
      {
        name: 'Tipo de usuario',
        dataKey: 'userRoleId',
        position: { row: 0, col: 0, rowSpan: 1, colSpan: 1 },
        hidden: false,
        type: ContentType.dropdownFields,
        dropdown: this.usersKeys,
        dropdownKeyToShow: 'name',
        dropdownKeyValue: 'id',
        validators: [Validators.required],
      },
      {
        name: 'Nombre',
        dataKey: 'firstName',
        position: { row: 1, col: 0, rowSpan: 1, colSpan: 1 },
        type: ContentType.editableTextFields,
        validators: [Validators.required],
      },
      {
        name: 'Apellido',
        dataKey: 'lastName',
        position: { row: 1, col: 0, rowSpan: 1, colSpan: 1 },
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

  setUserPasswordForm(): any[] {
    return [
      {
        name: 'Contraseña',
        dataKey: 'password',
        position: { row: 0, col: 0, rowSpan: 1, colSpan: 2 },
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
      dialogTitle: 'Añade un nuevo usuario',
    };
    const dialogRef = this.dialog.open(GenericFormDialogComponent, {
      data: dialogData,
      minWidth: 600,
    });
    dialogRef.afterClosed().subscribe(async (result) => {
      if (result !== undefined && result !== null && result !== '') {
        this.createElement(result);
      }
    });
  }

  showFormDialogPassword(event: any) {
    let dialogData = {
      formData: event,
      formFields: this.setUserPasswordForm(),
      formCols: 2,
      dialogTitle: 'Añade una nueva contraseña',
    };
    const dialogRef = this.dialog.open(GenericFormDialogComponent, {
      data: dialogData,
      minWidth: 600,
    });
    dialogRef.afterClosed().subscribe((result) => {
      if (result !== undefined && result !== null && result !== '') {
        this.updateElement(result);
      }
    });
  }

  createElement(event: any) {
    event.id = 0;
    this._userService.createUser(event).subscribe(
      (res) => {
        this.handleResponse(res.message);
      },
      (err) => {
        this.handleErrorResponse(err.error.message);
      }
    );
  }

  updateElement(event: any) {
    this._userService.update(event.id, event).subscribe(
      (res) => {
        this.handleResponse(res.message);
      },
      (err) => {
        this.handleErrorResponse(err.error.message);
      }
    );
  }

  deleteElement(event: any) {
    this._userService.delete(event.id).subscribe(
      (res) => {
        this.handleResponse(res.message);
      },
      (err) => {
        this.handleErrorResponse(err.error.message);
      }
    );
  }

  private handleGetResponse(res: any) {
    this.users = res;
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
    this.getUsers();
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

  onPaginationChange(PageEvent: PageEvent) {
    this.pageNumber = PageEvent.pageIndex + 1;
    this.pageSize = PageEvent.pageSize;
    this.getUsers();
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

  filterData(filters: Filter[]) {
    this._userService.getFiltered(filters).subscribe((res) => {
      this.users = res;
    });
  }
}
