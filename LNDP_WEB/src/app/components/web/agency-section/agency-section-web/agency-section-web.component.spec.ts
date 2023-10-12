import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AgencySectionWebComponent } from './agency-section-web.component';

describe('AgencySectionWebComponent', () => {
  let component: AgencySectionWebComponent;
  let fixture: ComponentFixture<AgencySectionWebComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AgencySectionWebComponent]
    });
    fixture = TestBed.createComponent(AgencySectionWebComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
