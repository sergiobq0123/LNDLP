import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GenericSidenavComponent } from './generic-sidenav.component';

describe('GenericSidenavComponent', () => {
  let component: GenericSidenavComponent;
  let fixture: ComponentFixture<GenericSidenavComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GenericSidenavComponent]
    });
    fixture = TestBed.createComponent(GenericSidenavComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
