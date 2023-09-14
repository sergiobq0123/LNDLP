import { animate, state, style, transition, trigger } from '@angular/animations';
import { Component, EventEmitter, InjectionToken, Injector, Input, Output, SimpleChanges, TemplateRef, ViewChild } from '@angular/core';
import { AbstractControl, Form, FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort, Sort } from '@angular/material/sort';
import { MatTable, MatTableDataSource } from '@angular/material/table';
import { ErrorCode, ErrorDTO, ErrorType } from 'src/app/common/errorDTO.model';
import { NotificationService } from 'src/app/services/notification.service';
import { ValidatorService } from 'src/app/services/validator.service';
import { Column } from './column';
import { DeleteWindowComponent } from 'src/app/intranet/delete-window/delete-window.component';
import { MatDialog } from '@angular/material/dialog';
import { notifications } from 'src/app/common/notifications';
import {
  CdkDragDrop,
  moveItemInArray,
  transferArrayItem,
} from '@angular/cdk/drag-drop';

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
  showFilterInput: boolean = true;
  selectedOption: Column; // Column selected to add in array filter
  selectedOptionCondition: any; // Column selected condition to add in array filter
  selectedFilters: any[]; // Selected Filters Array
  filterInput: any; // Column selected input value to add in array filter
  filterTypeInputConditions: string[] = ['is','is not','contains'];
  filterTypeDateConditions: string[] = ['is','more or equals','minor or equals','between','today','yesterday','this week','last week','this month','last month','this year','last year'];
  filterTypeDropdownConditions: string[] = ['is','is not'];
  startDate: Date; //Start Input to compare Dates
  endDate: Date; //End Input to compare Dates

  @ViewChild(MatPaginator, { static: false }) matPaginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) matSort: MatSort;

  @Input() isPageable = true;
  @Input() isSortable = true;
  @Input() isExpandable = false;
  @Input() isOrderable = false;
  @Input() hasActions = false;
  @Input() canAddRows = false;
  @Input() apiFailing = false;
  @Input() editingOutside = false;

  @Input() tableColumns: Column[];
  @Input() tableData: any[];
  @Input() expandData: any[];
  @Input() expandTemplate: TemplateRef<any>;
  @Input() parentId: number;

  @Input() paginationSizes: number[] = [5, 10, 20, 50];
  @Input() defaultPageSize = this.paginationSizes[1];

  @Output() sort: EventEmitter<Sort> = new EventEmitter();
  @Output() rowAdded: EventEmitter<any> = new EventEmitter<any>();
  @Output() delete: EventEmitter<any> = new EventEmitter<any>();
  @Output() create: EventEmitter<any> = new EventEmitter<any>();
  @Output() modified: EventEmitter<any> = new EventEmitter<any>();
  @Output() reordered: EventEmitter<any> = new EventEmitter<any>();
  @Output() pageNum: EventEmitter<any> = new EventEmitter<any>();
  @Output() edited: EventEmitter<boolean> = new EventEmitter<boolean>();

  ngOnChanges(changes: SimpleChanges) {
    let mustRender: boolean = (changes['tableColumn'] !== undefined ||
      changes['tableData'] !== undefined ||
      changes['expandData'] !== undefined ||
      changes['expandTemplate'] !== undefined)
    if (mustRender){
      this.setTableDataSource();
    }
  }

  constructor(private fb: FormBuilder,
    private notificationService: NotificationService,
    private errorMessagesService: ValidatorService,
    public dialog: MatDialog,
  ) { }

  ngOnInit(): void {
    this.setTableDataSource();
    this.displayedColumns = new Array<string>();
    this.selectedFilters = new Array();
    for (var i = 0; i < this.tableColumns.length; i++) {
      if (!this.tableColumns[i].hidden) {
        this.displayedColumns.push(this.tableColumns[i].name)
      }
    }
    if (this.hasActions) {
      this.displayedColumns = [...this.displayedColumns, '_action']
    }
    if (this.isExpandable) {
      this.displayedColumns = [...this.displayedColumns, '_expand']
    }
    if (this.isOrderable) {
      this.displayedColumns = ['_order', ...this.displayedColumns]
    }
  }

  columnDropped(event) {
    if (event.previousContainer === event.container) {
      if (event.container.id == 'availableColumns') {
        moveItemInArray(event.container.data, event.previousIndex, event.currentIndex)
      } else {
        moveItemInArray(this.displayedColumns, event.previousIndex, event.currentIndex)
      }
    } else {
      var c = this.tableColumns.find(c => c.name == event.item.data);
      if (event.container.id == "availableColumns") {
        if (this.displayedColumns.filter(c => !c.includes('_')).length <= 1) {
          this.notificationService.showMessageOnSnackbar(notifications.COLUMNS_INVALID_LENGTH, 'Ok!', 3500, 'success-button')
        } else {
          this.displayedColumns = this.displayedColumns.filter(col => col != c.name)
        }
      } else {
        transferArrayItem(event.previousContainer.data, this.displayedColumns, event.previousIndex, event.currentIndex)
      }
    }
  }

  getAvailableColumns() {
    return this.tableColumns.filter(c => !c.name.includes('_') && !this.displayedColumns.includes(c.name)).map(c => c.name);
  }

  getDisplayedColumns() {
    return this.displayedColumns.filter(c => !c.includes('_'));
  }

  getTypeColumn() {
    return this.tableColumns.filter(c => !c.name.includes('_') && !c.name.includes('Users'));
  }

  getUnselectedColumns() {
    return this.getTypeColumn().filter(column => !this.selectedFilters.some(filter => filter.dataKey === column.dataKey));
  }

  getValidatorErrorMessage(errors) {
    return this.errorMessagesService.getErrorMessage(Object.keys(errors)[0]);
  }

  // we need this, in order to make pagination work with *ngIf
  ngAfterViewInit(): void {
    this.tableDataSource.paginator = this.matPaginator;
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
          let vl = Object.keys(data).find(k => mainKey == k)
          value = dataKeys.reduce((a, p) => { return a[p] == null ? '' : a[p]; }, data[vl] == null ? '' : data[vl]);
        }
        else {
          value = data[c.dataKey]
        }
        controls[c.dataKey] = new FormControl({ value: value, disabled: !c.isEnabledByDefault }, c.validators);
        controls['isEditable'] = new FormControl(c.isEditable);
        controls['isNewRow'] = new FormControl(false);
      })
      controlsArray.push(this.fb.group(controls));
    })
    if (this.isSaved) {
      let previousArray = (this.VOForm.get('VORows') as FormArray).controls;
      if (previousArray.length == controlsArray.length) {
        controlsArray.sort((a, b) =>
          previousArray.findIndex(e => e.getRawValue().id == a.getRawValue().id) - previousArray.findIndex(e => e.getRawValue().id == b.getRawValue().id)
        )
      }
      this.isSaved = false;
    }

    this.VOForm = this.fb.group({ VORows: this.fb.array(controlsArray) }, { updateOn: "change" });
    this.tableDataSource = new MatTableDataSource((this.VOForm.get('VORows') as FormArray).controls);
    this.tableDataSource.paginator = this.matPaginator;

    const filterPredicate = this.tableDataSource.filterPredicate;
    this.tableDataSource.filterPredicate = (data: AbstractControl, filter) => {
      return filterPredicate.call(this.tableDataSource, data.getRawValue(), filter);
    };
  }

  paginationChanges(info: any){
    this.pageNum.emit(info.pageIndex + 1);
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
    }
    else if (this.apiFailing) {
      this.notificationService.showMessageOnSnackbar(notifications.PROBLEM_OCURRED, 'Ok!', 3500, 'success-button')
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
      this.notificationService.showMessageOnSnackbar(notifications.ENTRY_BEING_EDITED, 'Ok!', 3500, 'success-button');
    }
  }

  // this function is used for saving a new or a modified entry
  Save(row, index) {
    if (row.valid) {
      this.isSaved = true;
      this.parentId ? row.value.parentId = this.parentId : ''
      if (row.value.isNewRow) {
        this.create.emit(row.value);
        this.newRowAdded = false;
        this.rowAdded.emit(false);
      } else {
        this.modified.emit(row.value);
      }
      this.edittingRows.delete(index)
      row.get('isEditable').patchValue(true)
      row.disable()
      this.entryBeingEdited = false;
      this.edited.emit(this.entryBeingEdited);
    } else {
      let error: ErrorDTO = {
        code: ErrorCode.FormNotValid,
        type: ErrorType.FormValidators,
        description: "Form has invalid fields"
      }
      this.notificationService.showErrorOnSnackbar(error, "Ok!", 3500);
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
      this.notificationService.showMessageOnSnackbar(notifications.ENTRY_EDITION_CANCELED, 'Ok!', 3500, 'success-button');
    }
    this.entryBeingEdited = false;
    this.edited.emit(this.entryBeingEdited);
  }

  Delete(row) {
    let data = row.getRawValue()
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
        this.notificationService.showMessageOnSnackbar(notifications.ENTRY_EDITION_CANCELED, 'Ok!', 3500, 'success-button');
      }
    })
  }

  drop(event: CdkDragDrop<any[]>) {
    this.dragDisabled = true;
    if (event.previousIndex != event.currentIndex) {
      moveItemInArray(this.tableData, event.previousIndex, event.currentIndex);
      this.reordered.emit(this.tableData);
    }
  }

  setupFilteringByColumn(column: string) {
    this.tableDataSource.filterPredicate = (data: AbstractControl, filter) => {
      const textToSearch = data.value[column].trim().toLowerCase() || ''
      return textToSearch.includes(filter.trim().toLowerCase());
    };
  }

  // Function to Find selectedOptions assing by the user
  applyFilterOption() {
    if (this.selectedFilters.length > 0) {
      const filterPredicates = [];
      const today = new Date();

      this.selectedFilters.forEach(filterOptions => {
        const filterPredicate = (data: any) => {
          let value = data.getRawValue()[filterOptions.dataKey];

          if (filterOptions.type === 'dropdownFields') {
            const targetDropdown = filterOptions.dropdown.find(dropdownValues => dropdownValues.id === value);
            if (targetDropdown) {
              value = targetDropdown[filterOptions.dropdownKeyToShow].toLowerCase();
            }

            switch (filterOptions.condition) {
              case 'is':
                return value === filterOptions.filterInput.toLowerCase();
              case 'is not':
                return value !== filterOptions.filterInput.toLowerCase();
              default:
                return false;
            }
          } else if (filterOptions.type === 'editableTextFields') {
            value = value.toString().toLowerCase();

            switch (filterOptions.condition) {
              case 'is':
                return value === filterOptions.filterInput.toLowerCase();
              case 'is not':
                return value !== filterOptions.filterInput.toLowerCase();
              case 'contains':
                return value.includes(filterOptions.filterInput.toLowerCase());
              default:
                return false;
            }
          } else if (filterOptions.type == 'datePicker') {
            const itemDate = new Date(value);
            const selectedDate = new Date(filterOptions.filterInput);

            switch (filterOptions.condition) {
              case 'today':
                return itemDate.getDate() === today.getDate();
              case 'yesterday':
                const yesterday = new Date();
                yesterday.setDate(today.getDate() - 1);
                return itemDate.getDate() === yesterday.getDate();
              case 'this week':
                const week = new Date(today.getFullYear(), today.getMonth(), today.getDate() - 7);
                return itemDate >= week && itemDate <= today;
              case 'last week':
                const thisWeek = new Date(today.getFullYear(), today.getMonth(), today.getDate() - 7);
                const lastWeek = new Date(today.getFullYear(), today.getMonth(), today.getDate() - 14);
                return itemDate >= lastWeek && itemDate <= thisWeek;
              case 'this month':
                const month = today.getMonth();
                return itemDate.getMonth() === month;
              case 'last month':
                const lastMonth = today.getMonth() -1;
                return itemDate.getMonth() === lastMonth;
              case 'this year':
                const year = today.getFullYear();
                return itemDate.getFullYear() === year;
              case 'last year':
                const lastYear = today.getFullYear() - 1;
                return itemDate.getFullYear() === lastYear;
              case 'is':
                return itemDate.getTime() === selectedDate.getTime();
              case 'more or equals':
                return itemDate >= selectedDate;
              case 'minor or equals':
                return itemDate <= selectedDate;
              case 'between':
                return itemDate >= filterOptions.startDate && itemDate <= filterOptions.endDate;
              default:
                return false;
            }
          }
        };
        filterPredicates.push(filterPredicate);
      });
      const compositeFilterPredicate = (data: any) => {
        return filterPredicates.every(predicate => predicate(data));
      };
      this.tableDataSource.filterPredicate = compositeFilterPredicate;
      this.tableDataSource.filter = 'applyFilters';
    } else {
      this.tableDataSource.filterPredicate = null;
      this.tableDataSource.filter = '';
      this.notificationService.showMessageOnSnackbar(notifications.FILTER_NOT_CREATED, 'Ok!', 3500, 'success-button');
    }
  }

  // Function to add all selected filters to an array
  addFilter() {
    if (this.selectedOption && this.selectedOptionCondition) {
      const filterOptions = {
        dataKey: this.selectedOption.dataKey,
        name: this.selectedOption.name,
        type: this.selectedOption.type,
        condition: this.selectedOptionCondition,
        filterInput: this.filterInput,
        dropdown: this.selectedOption.dropdown,
        dropdownKeyToShow: this.selectedOption.dropdownKeyToShow,
        startDate: this.startDate,
        endDate: this.endDate,
      };
      const existingFilterIndex = this.selectedFilters.findIndex(filter => filter.dataKey === filterOptions.dataKey);

      if (existingFilterIndex === -1) {
        this.selectedFilters.push(filterOptions);
      } else {
        this.notificationService.showMessageOnSnackbar(notifications.FILTER_ALLREADY_ADDED, 'Ok!', 3500, 'success-button');
      }
      this.selectedOptionCondition = null;
      this.filterInput = null;
      this.selectedOption = null;
    } else {
      this.notificationService.showMessageOnSnackbar(notifications.FILTER_NOT_SELECTED, 'Ok!', 3500, 'success-button');
    }
  }

  // Function to reset all Filter options
  resetFilterOptions() {
    this.selectedOptionCondition = null;
    this.filterInput = null;
    this.selectedOption = null;
    this.selectedFilters = [];
    this.setTableDataSource();
  }

  removeFilter(filterToRemove: any) {
    const existingFilterIndex = this.selectedFilters.findIndex(filter => filter.dataKey === filterToRemove.dataKey);

    if (existingFilterIndex !== -1) {
      this.selectedFilters.splice(existingFilterIndex, 1);
    }
  }

  sortTable(sortParameters: Sort) {
    // defining name of data property, to sort by, instead of column name
    sortParameters.active = this.tableColumns.find(column => column.name === sortParameters.active).dataKey;
    this.sort.emit(sortParameters);
  }

  openMaps(direccion : string){
    const url = `https://www.google.com/maps?q=${direccion}`;
    window.open(url, '_blank');
  }

  getDropdownValue(dropdownItem: any): string {
    if (dropdownItem.hasOwnProperty('status')) {
      return dropdownItem.status;
    } else if (dropdownItem.hasOwnProperty('name')) {
      return dropdownItem.name;
    } else if (dropdownItem.hasOwnProperty('type')) {
      return dropdownItem.type;
    } else if (dropdownItem.hasOwnProperty('userCode')) {
      return dropdownItem.userCode;
    }
    return '';
  }
}


