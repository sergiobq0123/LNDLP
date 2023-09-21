import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CrewAdminComponent } from './crew-admin.component';

describe('CrewAdminComponent', () => {
  let component: CrewAdminComponent;
  let fixture: ComponentFixture<CrewAdminComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CrewAdminComponent]
    });
    fixture = TestBed.createComponent(CrewAdminComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
