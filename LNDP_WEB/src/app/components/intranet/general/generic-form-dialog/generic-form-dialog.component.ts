import { Component, Inject, Input } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ValidatorService } from 'src/app/services/validator.service';
import { GenericForm } from './generic-content';
import { GenericFormDialogData } from './generic-form-dialog-data';

@Component({
  selector: 'app-form-generic-dialog',
  templateUrl: './generic-form-dialog.component.html',
  styleUrls: ['./generic-form-dialog.component.scss'],
})
export class GenericFormDialogComponent {
  constructor(
    public dialogRef: MatDialogRef<GenericFormDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: GenericFormDialogData,
    private fb: FormBuilder,
    private errorMessagesService: ValidatorService,
  ) {}

  VOForm: FormGroup;
  controls = {};
  loaded: boolean = false;
  rowHeight: string;
  gutterSize: string;
  selectedImage: string ;
  selectedImageBase64: string ;

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
    this.rowHeight = this.data.rowHeight ? this.data.rowHeight : '90px';
    this.gutterSize = this.data.gutterSize ? this.data.gutterSize : '15px';
    this.data.formFields.map(c => {
      this.controls[c.dataKey] = new FormControl({ value: '', disabled: false }, c.validators);
    });
    this.VOForm = this.fb.group(this.controls);
  }

  setData() {
    this.data.formFields.map(c => {
      let value;
      let dataKeys = c.dataKey.split('.');
      if (dataKeys.length > 1) {

        let mainKey = dataKeys.shift();
        let vl = Object.keys(this.data.formData).find(k => mainKey == k);
        value = dataKeys.reduce(
          (a, p) => {
            return a[p] == null ? '' : a[p];
          },
          this.data.formData[vl] == null ? '' : this.data.formData[vl],
        );
      } else {
        value = this.data.formData[c.dataKey];
      }
      if(c.dataKey === "photoUrl"){
        this.selectedImage = this.data.formData[c.dataKey]
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
        const dataURL = e.target?.result as string;
        this.selectedImage = dataURL
        const base64Data = dataURL.split(',')[1]; // Extraer la parte Base64
        this.selectedImageBase64 = base64Data; // Almacena la cadena Base64
      };
      reader.readAsDataURL(file);
    }
  }

  onSave() {
    let data = {};
    Object.keys(this.VOForm.controls).forEach((key) => {
      if (key == 'photoUrl') {
        console.log(data[key]);
        data[key] = this.selectedImageBase64;
      } else {
        data[key] = this.VOForm.get(key).value;
      }
      this.dialogRef.close(data);
    });
  }
}
