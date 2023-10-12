import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AgencySectionPartnersComponent } from './agency-section-partners.component';

describe('AgencySectionPartnersComponent', () => {
  let component: AgencySectionPartnersComponent;
  let fixture: ComponentFixture<AgencySectionPartnersComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AgencySectionPartnersComponent]
    });
    fixture = TestBed.createComponent(AgencySectionPartnersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
