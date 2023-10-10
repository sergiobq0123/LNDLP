import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CollaborationAdminComponent } from './collaboration-admin.component';

describe('CollaborationAdminComponent', () => {
  let component: CollaborationAdminComponent;
  let fixture: ComponentFixture<CollaborationAdminComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CollaborationAdminComponent]
    });
    fixture = TestBed.createComponent(CollaborationAdminComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
