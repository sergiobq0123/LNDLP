import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DossierWebComponent } from './dossier-web.component';

describe('DossierWebComponent', () => {
  let component: DossierWebComponent;
  let fixture: ComponentFixture<DossierWebComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DossierWebComponent]
    });
    fixture = TestBed.createComponent(DossierWebComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
