import { Component } from '@angular/core';
import { Sort } from '@angular/material/sort';
import { ContentType } from '../../generic-form-dialog/generic-content';
import { NotificationService } from 'src/app/services/notification.service';
import { MatDialog } from '@angular/material/dialog';
import { Column } from '../../generic-table/column';
import { UsersService } from 'src/app/services/intranet/users.service';


@Component({
  selector: 'app-user-admin',
  templateUrl: './user-admin.component.html',
  styleUrls: ['./user-admin.component.scss']
})
export class UserAdminComponent {
  users: Array<any> = new Array<any>();
  usersColumns: Column[];
  pageNumber: number = 1;
  loaded: boolean = false;
  newRowAdded: boolean = false;
  entryBeingEdited: boolean = false;
  apiFailing: boolean = false;
  collator = new Intl.Collator(undefined, { numeric: true, sensitivity: 'base' });
  spinner: boolean = false;

  constructor(
    private userService: UsersService,
    public dialog : MatDialog,
    private notificationService : NotificationService
  ){}

  ngOnInit(){
    this.getArtist()
  }

  getArtist() {
    this.userService.get().subscribe((res) => {
      console.log(res);

      let users = new Array();
      res.forEach(val => {
        users.push(val)
      });
      this.users = [... users];
      console.log(this.users);

      this.setColumns();
      this.loaded = true;
    })
  }

  setColumns(): void {
    this.usersColumns = [
      {
        name: 'name',
        dataKey: 'name',
        position: 'left',
        isSortable: true,
        isEditable: true,
        hidden: false,
        type: ContentType.editableTextFields
      },
      {
        name: 'city',
        dataKey: 'city',
        position: 'left',
        isSortable: false,
        type: ContentType.editableTextFields,
      },
      {
        name: 'recruitmentEmail',
        dataKey: 'recruitmentEmail',
        position: 'left',
        isSortable: false,
        type: ContentType.editableTextFields,
      }
    ];
  }

  showFormDialog() {}

  sortData(sortParameters: Sort) {
    const keyName = sortParameters.active;
    if (sortParameters.direction === 'asc') {
      this.users = [ ...this.users.sort((a, b) => this.collator.compare(a[ keyName ], b[ keyName ])) ];
    } else if (sortParameters.direction === 'desc') {
      this.users = [ ...this.users.sort((a, b) => (-1) * this.collator.compare(a[ keyName ], b[ keyName ])) ];
    } else {
      this.getArtist();
    }
  }

  updateElement(event: any) {}

  deleteElement(event: any) {}

  createElement(event: any) {}

  updatePageNumber(pageNum: number) {
    this.pageNumber = pageNum;
  }
}
