import { TemplateRef } from '@angular/core';

export enum ContentType {
  plainText = 'plainText',
  editableTextFields = 'editableTextFields',
  dropdownFields = 'dropdownFields',
  multipleDropdownFields = 'multipleDropdownFields',
  radioButtons = 'radioButtons',
  checkbox = 'checkbox',
  datePicker = 'datePicker',
  dateText = 'dateText',
  specialContent = 'specialContent',
  imageFile = 'imageFile'
}

export interface PositionInGrid {
  col: number;
  row: number;
  colSpan: number;
  rowSpan: number;
}

export interface GenericContent {
  name: string;
  dataKey: string;
  type?: ContentType;
  hidden?: boolean;
  validators?: any[];
  width?: string;
  dropdown?: any[];
  dropdownKeyValue?: string;
  dropdownKeyToShow?: string;
  dropdownHasEmptyOption?: boolean;
  template?: TemplateRef<any>;
  radioButtons?: { value: any; shown: any }[];
  checkboxText?: string;
  matTooltip?: Function | string;
  matTooltipHeader?: string;
  matTooltipShowDelay?: number;
}

export interface GenericForm extends GenericContent {
  position?: PositionInGrid;
  style?: string;
}
