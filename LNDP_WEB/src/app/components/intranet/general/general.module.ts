import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GenericFormDialogComponent } from './generic-form-dialog/generic-form-dialog.component';
import { GenericTableComponent } from './generic-table/generic-table.component';
import { GenericWindowComponent } from './generic-window/generic-window.component';
import { SpinnerComponent } from './spinner/spinner.component';
import { MaterialModule } from 'src/app/material/material/material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DeleteWindowComponent } from './delete-window/delete-window.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { GenericFilterComponent } from './generic-filter/generic-filter.component';

@NgModule({
  declarations: [
    GenericTableComponent,
    GenericFormDialogComponent,
    GenericWindowComponent,
    SpinnerComponent,
    DeleteWindowComponent,
    GenericFilterComponent,
  ],
  imports: [
    CommonModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,
    FontAwesomeModule,
  ],
  exports: [
    GenericTableComponent,
    GenericFormDialogComponent,
    GenericWindowComponent,
    GenericTableComponent,
    SpinnerComponent,
    DeleteWindowComponent,
    GenericFilterComponent,
  ],
})
export class GeneralModule {}
