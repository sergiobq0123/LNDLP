import { Component } from '@angular/core';
import { Column } from '../../generic-table/column';
import { ContentType } from '../../generic-form-dialog/generic-content';
import { Sort } from '@angular/material/sort';
import { MatDialog } from '@angular/material/dialog';
import { NotificationService } from 'src/app/services/notification.service';
import { SocialNetworkService } from 'src/app/services/intranet/social-network.service';

@Component({
  selector: 'app-social-netwok-admin',
  templateUrl: './social-netwok-admin.component.html',
  styleUrls: ['./social-netwok-admin.component.scss']
})
export class SocialNetwokAdminComponent {
  socialNetworks: Array<any> = new Array<any>();
  socialNetworkColumns: Column[];
  pageNumber: number = 1;
  loaded: boolean = false;
  newRowAdded: boolean = false;
  entryBeingEdited: boolean = false;
  apiFailing: boolean = false;
  collator = new Intl.Collator(undefined, { numeric: true, sensitivity: 'base' });
  spinner: boolean = false;

  constructor(
    private socialNetwokService: SocialNetworkService,
    public dialog : MatDialog,
    private notificationService : NotificationService
  ){}

  ngOnInit(){
    this.getSocialNetworks()
  }

  getSocialNetworks() {
    this.socialNetwokService.get().subscribe((res) => {
      console.log(res);

      let socialNetworks = new Array();
      res.forEach(val => {
        socialNetworks.push(val)
      });
      this.socialNetworks = [... socialNetworks];
      console.log(this.socialNetworks);

      this.setColumns();
      this.loaded = true;
    })
  }

  setColumns(): void {
    this.socialNetworkColumns = [
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
      this.socialNetworks = [ ...this.socialNetworks.sort((a, b) => this.collator.compare(a[ keyName ], b[ keyName ])) ];
    } else if (sortParameters.direction === 'desc') {
      this.socialNetworks = [ ...this.socialNetworks.sort((a, b) => (-1) * this.collator.compare(a[ keyName ], b[ keyName ])) ];
    } else {
      this.getSocialNetworks();
    }
  }

  updateElement(event: any) {}

  deleteElement(event: any) {}

  createElement(event: any) {}

  updatePageNumber(pageNum: number) {
    this.pageNumber = pageNum;
  }
}
