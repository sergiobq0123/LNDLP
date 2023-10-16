import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GenericFilterComponent } from './generic-filter/generic-filter.component';
import { GenericFormDialogComponent } from './generic-form-dialog/generic-form-dialog.component';
import { GenericTableComponent } from './generic-table/generic-table.component';
import { GenericWindowComponent } from './generic-window/generic-window.component';
import { SpinnerComponent } from './spinner/spinner.component';
import { MaterialModule } from 'src/app/material/material/material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DeleteWindowComponent } from './delete-window/delete-window.component';



@NgModule({
  declarations: [
    GenericTableComponent,
    GenericFormDialogComponent,
    GenericWindowComponent,
    GenericFilterComponent,
    SpinnerComponent,
    DeleteWindowComponent
  ],
  imports: [
    CommonModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  exports: [
    GenericTableComponent,
    GenericFormDialogComponent,
    GenericWindowComponent,
    GenericFilterComponent,
    GenericTableComponent,
    SpinnerComponent,
    DeleteWindowComponent
  ]
})
export class GeneralModule { }
