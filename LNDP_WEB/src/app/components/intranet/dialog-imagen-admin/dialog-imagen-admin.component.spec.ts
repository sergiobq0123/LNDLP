import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DialogImagenAdminComponent } from './dialog-imagen-admin.component';

describe('DialogImagenAdminComponent', () => {
  let component: DialogImagenAdminComponent;
  let fixture: ComponentFixture<DialogImagenAdminComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DialogImagenAdminComponent]
    });
    fixture = TestBed.createComponent(DialogImagenAdminComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
