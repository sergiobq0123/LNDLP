

import { animate, state, style, transition, trigger } from '@angular/animations';
import { CdkDragDrop, moveItemInArray, transferArrayItem } from '@angular/cdk/drag-drop';
import { Component, EventEmitter, Input, Output, SimpleChanges, TemplateRef, ViewChild } from '@angular/core';
import { AbstractControl, FormArray, FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatSort, Sort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ErrorCode, ErrorDTO, ErrorType } from 'src/app/common/errorDTO.model';
import { notifications } from 'src/app/common/notifications';
import { NotificationService } from 'src/app/services/notification.service';
import { ValidatorService } from 'src/app/services/validator.service';
import { Filter } from '../generic-filter/filter';
import { ContentType } from '../generic-form-dialog/generic-content';
import { Column } from './column';
import { DeleteWindowComponent } from '../delete-window/delete-window.component';

@Component({
  selector: 'app-generic-table',
  templateUrl: './generic-table.component.html',
  styleUrls: ['./generic-table.component.scss'],
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({ height: '0px', minHeight: '0' })),
      state('expanded', style({ height: '*' })),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})
export class GenericTableComponent {
  public tableDataSource = new MatTableDataSource([]);
  public displayedColumns: string[];
  expandedElement: any;
  VOForm: FormGroup;
  defaultPageNumber: number;
  dragDisabled: boolean;
  newRowAdded: boolean;
  edittingRows = new Map();
  entryBeingEdited: boolean = false;
  isSaved: boolean = false;
  showColumnSelection: boolean = false;
  showFilterOptions: boolean = false;

