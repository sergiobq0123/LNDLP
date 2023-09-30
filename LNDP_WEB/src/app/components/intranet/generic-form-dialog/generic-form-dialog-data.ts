import { GenericForm } from './generic-content';

export interface GenericFormDialogData {
  formData: any;
  formFields: GenericForm[];
  formCols: number;
  dialogTitle: string;
  rowHeight?: string;
  gutterSize?: string;
}
