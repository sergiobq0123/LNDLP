import { TemplateRef } from "@angular/core";
import { ValidatorFn } from "@angular/forms";

export enum ContentType {
    plainText = 'plainText',
    editableTextFields = 'editableTextFields',
    dropdownFields = 'dropdownFields',
    radioButtons = 'radioButtons',
    checkbox = 'checkbox',
    datePicker = 'datePicker',
    specialContent = 'specialContent',
    buttonMap = 'buttonMap',
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
    template?: TemplateRef<any>;
    radioButtons?: { value: any, shown: any }[];
    checkboxText?: string;
}

export interface GenericForm extends GenericContent {
    position?: PositionInGrid;
}
