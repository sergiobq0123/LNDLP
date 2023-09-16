import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FestivalAdminComponent } from './festival-admin.component';

describe('FestivalAdminComponent', () => {
  let component: FestivalAdminComponent;
  let fixture: ComponentFixture<FestivalAdminComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [FestivalAdminComponent]
    });
    fixture = TestBed.createComponent(FestivalAdminComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
