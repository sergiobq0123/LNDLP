import { Component, EventEmitter, Input, Output } from '@angular/core';
import { AbstractControl, FormControl, Validators } from '@angular/forms';
import { NotificationService } from 'src/app/services/notification.service';
import { ContentType } from '../generic-form-dialog/generic-content';
import { Column } from '../generic-table/column';
import { Filter } from './filter';

@Component({
  selector: 'app-generic-filter',
  templateUrl: './generic-filter.component.html',
  styleUrls: ['./generic-filter.component.scss'],
})
export class GenericFilterComponent {
  selectedFilters: Filter[]; // Selected Filters Array
  selectedOption: Column; // Column selected to add in array filter
  filterTypeInputConditions: Filter.Condition[] = [
    Filter.Condition.IS,
    Filter.Condition.IS_NOT,
    Filter.Condition.CONTAINS,
  ];
  filterTypeDateConditions: Filter.Condition[] = [
    Filter.Condition.IS,
    Filter.Condition.MORE_OR_EQUALS,
    Filter.Condition.LESS_OR_EQUALS,
    Filter.Condition.BETWEEN,
    Filter.Condition.TODAY,
    Filter.Condition.YESTERDAY,
    Filter.Condition.THIS_WEEK,
    Filter.Condition.LAST_WEEK,
    Filter.Condition.THIS_MONTH,
    Filter.Condition.LAST_MONTH,
    Filter.Condition.THIS_YEAR,
    Filter.Condition.LAST_YEAR,
  ];
  filterTypeDropdownConditions: Filter.Condition[] = [Filter.Condition.IS, Filter.Condition.IS_NOT];
  public FilterCondition = Filter.Condition;
  startDate: FormControl = new FormControl(Date.now, [Validators.required]);
  endDate: FormControl = new FormControl(Date.now, [Validators.required]);

  @Input() tableDataSource;
  @Input() tableColumns: Column[];

  @Output() filtered: EventEmitter<Filter[]> = new EventEmitter();

  constructor(private notificationService: NotificationService) {}

  ngOnInit() {
    this.selectedFilters = [];
    this.selectedOption = null;
  }

  setupFilteringByColumn(column: string) {
    this.tableDataSource.filterPredicate = (data: AbstractControl, filter) => {
      const textToSearch = data.value[column].trim().toLowerCase() || '';
      return textToSearch.includes(filter.trim().toLowerCase());
    };
  }

  // Function to Find selectedOptions assing by the user
  applyFilterOption() {
    if (this.startDate.invalid || this.endDate.invalid) {
      return;
    }
    const filters: Filter[] = this.selectedFilters.filter(f => f.active);
    this.filtered.emit(filters);
  }

  // Function to add all selected filters to an array
  addFilter() {
    if (this.selectedOption) {
      const filterOptions: Filter = {
        dataKey: this.selectedOption.dataKey,
        name: this.selectedOption.name,
        type: this.selectedOption.type,
        condition: this.getFilterConditions(this.selectedOption.type)[0],
        filterInput: null,
        dropdown: this.selectedOption.dropdown,
        dropdownKeyToShow: this.selectedOption.dropdownKeyToShow,
        startDate: new Date(),
        endDate: new Date(),
        active: true,
      };
      const existingFilterIndex = this.selectedFilters.findIndex(filter => filter.dataKey === filterOptions.dataKey);

      if (existingFilterIndex != -1) {
        return;
      }
      this.selectedFilters.push(filterOptions);
      this.selectedOption = null;
    }
  }

  getUnselectedColumns() {
    return this.getTypeColumn().filter(
      column => !this.selectedFilters.some(filter => filter.dataKey === column.dataKey),
    );
  }

  getTypeColumn() {
    return this.tableColumns.filter(c => !c.name.includes('_') && c.type != ContentType.specialContent);
  }

  // Function to reset all Filter options
  resetFilterOptions() {
    this.selectedFilters = [];
    this.selectedOption = undefined;
    this.applyFilterOption();
  }

  onFilterActiveChange(filterKey: string) {
    this.selectedFilters = this.selectedFilters.map(f => (f.dataKey === filterKey ? { ...f, active: !f.active } : f));
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

  getDropdownKeyValue(dropdownItem: any): string {
    if (dropdownItem.hasOwnProperty('id')) {
      return dropdownItem.id.toString();
    }
    return '';
  }

  getFilterConditions(filterType: ContentType): Filter.Condition[] {
    switch (filterType) {
      case ContentType.datePicker:
      case ContentType.dateText:
        return this.filterTypeDateConditions;
      case ContentType.dropdownFields:
        return this.filterTypeDropdownConditions;
      default:
        return this.filterTypeInputConditions;
    }
  }
}
