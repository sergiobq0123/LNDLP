import { ContentType } from '../generic-form-dialog/generic-content';

export class Filter {
  dataKey: string;
  name: string;
  type: ContentType;
  condition: Filter.Condition;
  filterInput: string[];
  dropdown?: any[];
  dropdownKeyToShow?: string;
  startDate?: Date;
  endDate?: Date;
  active: boolean;
}

export namespace Filter {
  export enum Condition {
    IS = 'is',
    IS_NOT = 'is not',
    CONTAINS = 'contains',
    MORE_OR_EQUALS = 'more or equals',
    LESS_OR_EQUALS = 'less or equals',
    BETWEEN = 'between',
    TODAY = 'today',
    YESTERDAY = 'yesterday',
    THIS_WEEK = 'this week',
    LAST_WEEK = 'last week',
    THIS_MONTH = 'this month',
    LAST_MONTH = 'last month',
    THIS_YEAR = 'this year',
    LAST_YEAR = 'last year',
  }
}
