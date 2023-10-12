import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AgencySectionMarcasComponent } from './agency-section-marcas.component';

describe('AgencySectionMarcasComponent', () => {
  let component: AgencySectionMarcasComponent;
  let fixture: ComponentFixture<AgencySectionMarcasComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AgencySectionMarcasComponent]
    });
    fixture = TestBed.createComponent(AgencySectionMarcasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
