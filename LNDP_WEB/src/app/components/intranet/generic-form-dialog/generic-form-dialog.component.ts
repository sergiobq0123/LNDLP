import { Component, ElementRef, Inject, Input, ViewChild } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { GenericForm } from './generic-content';
import { ValidatorService } from 'src/app/services/validator.service';

@Component({
  selector: 'app-form-generic-dialog',
  templateUrl: './generic-form-dialog.component.html',
  styleUrls: ['./generic-form-dialog.component.scss'],
})
export class GenericFormDialogComponent {
  constructor(
    public dialogRef: MatDialogRef<GenericFormDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private fb: FormBuilder,
    private errorMessagesService: ValidatorService
  ) {}

  VOForm: FormGroup;
  selectedImage: string | null = null;
  controls = {};
  imagenSeleccionada: string | null = null;
  loaded: boolean = false;

  ngOnInit(): void {
    this.buildForm();
    if (this.data.formData) {
      this.setData();
    }
    this.loaded = true;
  }

  getValidatorErrorMessage(errors): string {
    return this.errorMessagesService.getErrorMessage(errors);
  }

  buildForm() {
    this.data.formFields.map((c) => {
      this.controls[c.dataKey] = new FormControl(
        { value: '', disabled: false },
        c.validators
      );
    });
    this.VOForm = this.fb.group(this.controls);
  }

  setData() {
    this.data.formFields.map((c) => {
      let value;
      let dataKeys = c.dataKey.split('.');
      if (dataKeys.length > 1) {
        let mainKey = dataKeys.shift();
        let vl = Object.keys(this.data.formData).find((k) => mainKey == k);
        value = dataKeys.reduce(
          (a, p) => {
            return a[p] == null ? '' : a[p];
          },
          this.data.formData[vl] == null ? '' : this.data.formData[vl]
        );
      } else {
        value = this.data.formData[c.dataKey];
      }
      this.VOForm.controls[c.dataKey].patchValue(value);
    });
  }

  onImageInputChange(event: any) {
    const fileList: FileList = event.target.files;
    if (fileList.length > 0) {
      const file: File = fileList[0];
      const reader = new FileReader();
      reader.onload = (e) => {
        this.selectedImage = e.target?.result as string;
      };
      reader.readAsDataURL(file);
    }
  }

  removeSelectedImage() {
    this.selectedImage = null;
    const inputElement = document.querySelector(
      'input[type="file"]'
    ) as HTMLInputElement;
    if (inputElement) {
      inputElement.value = '';
    }
  }

  onSave() {
    let data = {};
    Object.keys(this.VOForm.controls).forEach((key) => {
      if (key == 'photo') {
        data[key] = this.selectedImage;
      } else {
        data[key] = this.VOForm.get(key).value;
      }
      this.dialogRef.close(data);
    });
  }
}