  @ViewChild(MatPaginator) matPaginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) matSort: MatSort;

  @Input() isPageable = true;
  @Input() isSortable = true;
  @Input() isExpandable = false;
  @Input() isOrderable = false;
  @Input() hasActions = false;
  @Input() canAddRows = false;
  @Input() apiFailing = false;
  @Input() editingOutside = false;
  @Input() canManageColumns = false;
  @Input() hasFilter = false;

  @Input() tableColumns: Column[];
  @Input() tableData: any[];
  @Input() expandData: any[];
  @Input() expandTemplate: TemplateRef<any>;
  @Input() parentId: number;

  @Input() paginationSizes: number[] = [5, 10, 20, 50];
  @Input() pageSize = this.paginationSizes[1];
  @Input() pageNumber = 1;
  @Input() totalRecords: number;
  @Input() isUsers: boolean = false;

  @Output() filtered: EventEmitter<Filter[]> = new EventEmitter();
  @Output() sort: EventEmitter<Sort> = new EventEmitter();
  @Output() rowAdded: EventEmitter<any> = new EventEmitter<any>();
  @Output() delete: EventEmitter<any> = new EventEmitter<any>();
  @Output() create: EventEmitter<any> = new EventEmitter<any>();
  @Output() modified: EventEmitter<any> = new EventEmitter<any>();
  @Output() reordered: EventEmitter<any> = new EventEmitter<any>();
  @Output() paginationChange: EventEmitter<PageEvent> = new EventEmitter();
  @Output() edited: EventEmitter<boolean> = new EventEmitter<boolean>();

  constructor(
    private fb: FormBuilder,
    private notificationService: NotificationService,
    private errorMessagesService: ValidatorService,
    public dialog: MatDialog,
  ) {}

  ngOnInit(): void {
    this.setTableDataSource();
    this.displayedColumns = new Array<string>();
    for (var i = 0; i < this.tableColumns.length; i++) {
      if (!this.tableColumns[i].hidden) {
        this.displayedColumns.push(this.tableColumns[i].name);
      }
    }
    if (this.hasActions) {
      this.displayedColumns = [...this.displayedColumns, '_action'];
    }
    if (this.isExpandable) {
      this.displayedColumns = [...this.displayedColumns, '_expand'];
    }
    if (this.isOrderable) {
      this.displayedColumns = ['_order', ...this.displayedColumns];
    }
  }

  ngOnChanges(changes: SimpleChanges) {
    let mustRender: boolean =
      changes['tableColumn'] !== undefined ||
      changes['tableData'] !== undefined ||
      changes['expandData'] !== undefined ||
      changes['expandTemplate'] !== undefined;
    if (mustRender) {
      this.setTableDataSource();
    }
  }

  columnDropped(event) {
    if (event.previousContainer === event.container) {
      if (event.container.id == 'availableColumns') {
        moveItemInArray(event.container.data, event.previousIndex, event.currentIndex);
      } else {
        moveItemInArray(this.displayedColumns, event.previousIndex, event.currentIndex);
      }
    } else {
      var c = this.tableColumns.find(c => c.name == event.item.data);
      if (event.container.id == 'availableColumns') {
        if (this.displayedColumns.filter(c => !c.includes('_')).length <= 1) {
          this.notificationService.showMessageOnSnackbar(
            notifications.COLUMNS_INVALID_LENGTH,
            'X',
            3500,
            'warn-button',
          );
        } else {
          this.displayedColumns = this.displayedColumns.filter(col => col != c.name);
        }
      } else {
        transferArrayItem(event.previousContainer.data, this.displayedColumns, event.previousIndex, event.currentIndex);
      }
    }
  }
  defineTooltip(columnName: string): string {
    if (columnName === 'SPs') {
      return 'Estimated Story Points';
    } else if (columnName === 'TL') {
      return 'Time Logged';
    } else {
      return null;
    }
  }
  getAvailableColumns() {
    return this.tableColumns
      .filter(c => !c.name.includes('_') && !this.displayedColumns.includes(c.name))
      .map(c => c.name);
  }

  getDisplayedColumns() {
    return this.displayedColumns.filter(c => !c.includes('_'));
  }

  getTypeColumn() {
    return this.tableColumns.filter(c => !c.name.includes('_') && c.type != ContentType.specialContent);
  }

  getValidatorErrorMessage(errors) {
    return this.errorMessagesService.getErrorMessage(Object.keys(errors)[0]);
  }

  setTableDataSource() {
    let controlsArray = new Array();
    this.tableData.map(data => {
      let controls = {};
      this.tableColumns.map(c => {
        let value;
        let dataKeys = c.dataKey.split('.');
        if (dataKeys.length > 1) {
          let mainKey = dataKeys.shift();
          let vl = Object.keys(data).find(k => mainKey == k);
          value = dataKeys.reduce(
            (a, p) => {
              return a[p] == null ? '' : a[p];
            },
            data[vl] == null ? '' : data[vl],
          );
        } else {
          value = data[c.dataKey];
        }
        controls[c.dataKey] = new FormControl({ value: value, disabled: !c.isEnabledByDefault }, c.validators);
        controls['isNewRow'] = new FormControl(false);
        if (this.hasActions) {
          controls['isEditable'] = new FormControl(true);
        }
      });
      controlsArray.push(this.fb.group(controls));
    });
    if (this.isSaved) {
      let previousArray = (this.VOForm.get('VORows') as FormArray).controls;
      if (previousArray.length == controlsArray.length) {
        controlsArray.sort(
          (a, b) =>
            previousArray.findIndex(e => e.getRawValue().id == a.getRawValue().id) -
            previousArray.findIndex(e => e.getRawValue().id == b.getRawValue().id),
        );
      }
      this.isSaved = false;
    }

    this.VOForm = this.fb.group({ VORows: this.fb.array(controlsArray) }, { updateOn: 'change' });
    this.tableDataSource = new MatTableDataSource((this.VOForm.get('VORows') as FormArray).controls);

    const filterPredicate = this.tableDataSource.filterPredicate;
    this.tableDataSource.filterPredicate = (data: AbstractControl, filter) => {
      return filterPredicate.call(this.tableDataSource, data.getRawValue(), filter);
    };
  }

  onPaginationChange(info: PageEvent) {
    this.paginationChange.emit(info);
  }

  addNewCustomRow(newRow: any) {
    let row = {};
    Object.entries(newRow).forEach(([key, value]) => {
      row[key] = new FormControl(value);
    });
    row['isEditable'] = new FormControl(false);
    row['isNewRow'] = new FormControl(true);
    const control = this.VOForm.get('VORows') as FormArray;
    control.push(this.fb.group(row));
    this.tableDataSource = new MatTableDataSource(control.controls);
    this.tableDataSource.paginator = this.matPaginator;
    this.matPaginator.lastPage();
    this.rowAdded.emit(true);
  }

  addNewRow() {
    if (!this.newRowAdded && !this.entryBeingEdited && !this.editingOutside) {
      let row = {};
      this.tableColumns.map(col => {
        row[col.dataKey] = new FormControl('', col.validators);
      });
      row['isEditable'] = new FormControl(false);
      row['isNewRow'] = new FormControl(true);
      this.newRowAdded = true;
      this.rowAdded.emit(true);
      this.entryBeingEdited = true;
      this.edited.emit(this.entryBeingEdited);
      const controls = this.VOForm.get('VORows') as FormArray;
      controls.push(this.fb.group(row));
      this.tableDataSource = new MatTableDataSource(controls.controls);
      this.matPaginator.length = this.tableDataSource.data.length;
      this.matPaginator.lastPage();
      this.tableDataSource.paginator = this.matPaginator;
    } else if (this.apiFailing) {
      this.notificationService.showMessageOnSnackbar(notifications.PROBLEM_OCURRED, 'X', 3500, 'err-button');
    }
  }

  // this function will enabled the select field for edit
  Edit(row, index) {
    if (!this.entryBeingEdited && !this.editingOutside) {
      row.enable();
      this.edittingRows.set(index, row.value);
      row.get('isEditable').patchValue(false);
      this.entryBeingEdited = true;
      this.edited.emit(this.entryBeingEdited);
    } else {
      this.notificationService.showMessageOnSnackbar(notifications.ENTRY_BEING_EDITED, 'X', 3500, 'warn-button');
    }
  }

  // this function is used for saving a new or a modified entry
  Save(row, index) {
    if (row.valid) {
      this.isSaved = true;
      this.parentId ? (row.value.parentId = this.parentId) : '';
      if (row.value.isNewRow) {
        this.create.emit(row.value);
        this.newRowAdded = false;
        this.rowAdded.emit(false);
      } else {
        this.modified.emit(row.value);
      }
      this.edittingRows.delete(index);
      row.get('isEditable').patchValue(true);
      row.disable();
      this.entryBeingEdited = false;
      this.edited.emit(this.entryBeingEdited);
    } else {
      let error: ErrorDTO = {
        code: ErrorCode.FormNotValid,
        type: ErrorType.FormValidators,
        description: 'Form has invalid fields',
      };
      this.notificationService.showErrorOnSnackbar(error, 'X', 3500);
    }
  }

  // On click of cancel button in the table (after click on edit) this method will call and reset the previous data
  Cancel(row, index) {
    if (row.get('isNewRow').value) {
      const control = this.VOForm.get('VORows') as FormArray;
      control.removeAt(index);
      this.tableDataSource = new MatTableDataSource(control.controls);
      this.tableDataSource.paginator = this.matPaginator;
      this.newRowAdded = false;
      this.rowAdded.emit(false);
    } else {
      (this.VOForm.get('VORows') as FormArray).controls[index].setValue(this.edittingRows.get(index));
      row.disable();
      this.notificationService.showMessageOnSnackbar(notifications.ENTRY_EDITION_CANCELED, 'X', 3500, 'info-button');
    }
    this.entryBeingEdited = false;
    this.edited.emit(this.entryBeingEdited);
  }

  Delete(row) {
    let data = row.getRawValue();
    if (this.parentId != undefined && this.parentId != null) {
      data.parentId = this.parentId;
    }
    const dialogRef = this.dialog.open(DeleteWindowComponent);
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.delete.emit(data);
        this.entryBeingEdited = false;
        this.edited.emit(this.entryBeingEdited);
      } else {
        this.notificationService.showMessageOnSnackbar(notifications.ENTRY_EDITION_CANCELED, 'X', 3500, 'info-button');
      }
    });
  }

  drop(event: CdkDragDrop<any[]>) {
    this.dragDisabled = true;
    if (event.previousIndex != event.currentIndex) {
      moveItemInArray(this.tableData, event.previousIndex, event.currentIndex);
      this.reordered.emit(this.tableData);
    }
  }

  sortTable(sortParameters: Sort) {
    // defining name of data property, to sort by, instead of column name
    sortParameters.active = this.tableColumns.find(column => column.name === sortParameters.active).dataKey;
    this.sort.emit(sortParameters);
  }

  getValueToShow(column: Column, key: string): string {
    switch (column.type) {
      case ContentType.dropdownFields:
        const dropdown = column.dropdown.find(element => element.id === key);
        return dropdown ? dropdown[column.dropdownKeyToShow] : null;
      case ContentType.radioButtons:
        const radioButton = column.radioButtons.find(element => element.value === key);
        return radioButton ? radioButton.shown : null;
      case ContentType.datePicker:
        return new Date(key).toLocaleString('en-GB', { timeZone: 'UTC' });
      default:
        return key;
    }
  }

  openMaps(direccion: string) {
    const url = `https://www.google.com/maps?q=${direccion}`;
    window.open(url, '_blank');
  }
}



