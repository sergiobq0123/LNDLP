import { GenericContent } from '../generic-form-dialog/generic-content';
export interface Column extends GenericContent {
  position?: 'right' | 'left'; // should the data be right-aligned or left-aligned?
  isSortable?: boolean; // can the column be sorted?
  isFilterable?: boolean;
  isEnabledByDefault?: boolean; // can the column be sorted?
}
