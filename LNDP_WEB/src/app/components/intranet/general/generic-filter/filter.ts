import { ContentType } from '../generic-form-dialog/generic-content';

export class Filter {
  dataKey: string;
  name: string;
  type: ContentType;
  condition: Filter.Condition;
  filterInput: string[];
  dropdown?: any[];
  dropdownKeyValue?: string;
  dropdownKeyToShow?: string;
  startDate?: Date;
  endDate?: Date;
  active: boolean;
}

export namespace Filter {
  export enum Condition {
    IS = 'is',
    IS_NOT = 'is not',
  }
}
