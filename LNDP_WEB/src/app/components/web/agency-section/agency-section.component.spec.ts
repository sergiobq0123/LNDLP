import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AgencySectionComponent } from './agency-section.component';

describe('AgencySectionComponent', () => {
  let component: AgencySectionComponent;
  let fixture: ComponentFixture<AgencySectionComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AgencySectionComponent]
    });
    fixture = TestBed.createComponent(AgencySectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
