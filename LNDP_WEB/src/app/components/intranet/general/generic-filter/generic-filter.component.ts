import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import {
  faCheck,
  faPlus,
  faSave,
  faUndo,
} from '@fortawesome/free-solid-svg-icons';
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
  filterTypeDropdownConditions: Filter.Condition[] = [
    Filter.Condition.IS,
    Filter.Condition.IS_NOT,
  ];
  filterTypeNumericConditions: Filter.Condition[] = [
    Filter.Condition.IS,
    Filter.Condition.IS_NOT,
  ];
  public FilterCondition = Filter.Condition;
  startDate: FormControl = new FormControl(Date.now, [Validators.required]);
  endDate: FormControl = new FormControl(Date.now, [Validators.required]);

  @Input() tableDataSource;
  @Input() tableColumns: Column[];

  @Output() filtered: EventEmitter<Filter[]> = new EventEmitter();

  faCheck = faCheck;
  faSave = faSave;
  faPlus = faPlus;
  faUndo = faUndo;

  constructor(private notificationService: NotificationService) {}

  ngOnInit() {
    if (!this.selectedFilters || this.selectedFilters.length >= 0) {
      this.selectedFilters = [];
    }
    this.selectedOption = null;
  }

  // Function to Find selectedOptions assing by the user
  applyFilterOption() {
    if (this.startDate.invalid || this.endDate.invalid) {
      return;
    }
    const filters: Filter[] = this.selectedFilters.filter((f) => f.active);
    this.filtered.emit(filters);
  }

  // Function to add all selected filters to an array
  addFilter() {
    if (this.selectedOption) {
      const filterOptions: Filter = {
        dataKey: this.selectedOption.dataKey,
        name: this.selectedOption.name,
        type: this.selectedOption.type,
        condition: this.getFilterConditions(this.selectedOption)[0],
        filterInput: null,
        dropdown: this.selectedOption.dropdown,
        dropdownKeyToShow: this.selectedOption.dropdownKeyToShow,
        startDate: new Date(),
        endDate: new Date(),
        active: true,
      };
      const existingFilterIndex = this.selectedFilters.findIndex(
        (filter) => filter.dataKey === filterOptions.dataKey
      );

      if (existingFilterIndex != -1) {
        return;
      }
      this.selectedFilters.push(filterOptions);
      this.selectedOption = null;
    }
  }

  getUnselectedColumns() {
    return this.getTypeColumn().filter(
      (column) =>
        !this.selectedFilters.some(
          (filter) => filter.dataKey === column.dataKey
        )
    );
  }

  getTypeColumn() {
    return this.tableColumns.filter((c) => c.isFilterable);
  }

  // Function to reset all Filter options
  resetFilterOptions() {
    this.selectedFilters = [];
    this.selectedOption = undefined;
    this.applyFilterOption();
  }

  onFilterActiveChange(filterKey: string) {
    this.selectedFilters = this.selectedFilters.map((f) =>
      f.dataKey === filterKey ? { ...f, active: !f.active } : f
    );
  }

  getDropdownKeyValue(dropdownValue: any, filter: Filter): string {
    return dropdownValue[filter.dropdownKeyToShow];
  }

  getFilterConditions(column: Column): Filter.Condition[] {
    switch (column.type) {
      case ContentType.datePicker:
      case ContentType.dateText:
        return this.filterTypeDateConditions;
      case ContentType.dropdownFields:
        return this.filterTypeDropdownConditions;
      case ContentType.numericField:
        return this.filterTypeNumericConditions;
      default:
        if (column.dropdown) {
          return this.filterTypeDropdownConditions;
        }
        return this.filterTypeInputConditions;
    }
  }
}
