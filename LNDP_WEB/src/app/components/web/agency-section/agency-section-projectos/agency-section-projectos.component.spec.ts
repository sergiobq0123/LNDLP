import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AgencySectionProjectosComponent } from './agency-section-projectos.component';

describe('AgencySectionProjectosComponent', () => {
  let component: AgencySectionProjectosComponent;
  let fixture: ComponentFixture<AgencySectionProjectosComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AgencySectionProjectosComponent]
    });
    fixture = TestBed.createComponent(AgencySectionProjectosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
