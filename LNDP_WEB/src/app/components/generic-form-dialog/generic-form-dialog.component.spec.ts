import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GenericFormDialogComponent } from './generic-form-dialog.component';

describe('GenericFormDialogComponent', () => {
  let component: GenericFormDialogComponent;
  let fixture: ComponentFixture<GenericFormDialogComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GenericFormDialogComponent]
    });
    fixture = TestBed.createComponent(GenericFormDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
